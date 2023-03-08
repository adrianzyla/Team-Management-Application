using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementAppGUI
{
    public class PESELComparator : IComparer<TeamMember>
    {
        public int Compare(TeamMember x, TeamMember y)
        {
            return string.Compare(x.Pesel, y.Pesel);
        }
    }
}
