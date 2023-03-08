using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeamManagementAppGUI
{
    [Serializable]
    public class Team : ICloneable, ITeam
    {
        int numberOfActiveTeamMembers;
        string teamName;
        TeamLeader teamLeader;
        List<TeamMember> teamMembers = new List<TeamMember>();
        

        public int NumberOfActiveTeamMembers { get => numberOfActiveTeamMembers; set => numberOfActiveTeamMembers = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public TeamLeader TeamLeader { get => teamLeader; set => teamLeader = value; }
        public List<TeamMember> TeamMembers { get => teamMembers; set => teamMembers = value; }

        public Team()
        {
            numberOfActiveTeamMembers = 0;
            teamName = null;
            teamLeader = null;
            teamMembers = new List<TeamMember>();
        }

        public Team(string teamName, TeamLeader teamLeader) :this()
        {
            this.teamName = teamName;
            this.teamLeader = teamLeader;
        }

        public void AddMember(TeamMember t)
        {
            if (!this.teamMembers.Contains(t))
            {
                teamMembers.Add(t);
                numberOfActiveTeamMembers++;
            }
        }

        public void RemoveMember(string pesel)
        {
            if (this.TeamMembers.FirstOrDefault(c => c.Pesel == pesel) == null)
                return;

            this.TeamMembers.Remove(this.TeamMembers.FirstOrDefault(c => c.Pesel == pesel));
        }
        public void RemoveMember(TeamMember t)
        {
            teamMembers.Remove(t);
            numberOfActiveTeamMembers--;
        }
        public void DeleteAll(Team t)
        {
            this.teamMembers.ForEach(t.RemoveMember);
            numberOfActiveTeamMembers = 0;
        }
        public void Sort()
        {
            this.teamMembers.Sort();
        }
        public void SortByPESEL()
        {
            this.teamMembers.Sort(new PESELComparator());
        }

        public List<TeamMember> FindInactiveMembers()
        {
            return teamMembers.Where(x => x.Active == false).ToList();
        }

        public List<TeamMember> FindMembers(string function)
        {
            return teamMembers.Where(x => x.TeamFunction == function).ToList();
        }
        public List<TeamMember> FindMembers(int month)
        {
            return teamMembers.Where(x => x.JoinDate.Month == month).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(TeamName);
            sb.AppendLine(teamLeader.ToString());
            foreach (TeamMember member in TeamMembers)
            {
                sb.AppendLine(member.ToString());
            }
            return sb.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public object DeepClone()
        {
            Team team = new Team();
            team = (Team)this.MemberwiseClone();
            team.TeamMembers = new List<TeamMember>();
            foreach (TeamMember member in this.TeamMembers)
                team.AddMember((TeamMember)member.Clone());

            team.TeamLeader = (TeamLeader)this.TeamLeader.Clone();
            return team;
        }

        public static void SaveXML(string name, Team z)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Team));
            TextWriter writer = new StreamWriter($"{name}");
            serializer.Serialize(writer, z);
            writer.Close();
        }
        public static Team ReadXML(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Team));
            FileStream fs = new FileStream($"{name}", FileMode.Open);
            return (Team)serializer.Deserialize(fs);
        }
    }
}
