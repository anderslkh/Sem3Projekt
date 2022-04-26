using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopConsumer.Models
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nickName { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; }

        public Person(string firstName, string lastName, string nickName, DateTime birthDate, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.nickName = nickName;
            this.birthDate = birthDate;
            this.email = email;
        }
    }
}
