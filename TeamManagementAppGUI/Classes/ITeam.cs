using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementAppGUI
{
    public interface ITeam
    {
        void AddMember(TeamMember t);
        void RemoveMember(TeamMember t);
        void DeleteAll(Team t);
        void Sort();
        List<TeamMember> FindInactiveMembers();
        List<TeamMember> FindMembers(string function);
        List<TeamMember> FindMembers(int month);
    }
}
