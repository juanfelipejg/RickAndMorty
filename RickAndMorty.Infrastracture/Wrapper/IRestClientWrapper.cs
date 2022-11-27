namespace RickAndMorty.Infrastracture.Wrapper
{
    using RestSharp;

    public interface IRestClientWrapper
    {
        T Get<T>( RestRequest request ) where T : class;
    }
}
