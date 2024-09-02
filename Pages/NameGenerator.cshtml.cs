using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NameGenerator.Pages
{
    public class NameGeneratorModel : PageModel
    {
        [BindProperty]
        public string GeneratedName { get; set; }

        public void OnPost()
        {
            // Placeholder logic for generating a name
            GeneratedName = "GeneratedNamePlaceholder";
        }
    }
}