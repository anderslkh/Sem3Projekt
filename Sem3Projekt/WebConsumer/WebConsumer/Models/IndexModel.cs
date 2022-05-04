using System.Dynamic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebConsumer.Models {
    public class IndexModel : PageModel {
        public string Name { get; set; }
        public void OnGet()
        { 
            Name = HttpContext.User.Identity.Name;
        }
    }
}
