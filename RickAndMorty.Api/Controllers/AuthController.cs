namespace RickAndMorty.Api.Controllers
{
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using RickAndMorty.Dtos;

	[Route( "api/[controller]" )]
	[ApiController]
	public class AuthController: ControllerBase
	{
		private readonly IConfiguration _configuration;

		public AuthController( IConfiguration configuration )
		{
			this._configuration = configuration;
		}

		[HttpPost( "login" )]
		public IActionResult Login( [FromBody] LoginModel model )
		{
			string token = this.GenerateJwtToken( model.Username );
			return this.Ok( new { token } );
		}

		private string GenerateJwtToken( string username )
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.ASCII.GetBytes( _configuration["Jwt:SecretKey"] );

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity( new Claim[]
				{
					new Claim(ClaimTypes.Name, username),
				} ),
				Expires = DateTime.UtcNow.AddHours( 1 ),
				SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( key ), SecurityAlgorithms.HmacSha256Signature )
			};

			SecurityToken token = tokenHandler.CreateToken( tokenDescriptor );
			return tokenHandler.WriteToken( token );
		}
	}
}