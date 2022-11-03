using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Validator;
using System.Reflection.Metadata;

namespace SevStudentsApp.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ILogger<SignUpModel> _logger;

        public SignUpModel(ILogger<SignUpModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {  
            Response.Redirect("/Index");
        }

    }
}