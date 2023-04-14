namespace RickAndMorty.Infrastracture
{
	using AutoMapper;
	using RestSharp;
	using RickAndMorty.Domain.Models.Characters;
	using RickAndMorty.Domain.Services;
	using RickAndMorty.Infrastracture.Wrapper;
	using System.Collections.Generic;

	public class CharacterGetter: ICharacterGetter
	{
		private readonly IRestClientWrapper restClientWrapper;
		private readonly IMapper mapper;

		public CharacterGetter( IRestClientWrapper restClientWrapper, IMapper mapper )
		{
			this.restClientWrapper = restClientWrapper;
			this.mapper = mapper;
		}

		public IEnumerable<Character> GetAll()
		{
			var request = new RestRequest( "/character" );
			var response = this.restClientWrapper.Get<Dtos.Character.CharacterResults>( request );
			return this.mapper.Map<IEnumerable<Dtos.Character.Character>, IEnumerable<Character>>( response.Results );
		}
	}
}