namespace Proiect_Rochii.Models
{
    public class Designer
    {
        public int ID { get; set; }
        public string NumeDesigner { get; set; }
        public ICollection<Rochie>? Rochii { get; set; }
    }
}
