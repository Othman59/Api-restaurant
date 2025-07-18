namespace Api_restaurant.Classes
{
    public class Article
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public decimal Prix { get; set; }
        public string? Categorie { get; set; }
        public string? Secret { get; set; }

        public List<CommandeArticle> CommandeArticles { get; set; } = new();

    }
}
