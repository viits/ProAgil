using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {

        private readonly ProAgilContext context;

        public ProAgilRepository(ProAgilContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;

        }
        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        //EVENTOS Get
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = this.context.Eventos
            .Include(x => x.Lotes)
            .Include(x => x.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestrantesEvento)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.AsNoTracking().OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventosAsyncTema(string tema, bool includePalestrante)
        {

            IQueryable<Evento> query = this.context.Eventos
            .Include(x => x.Lotes)
            .Include(x => x.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestrantesEvento)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.AsNoTracking().OrderByDescending(c => c.DataEvento)
            .Where(t => t.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Evento> GetEventoAsyncId(int id, bool includePalestrante)
        {
            IQueryable<Evento> query = this.context.Eventos
           .Include(x => x.Lotes)
           .Include(x => x.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestrantesEvento)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.AsNoTracking().OrderByDescending(c => c.DataEvento)
            .Where(t => t.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante> GetPalestranteIdAsync(int id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes
              .Include(x => x.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEvento)
                .ThenInclude(e => e.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Name)
            .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestranteAsyncName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes
             .Include(x => x.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEvento)
                .ThenInclude(e => e.Evento);
            }
            query = query.AsNoTracking().Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}