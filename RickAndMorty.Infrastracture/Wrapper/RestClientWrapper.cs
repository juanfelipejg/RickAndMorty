namespace RickAndMorty.Infrastracture.Wrapper
{
    using RestSharp;

    public class RestClientWrapper : IRestClientWrapper
    {
        private readonly RestClient client;

        public RestClientWrapper()
        {
            this.client = new RestClient( "https://rickandmortyapi.com/api" );
        }

        public T Get<T>( RestRequest request ) where T : class
        {
            return this.client.Get<T>( request );
        }
    }
}
