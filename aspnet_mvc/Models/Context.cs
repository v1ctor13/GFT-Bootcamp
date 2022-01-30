using Microsoft.EntityFrameworkCore;


namespace aspnet_mvc.Models {

    public class Context : DbContext {

        public DbSet<Categoria>? Categorias { get; set; }

        public Context(DbContextOptions options) : base(options) {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=12345;database=test");
        }

    }

}