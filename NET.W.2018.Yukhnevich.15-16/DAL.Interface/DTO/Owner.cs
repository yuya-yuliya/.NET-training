using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Represents owner of the account
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// The owner first name
        /// </summary>
        private string _firstName;

        /// <summary>
        /// The owner last name
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Initialize new instance of Owner class
        /// </summary>
        /// <param name="firstName">The first name</param>
        /// <param name="lastName">The last name</param>
        public Owner(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// The owner first name
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (value != null && value != string.Empty)
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// The owner last name
        /// </summary>
        public string LastName
        {
            get => _lastName;
            private set
            {
                if (value != null && value != string.Empty)
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Changes the owner first name
        /// </summary>
        /// <param name="newFirsName"></param>
        public void ChangeFirstName(string newFirsName)
        {
            FirstName = newFirsName;
        }

        /// <summary>
        /// Changes the owner last name
        /// </summary>
        /// <param name="newLastName"></param>
        public void ChangeLastName(string newLastName)
        {
            LastName = newLastName;
        }

        /// <summary>
        /// Checks the equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            Owner owner = (Owner)obj;
            return owner.FirstName == this.FirstName &&
                owner.LastName == this.LastName;
        }

        /// <summary>
        /// Gets hash code of current instance
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = 1464659268;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_lastName);
            return hashCode;
        }

        /// <summary>
        /// Provides the string representation of owner
        /// </summary>
        /// <returns>The string representation of owner</returns>
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
