using Api_restaurant.Classes;

namespace Api_restaurant.DTO
{
    public class CommandeItemDTO
    {
        public int ClientsId { get; set; }
        public List<int> ArticleIds { get; set; } = new();


    }

}
