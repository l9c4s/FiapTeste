namespace FrontEnd.Fiap.Request.Interface
{
    public interface IRequest
    {
        Task<T> GetByIdAsync<T>(string Endpoint, int id);
        Task<IQueryable<T?>> GetAsync<T>(string Endpoint);
        Task<T> PostAsync<T>(T Entidade, string Endpoint);
        Task<T> PostWithIdAsync<T>(int id, string Endpoint);
        Task<T> PutAsync<T>(T Entidade, string Endoint);
        Task<T> DeleteAsync<T>(T entidade, string Endpoint);

        Task<bool> PostAsyncBool(string Dado, string Endpoint);

    }
}
