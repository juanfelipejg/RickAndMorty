namespace RickAndMorty.Tests
{
	using Xunit;

	public class CharacterTests
	{
		[Fact]
		public void GetAllTest()
		{
			////Arrange
			//var mock = new Mock<ICharacterGetter>();
			//var context = new Mock<IRickAndMortyContext>();
			//var logger = new Mock<ILogger<CharacterService>>();

			//var characterService = new CharacterService( mock.Object, context.Object, logger.Object );

			//var character = new Character
			//{
			//	Name = "Rick Sanchez",
			//	Gender = "Male",
			//	Image = "https://rickandmortyapi.com/api/character/avatar/2.jpeg",
			//	Species = "Human",
			//	Status = "Alive",
			//};

			//var characterResults = new List<Character>() { character };			
			//mock.Setup( x => x.GetAll() ).Returns( characterResults );

			////Act
			//IEnumerable<Character> characters = characterService.GetAll();

			////Assert
			//Assert.NotNull( characters );
		}
	}
}