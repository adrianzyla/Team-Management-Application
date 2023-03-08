using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamManagementAppGUI
{
    [Serializable]
    public enum EnumSex {M,F}
    public abstract class Person : IEquatable<Person>
    {
        protected string name;
        protected string surname;
        protected string street;
        protected string city;
        protected int zipCode;
        protected DateTime dateOfBirth;
        protected string pesel;
        protected EnumSex sex;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public int ZipCode { get => zipCode; set => zipCode = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Pesel
        {
            get => pesel;
            set
            {
                if (!Regex.IsMatch(value, @"^\D*(\d\D*){11}$"))
                    throw new ArgumentException("PESEL number should contain 11 numbers");
                pesel = value;
            }
        }
        public EnumSex Sex { get => sex; set => sex = value; }

        public Person() { this.Pesel = "00000000000"; }
        public Person(string name, string surname, EnumSex sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
        }

        public Person(string name, string surname, string dateOfBirth, string pesel, EnumSex sex) : this(name, surname, sex)
        {
            DateTime date;
            DateTime.TryParseExact(dateOfBirth, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            DateOfBirth = date;
            Pesel = pesel;
            
        }
        public Person(string name, string surname, string street, string city, int zipCode, string dateOfBirth, string pesel, EnumSex sex) : this(name, surname,dateOfBirth, pesel, sex)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public int Age()
        {
            return DateTime.Now.Year - this.dateOfBirth.Year;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} ({sex}), ur. {DateOfBirth.ToString("yyyy-mm-dd")} ({Pesel}), {street}, {zipCode} {city}";
        }

        public bool Equals(Person other)
        {
            {
                if (Pesel == other.Pesel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
