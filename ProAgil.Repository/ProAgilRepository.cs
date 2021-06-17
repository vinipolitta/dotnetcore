using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Domain.Models;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilRepository(ProAgilContext _context)
        {
            this._context = _context;

        }
        public ProAgilContext _context { get; }
     

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        //EVENTO

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento)
                    .Where(c => c.Tema.Contains(tema));

            return await query.ToArrayAsync();
        }


        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
               .Include(c => c.Lotes)
               .Include(c => c.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento)
                    .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        //PALESTRANTE

        public async Task<Palestrante> GetAllPalestrantesAsyncByName(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
              .Include(c => c.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Nome)
                    .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante> GetPalestrantesAsync(string nome, bool includeEventos)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
              .Include(c => c.RedeSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Nome)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.FirstOrDefaultAsync();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante> GetPalestrantesAsync(int PalestranteId, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }
    }
}