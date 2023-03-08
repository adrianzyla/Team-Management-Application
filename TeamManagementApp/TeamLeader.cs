using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamManagementApp
{
    [Serializable]
    public class TeamLeader : Person, ICloneable
    {
        int experience;
        long phoneNumber;

        public int Experience { get => experience; set => experience = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public TeamLeader()
        {

        }
        public TeamLeader(string pesel, string name, string surname, string dateOfBirth, EnumSex sex, int experience) : base(name, surname, dateOfBirth, pesel, sex)
        {
            this.pesel = pesel;
            this.name = name;
            this.surname = surname;
            this.sex = sex;
            Experience = experience;
        }
        public TeamLeader(int experience, long phoneNumber, string name, string surname, string street, string city, int zipCode, string dateOfBirth, string pesel, EnumSex sex) : base(name, surname, street, city, zipCode, dateOfBirth, pesel, sex)
        {
            Experience = experience;
            PhoneNumber = phoneNumber;
        }


        public override string ToString()
        {
            return $"{Name} {Surname}, ur. {DateOfBirth.ToString("yyyy-mm-dd")} ({Pesel}) ({Sex}) (tel. no. {PhoneNumber}), {Experience} years of experience";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
