using System;

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
        /// Provides the string representation of owner
        /// </summary>
        /// <returns>The string representation of owner</returns>
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
