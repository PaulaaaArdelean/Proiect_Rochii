namespace Proiect_Rochii.Models
{
    public class CategorieRochie
    {
        public int ID { get; set; }
        public int RochieID { get; set; }
        public Rochie Rochie { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
