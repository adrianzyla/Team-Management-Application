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
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team("Power Team", new TeamLeader(5, 735701894, "Adrian", "Zyla", "Golden Street", "New York", 89990, "1995-25-10", "12345678901", EnumSex.M));
            team.AddMember(new TeamMember("2018-10-10", "programmer", true, "Kacper", "Borys", "Milennial Street", "Chickago", 85292, "1998-02-07", "12312312312", EnumSex.M));
            team.AddMember(new TeamMember("2017-04-12", "data analyst", true, "Emilia", "Sroka", "Golden Street", "New York", 89990, "1998-03-07", "69006028442 ", EnumSex.F));
            team.AddMember(new TeamMember("2016-04-11", "social media menager", true, "Kasia", "Karwacka", "Green Street", "Chickago", 76555, "1998-01-07", "17754285911 ", EnumSex.F));
            team.AddMember(new TeamMember("2020-11-03", "programmer", false, "Alek", "Chmura", "Green Street", "Chickago", 76555, "1998-10-07", "51648303971 ", EnumSex.M));
            Team teamSave = new Team();
            Team.SaveXML("teamFile", team);

            Team teamA = new Team("Codex Team", new TeamLeader(5, 735701894, "Piotr", "Rosomak", "Blue Street", "New York", 89990, "1995-25-10", "15779463130", EnumSex.M));
            teamA.AddMember(new TeamMember("2018-10-10", "programmer", true, "Filip", "Laphm", "Milennial Street", "Chickago", 85292, "1998-02-07", "28259455342", EnumSex.M));
            teamA.AddMember(new TeamMember("2017-04-12", "data analyst", true, "Simon", "Cowel", "Blue Street", "New York", 89990, "1998-03-07", "94995552686 ", EnumSex.F));
            teamA.AddMember(new TeamMember("2016-04-11", "social media menager", true, "Kathrin", "Everdeen", "Flowe Street", "Chickago", 76555, "1998-01-07", "53571620639", EnumSex.F));
            teamA.AddMember(new TeamMember("2020-11-03", "programmer", false, "Alex", "Ross", "Flower Street", "Chickago", 76555, "1998-10-07", "36207668635 ", EnumSex.M));
            Team.SaveXML("teamAFile", teamA);
            Console.WriteLine(team.ToString());
            Console.WriteLine(teamA.ToString());
            Console.WriteLine();

            

            //Console.WriteLine("-------------------TEAM-------------------");
            //Console.WriteLine(team);

            //Console.WriteLine("-------------------SORTED------------------");
            //team.Sort();
            //Console.WriteLine(team);

            //Console.WriteLine("-------------------SORTED BY PESEL------------------");
            //team.SortByPESEL();
            //Console.WriteLine(team);

            ////Płytkie klonowanie
            //Console.WriteLine("-------------------CLONE------------------");
            //Team team1 = (Team)team.Clone();
            //team1.TeamName = "Clone Power Team";
            //team1.TeamLeader.Name = "Robert";
            //Console.WriteLine("-------------------TEAM------------------");
            //Console.WriteLine(team);
            //Console.WriteLine("-------------------TEAM CLONE------------------");
            //Console.WriteLine(team1);

            ////Klonowanie głębokie
            //Console.WriteLine("-------------------DEEP CLONE------------------");
            //team1 = (Team)team.DeepClone();
            //team1.TeamName = "Clone Power Team";
            //team1.TeamLeader.Name = "Tomek";
            //Console.WriteLine("-------------------TEAM------------------");
            //Console.WriteLine(team);
            //Console.WriteLine("-------------------TEAM DEEP CLONE------------------");
            //Console.WriteLine(team1);
            
            Console.ReadKey();
        }
    }
}
