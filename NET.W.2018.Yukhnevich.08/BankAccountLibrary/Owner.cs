namespace BankAccountLibrary
{
    /// <summary>
    /// Represents the information of owner
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Initialize the new instance of Owner class that has information
        /// </summary>
        /// <param name="name">The owner name</param>
        /// <param name="surname">The owner surname</param>
        public Owner(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        /// <summary>
        /// The owner name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The owner surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Get string of the owner information
        /// </summary>
        /// <returns>The string with information of owner</returns>
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
