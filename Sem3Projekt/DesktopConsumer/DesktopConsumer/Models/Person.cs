using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopConsumer.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; }
        public string Password { get; set; }

        public Person(string firstName, string lastName, string nickName, DateTime birthDate, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = nickName;
            this.BirthDate = birthDate;
            this.Email = email;
        }

        public Person()
        {

        }
        public Person(string userName, string password)
        {
            Password = password;
        }

        public override string ToString()
        {
            return $"Navn: {FirstName} {LastName} | Brugernavn: {UserName} | Email: {Email}";
        }
    }
}
