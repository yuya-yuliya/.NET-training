using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class Owner
    {
        private string _firstName;
        private string _lastName;

        public Owner(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (value != null && value != "")
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            private set
            {
                if (value != null && value != "")
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void ChangeFirstName(string newFirsName)
        {
            FirstName = newFirsName;
        }

        public void ChangeLastName(string newLastName)
        {
            LastName = newLastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
