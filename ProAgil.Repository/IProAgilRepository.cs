using System.Threading.Tasks;
using ProAgil.Domain;
using ProAgil.Domain.Models;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //Geral
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();


        //EVENTOS
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes);

        //PALESTRANTE

        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos);
        Task<Palestrante> GetPalestrantesAsync(int PalestranteId, bool includeEventos);

    }
}