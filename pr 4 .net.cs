using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventRegistrationPortal.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Enter a 10-digit phone number")]
        public string Phone { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Please select an event")]
        public string EventName { get; set; } = "";

        public bool IsRegistered { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (EventName != "Technical Workshop" &&
                EventName != "Coding Competition" &&
                EventName != "Cultural Fest" &&
                EventName != "Sports Event")
            {
                ModelState.AddModelError(
                    nameof(EventName), "Please select a valid event");
            }

            if (ModelState.IsValid)
            {
                IsRegistered = true;
            }
        }
    }
}
