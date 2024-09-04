
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace NameGenerator.Pages
{
    public class NameGeneratorModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NameGeneratorModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public string GeneratedName { get; set; }

        public void OnPost()
        {
            // Get the full path to the JSON file
            var jsonFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "data", "wizardnames.json");

            // Read the JSON file content
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);

            // Parse the JSON to get name parts
            var nameParts = JsonSerializer.Deserialize<NameParts>(jsonData);

            if (nameParts != null)
            {
                // Randomly pick from FirstPart and SecondPart
                var random = new Random();
                string firstPart = nameParts.FirstPart[random.Next(nameParts.FirstPart.Length)];
                string secondPart = nameParts.SecondPart[random.Next(nameParts.SecondPart.Length)];

                // Concatenate the selected parts to form a wizard name
                GeneratedName = firstPart + secondPart;
            }
        }

        // Class to map the JSON data
        public class NameParts
        {
            public string[] FirstPart { get; set; }
            public string[] SecondPart { get; set; }
        }
    }
}