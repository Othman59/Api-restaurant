namespace Api_restaurant.Classes
{
    public class Client
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

    }
}
