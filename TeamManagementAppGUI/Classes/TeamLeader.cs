using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamManagementAppGUI
{
    [Serializable]
    public class TeamLeader : Person, ICloneable
    {
        int experience;
        long phoneNumber;


        public int Experience { get => experience; set => experience = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public TeamLeader() { }
        public TeamLeader(int experience, long phoneNumber, string name, string surname, string street, string city, int zipCode, string dateOfBirth, string pesel, EnumSex sex) : base(name, surname, street, city, zipCode, dateOfBirth, pesel, sex)
        {
            Experience = experience;
            PhoneNumber = phoneNumber;
        }

        public TeamLeader(string pesel, string name, string surname, string dateOfBirth, EnumSex sex, int experience) : base(name, surname, dateOfBirth, pesel, sex)
        {
            this.pesel = pesel;
            this.name = name;
            this.surname = surname;
            this.sex = sex;
            this.experience = experience;
            DateTime date;
            DateTime.TryParseExact(dateOfBirth, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            DateOfBirth = date;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}, {DateOfBirth.ToString("dd-MM-yyyy")} ({Pesel}) ({Sex}), {Experience} years of experience";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
