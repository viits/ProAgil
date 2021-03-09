using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Evento[]> GetAllEventosAsyncTema(string tema, bool includePalestrante);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
        Task<Evento> GetEventoAsyncId(int id,bool includePalestrante);

        Task<Palestrante[]> GetAllPalestranteAsyncName(string name, bool includeEventos);
        Task<Palestrante> GetPalestranteIdAsync(int id, bool includeEventos);

    }
}