namespace BankAccountLibrary
{
    public class Owner
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Owner(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
