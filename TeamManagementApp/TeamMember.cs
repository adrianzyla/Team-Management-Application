using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamManagementApp
{
    [Serializable]
    public class TeamMember : Person, IComparable<TeamMember>, ICloneable
    {
        DateTime joinDate;
        string teamFunction;
        bool active;

        public DateTime JoinDate { get => joinDate; set => joinDate = value; }
        public string TeamFunction { get => teamFunction; set => teamFunction = value; }
        public bool Active { get => active; set => active = value; }

        public TeamMember()
        {

        }
        public TeamMember(string joinDate, string teamFunction, bool active, string name, string surname, string street, string city, int zipCode, string dateOfBirth, string pesel, EnumSex sex) : base(name, surname, street, city, zipCode, dateOfBirth, pesel, sex)
        {
            DateTime date;
            DateTime.TryParseExact(joinDate, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            JoinDate = date;
            TeamFunction = teamFunction;
            Active = active;
        }
     
        public override string ToString()
        {
            return $"{Name} {Surname} {(Active == true ? " (active)" : " (not active)")}, ur. {DateOfBirth.ToString("yyyy -mm-dd")} ({Pesel}) ({Sex}) {TeamFunction} ";
        }

        public int CompareTo(TeamMember other)
        {
            if (object.ReferenceEquals(other, null))
                return 1;
            int result = Surname.CompareTo(other.Surname);
            if (result == 0)
                return Name.CompareTo(other.Name);
            return result;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
