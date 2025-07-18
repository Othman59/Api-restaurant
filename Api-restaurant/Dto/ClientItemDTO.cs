using Api_restaurant.Classes;

namespace Api_restaurant.Dto
{
    public class ClientItemDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NumeroDeRue { get; set; } = string.Empty;
        public string NomDeRue { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;

        public ClientItemDTO() { }
        public ClientItemDTO(Client clientsItem) => 
            
        (Id, Nom, Prenom, Telephone, Email, NumeroDeRue, NomDeRue, CodePostal, Ville) = (clientsItem.Id, clientsItem.Nom, clientsItem.Prenom, clientsItem.Telephone , clientsItem.Email, clientsItem.NumeroDeRue, clientsItem.NomDeRue, clientsItem.CodePostal, clientsItem.Ville);
    }
}
