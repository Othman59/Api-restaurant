namespace Api_restaurant.Classes
    {
        public class Commande
        {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal MontantTotal { get; set; }
        public string StatutLivraison { get; set; } = "En cours";

        public int ClientId { get; set; }

        public List<CommandeArticle> CommandeArticles { get; set; } = new();
    }
    }
