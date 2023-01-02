namespace Proiect_Rochii.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieRochie>? CategoriiRochii { get; set; }
    }
}
