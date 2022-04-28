using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }    
        public DateTime BirthDate { get; set; }
        

        public Person()
        {
        }
        public Person(string firstName, string lastName, string nickName, DateTime birthDate, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            BirthDate = birthDate;
            Email = email;
        }
    }
}
