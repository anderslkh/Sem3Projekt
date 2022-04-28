using Microsoft.AspNetCore.Identity;

namespace WebConsumer.Models
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string nickName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string firstName, string lastName, string nickName, DateTime birthDate, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            this.nickName = nickName;
            BirthDate = birthDate;
            Email = email;
        }

        public Person(string userName, string password) : base(userName)
        {
            Password = password;
        }
    }
}
