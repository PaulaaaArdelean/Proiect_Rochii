namespace Proiect_Rochii.Models
{
    public class RochieData
    {
        public IEnumerable<Rochie> Rochii { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieRochie> CategoriiRochii { get; set; }
    }
}
