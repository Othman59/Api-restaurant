using Api_restaurant.Classes;
using Microsoft.EntityFrameworkCore;
using System;


namespace Api_restaurant.Data
{
    public class RestaurantDb : DbContext
    {

        public RestaurantDb(DbContextOptions<RestaurantDb> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Commande> Commandes => Set<Commande>();
        public DbSet<CommandeArticle> CommandeArticles => Set<CommandeArticle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Définir une clé primaire composite sur CommandeArticle
            modelBuilder.Entity<CommandeArticle>()
                .HasKey(ca => new { ca.CommandeId, ca.ArticleId });



        }
    }
}
