using Api_restaurant.Classes;

namespace Api_restaurant.Dto
{
    public class ArticleItemDTO
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public decimal Prix { get; set; }
        public string? Categorie { get; set; }

        public ArticleItemDTO() { }
        public ArticleItemDTO(Article ArticlesItem) =>

        (Id, Nom, Prix, Categorie) = (ArticlesItem.Id, ArticlesItem.Nom, ArticlesItem.Prix, ArticlesItem.Categorie);
    }
}
