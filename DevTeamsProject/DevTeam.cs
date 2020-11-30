using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public List<Developer> teamList = new List<Developer>();
        public string ProjectName { get; set; }
        public List<Developer> TeamMembers
        {
            get { return teamList; }
            set { teamList = value; }
        }
        public int ProjectID { get; set; }
        public DevTeam() { }

        public DevTeam(string name, int id, List<Developer> list)
        {
           ProjectName = name;
            ProjectID = id;
            TeamMembers = list;
        }
    }
}
