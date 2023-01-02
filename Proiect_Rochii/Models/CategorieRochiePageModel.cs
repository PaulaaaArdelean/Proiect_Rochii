using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Rochii.Data;
namespace Proiect_Rochii.Models
{
    public class CategorieRochiePageModel:PageModel
    {
 public List<CategorieAsignataData> CategorieAsignataDataList;
        public void PopulateAssignedCategoryData(Proiect_RochiiContext context,
        Rochie rochie)
        {
            var allCategories = context.Categorie;
            var rochieCategorii = new HashSet<int>(
            rochie.CategoriiRochii.Select(c => c.CategorieID)); //
            CategorieAsignataDataList = new List<CategorieAsignataData>();
            foreach (var cat in allCategories)
            {
                CategorieAsignataDataList.Add(new CategorieAsignataData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Asignata = rochieCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateRochieCategorii(Proiect_RochiiContext context,
        string[] selectedCategories, Rochie rochieToUpdate)
        {
            if (selectedCategories == null)
            {
                rochieToUpdate.CategoriiRochii = new List<CategorieRochie>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var rochieCategorii = new HashSet<int>
            (rochieToUpdate.CategoriiRochii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!rochieCategorii.Contains(cat.ID))
                    {
                        rochieToUpdate.CategoriiRochii.Add(
                        new CategorieRochie
                        {
                            RochieID = rochieToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (rochieCategorii.Contains(cat.ID))
                    {
                        CategorieRochie courseToRemove
                        = rochieToUpdate
                        .CategoriiRochii
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
