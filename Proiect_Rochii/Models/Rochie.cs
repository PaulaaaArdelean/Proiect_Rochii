using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.Security.Policy;

namespace Proiect_Rochii.Models
{
    public class Rochie
    {
        public int ID { get; set; }
        [Display(Name = "Denumirea Rochiei")]
        public string Denumire { get; set; }
      //  public string Designer { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Range(0.01, 100000)]
        public decimal Pret { get; set; }
        public String Marime { get; set; }

        public int? DesignerID { get; set; }
        public Designer? Designer { get; set; } //navigation property
        public ICollection<CategorieRochie>? CategoriiRochii { get; set; }

    }




}
