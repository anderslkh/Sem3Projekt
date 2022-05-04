using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    public class RegisterModel
    {
        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime BirthDate { get; set; }

        public string? FirstName { get; set; }

        public string LastName { get; set; }
    }
}
