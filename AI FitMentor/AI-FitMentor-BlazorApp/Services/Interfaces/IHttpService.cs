namespace AI.FitMentor.BlazorApp.Services.Interfaces
{

public interface IHttpService
{
    Task<T> Get<T>(string uri);

    Task<T> Post<T>(string uri, object value);
    Task<T> Post<T>(string uri);
    Task Post(string uri);


    Task Post(string uri, object value);

    Task<T> Put<T>(string uri, object value);
    Task<T> Put<T>(string uri);
    Task Put(string uri);

    Task<T> Delete<T>(string uri);


}
}

