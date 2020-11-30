using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerRepo = new List<Developer>();

        //Developer Create
        public void AddNewDeveloper(Developer information)
        {
            _developerRepo.Add(information);
        }
        //Developer Read
        public List<Developer> GetDevelopers()
        {
            return _developerRepo;
        }
        //Developer Update
        public bool UpdateExistingDev(int devID, Developer newDev)
        {
            Developer oldDev = GetDeveloperByID(devID);
            if(oldDev != null)
            {
                oldDev.Name = newDev.Name;
                oldDev.PluralsightAccess = newDev.PluralsightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete
        public bool RemoveDeveloper(int devID)
        {
            Developer dev = GetDeveloperByID(devID);
            if(dev == null)
            {
                return false;
            }
            int initialCount = _developerRepo.Count;
            _developerRepo.Remove(dev);
            if(initialCount > _developerRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByID(int devID)
        {
            foreach(Developer dev in _developerRepo)
            {
                if(dev.EmployeeID == devID)
                {
                    return dev;
                }
            }
            return null;
        }
        public Developer GetDeveloperByName(string name)
        {
            foreach (Developer dev in _developerRepo)
            {
                if (dev.Name.ToLower() == name.ToLower())
                {
                    return dev;
                }
            }
            return null;
        }
        public List<Developer> GetDevelopersWithAccess(bool access)
        {
            List<Developer> devsWithAccess = new List<Developer>(); 
            foreach (Developer dev in _developerRepo)
            {
                if (dev.PluralsightAccess == access)
                {
                    devsWithAccess.Add(dev);
                }
            }
            return devsWithAccess;
        }
        
    }
}      