using Microsoft.EntityFrameworkCore;
using api_tarefas.Model;

namespace api_tarefas.Contextos
{
    public class TarefaContexto : DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto> option) : base(option)
        {

        }

        public DbSet<TarefaItem> Tarefas { get; set; } = null;
    }
}
