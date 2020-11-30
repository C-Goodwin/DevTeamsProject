using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class GetRepo
    {
        DeveloperRepo _developerRepo = new DeveloperRepo();
    }
    public class DevTeamRepo
    { 
        public List<DevTeam> _devTeamRepo = new List<DevTeam>();

        //DevTeam Create
        public void AddTeamToList(DevTeam info)
        {
            _devTeamRepo.Add(info);
        }
        //DevTeam Read
        public List<DevTeam> GetTeamList()
        {
            return _devTeamRepo;
        }
        //DevTeam Update
        public bool UpdateDevTeams(int projectID, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamByProjectID(projectID);
            if(oldTeam != null)
            {
                oldTeam.ProjectName = newTeam.ProjectName;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }
        //DevTeam Delete
        public bool RemoveTeamFromList(int projectID)
        {
            DevTeam team = GetTeamByProjectID(projectID);
            if (team == null)
            {
                return false;
            }
            int initialCount = _devTeamRepo.Count;
            _devTeamRepo.Remove(team);
            if (initialCount > _devTeamRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamByProjectID(int projectID)
        {
            foreach(DevTeam team in _devTeamRepo)
            {
                if(team.ProjectID == projectID)
                {
                    return team;
                }
            }
            return null;
        }

    }
}

    