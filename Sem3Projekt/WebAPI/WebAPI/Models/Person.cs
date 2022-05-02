using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        

        public Person(string firstName, string lastName, string userName, DateTime birthDate, string email) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
        }
    }
}
