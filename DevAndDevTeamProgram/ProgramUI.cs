using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAndDevTeamProgram
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedDeveloperList();
            SeedDeveloperTeamList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while(keepRunning)

            { 
                Console.WriteLine("Hello Komodo Insurance Associate.\n" +
                "Please input the number of your choice followed by ENTER.\n"
                + "1. Developers\n" +
                "2. Developer Teams\n" +
                "3. Exit Application");
                string firstAnswer = Console.ReadLine();
                if (firstAnswer == "1")
                {
                    DeveloperMenu();
                }
                else if (firstAnswer == "2")
                { 
                    DeveloperTeamMenu();
                }
                else if (firstAnswer == "3")
                {
                    Console.WriteLine("So Long");
                    keepRunning = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.");
                    Menu();
                }
             }
        }
        
        private void DeveloperMenu()
        {
            Console.Clear();
            Console.WriteLine("The following options are available:\n" +
                "Please input the number of your choice followed by ENTER.\n" +
                "1. Create a new developer\n" +
                "2. Display the current list of developers\n" +
                "3. Find a specific developer by ID\n" +
                "4. Find a specific developer by name\n" +
                "5. View a list of developers that do not have access to Pluralsight\n" +
                "6. Update an existing developer's information\n" +
                "7. Remove an existing developer\n" +
                "8. Return to the previous menu ");
            string devMenuAnswer = Console.ReadLine();
            int devMenuAnswerAsInt = int.Parse(devMenuAnswer);
            switch (devMenuAnswerAsInt)
            {
                case 1:
                    CreateNewDeveloper();
                    break;
                case 2:
                    Console.Clear();
                    DisplayAllDevelopers();
                    break;
                case 3:
                    FindDevByID();
                    break;
                case 4:
                    FindDevByName();
                    break;
                case 5:
                    ListPluralSight();
                    break;
                case 6:
                    UpdateDeveloper();
                    break;
                case 7:
                    RemoveDeveloper();
                    break;
                case 8:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not a valid number press ENTER to return to the Developer menu.");
                    Console.ReadKey();
                    Console.Clear();
                    DeveloperMenu();
                    break;
            }
            DeveloperMenu();

        }
        private void DeveloperTeamMenu()
        {
            Console.Clear();
            Console.WriteLine("The following options are available:\n" +
               "Please input the number of your choice followed by ENTER.\n" +
               "1. Create a new Developer Team\n" +
               "2. Display a list of the current Developer Teams\n" +
               "3. Find a Developer Team by Project ID\n" +
               "4. Update the information of an existing Developer Team\n" +
               "5. Remove an existing Developer Team \n" +
               "6. Return to the previous menu");
            string devTeamMenuAnswer = Console.ReadLine();
            int devTeamMenuAnswerAsInt = int.Parse(devTeamMenuAnswer);
            switch (devTeamMenuAnswerAsInt)
            {
                case 1:
                    CreateDeveloperTeam();
                    break;
                case 2:
                    DisplayAllTeams();
                    break;
                case 3:
                    DisplayTeamByID();
                    break;
                case 4:
                    UpdateExistingTeam();
                    break;
                case 5:
                    RemoveDevTeam();
                    break;
                case 6:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not a valid number press ENTER to return to the Developer Team menu.");
                    Console.ReadKey();
                    Console.Clear();
                    DeveloperTeamMenu();
                    break;
            }
            DeveloperTeamMenu();
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();
            Console.WriteLine("Input the developer's name:");
            newDev.Name = Console.ReadLine();
            Console.WriteLine("The application has generated this unique 8-digit ID number for your Developer:");
            string devID = IDGenerator();
            newDev.EmployeeID = int.Parse(devID);
            Console.WriteLine(devID);
            Console.WriteLine("Does this Developer have access to PluralSight? (yes/no)");
            string psAccess = Console.ReadLine().ToLower();
            if (psAccess == "yes")
            {
                newDev.PluralsightAccess = true;
            }
            else if (psAccess == "y")
            {
                newDev.PluralsightAccess = true;
            }
            else
            {
                newDev.PluralsightAccess = false;
            }
            _developerRepo.AddNewDeveloper(newDev);
        }
        public static string IDGenerator()
        {
            List<string> employeeID = new List<string>();
            Random random = new Random();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                output.Append(random.Next(0, 10));
            }

            employeeID.Add(output.ToString());
            if (employeeID.Distinct().Count() == employeeID.Count())
            {
                return output.ToString();
            }
            else
            {
                return null;
            }
        }
        private void DisplayAllDevelopers()
        {

            List<Developer> listOfDevs = _developerRepo.GetDevelopers();
            foreach (Developer developer in listOfDevs)
            {
                Console.WriteLine($"\n Developer's Name: {developer.Name}\n Employee ID: {developer.EmployeeID}\n");
            }
            Console.ReadKey();
        }
        private void FindDevByID()
        {
            Console.Clear();
            Console.WriteLine("Please input the Developer's ID:");
            string id = Console.ReadLine();
            Developer dev = _developerRepo.GetDeveloperByID(int.Parse(id));
            if (dev != null)
            {
                Console.WriteLine($"Developer's Name:{dev.Name}\n" +
                    $"Emplyee ID: {dev.EmployeeID}\n" +
                    $"Plural Access: {dev.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("There is no Developer with that ID.");
            }
            Console.ReadKey();
        }
        private void FindDevByName()
        {
            Console.Clear();
            Console.WriteLine("Please input the Developer's name:\n" +
                "First and Last seperated with one space");
            string name = Console.ReadLine();
            Developer dev = _developerRepo.GetDeveloperByName(name);
            if (dev != null)
            {
                Console.WriteLine($"Developer's Name:{dev.Name}\n" +
                    $"Emplyee ID: {dev.EmployeeID}\n" +
                    $"Plural Access: {dev.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("There is no Developer with that name.");
            }
            Console.ReadKey();
        }
        private void ListPluralSight()
        {
            Console.Clear();
            Console.WriteLine("Hit ENTER to view a list of Developer's that need PluralSight Access");
            Console.ReadKey();
            List<Developer> psAccess = _developerRepo.GetDevelopersWithAccess(false);
            foreach (Developer developer in psAccess)
            {
                Console.WriteLine($"\nDeveloper's Name: {developer.Name}\n Employee ID: {developer.EmployeeID}\n");
            }
            Console.ReadKey();
        }
        private void UpdateDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("Please enter the ID of the Developer you would like to edit.");
            int employeeID = int.Parse(Console.ReadLine());
            Developer newDev = new Developer();
            newDev.EmployeeID = employeeID;
            Console.WriteLine("Input the Developer's name:");
            newDev.Name = Console.ReadLine();
            Console.WriteLine("Does this Developer have access to PluralSight? (yes/no)");
            string psAccess = Console.ReadLine().ToLower();
            if (psAccess == "yes")
            {
                newDev.PluralsightAccess = true;
            }
            else if (psAccess == "y")
            {
                newDev.PluralsightAccess = true;
            }
            else
            {
                newDev.PluralsightAccess = false;
            }
            bool wasUpdated = _developerRepo.UpdateExistingDev(employeeID, newDev);
            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated.");
            }
            else
            {
                Console.WriteLine("Sorry. We could not update that Developer.");
            }
        }
        private void RemoveDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Input the Employee ID of the Developer you would like to remove.");
            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _developerRepo.RemoveDeveloper(input);
            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully removed.");
            }
            else
            {
                Console.WriteLine("The Developer could not be removed.");
            }
        }
        private void CreateDeveloperTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();
            Console.WriteLine("Input a name for the project this team will be working on:");
            newTeam.ProjectName = Console.ReadLine();
            Console.WriteLine("Please enter a project reference ID:");
            newTeam.ProjectID = int.Parse(Console.ReadLine());
            Console.WriteLine("Add Developers to this team using their employee IDs:\n" +
                "(Seperate each developer with a ',' \n" +
                "List of current Developers:");
            DisplayAllDevelopers();
            List<Developer> teamList = new List<Developer>();
            var line = Console.ReadLine();
            string[] devList = line.Split(',');
            foreach (var sub in devList)
            {
                Developer dev = _developerRepo.GetDeveloperByID(int.Parse(sub));
                teamList.Add(dev);
            } 
            newTeam.TeamMembers = teamList;
        }
        public void DisplayAllTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetTeamList();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"\n Project Name: {devTeam.ProjectName} \n Project ID: {devTeam.ProjectID}\n");
            }
        }
        public void DisplayTeamByID()
        {
            Console.Clear();
            Console.WriteLine("Input the project ID to view the Developer Team");
            int id = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetTeamByProjectID(id);
            if (devTeam != null)
            {
                Console.WriteLine($"Project Name: {devTeam.ProjectName}\n" +
                    $"Project ID: {devTeam.ProjectID}\n" +
                    $"Team Members: {devTeam.TeamMembers}");
            }
            else
            {
                Console.WriteLine("No Developer Team with that Project ID");
            }
        }
        public void UpdateExistingTeam()
        {
            DisplayAllTeams();
            Console.WriteLine("Please enter the Project ID of the team you would like to view.");
            int id = int.Parse(Console.ReadLine());
            DevTeam newTeam = new DevTeam();
            Console.WriteLine("Input a name for the project this team will be working on:");
            newTeam.ProjectName = Console.ReadLine();
            Console.WriteLine("Please enter a project reference ID:");
            newTeam.ProjectID = int.Parse(Console.ReadLine());
            Console.WriteLine("Add Developers to this team using their employee IDs:\n" +
                "(Seperate each developer with a ',' \n" +
                "List of current Developers:");
            DisplayAllDevelopers();
            List<Developer> teamList = new List<Developer>();
            var line = Console.ReadLine();
            string[] devList = line.Split(',');
            foreach (var sub in devList)
            {
                Developer dev = _developerRepo.GetDeveloperByID(int.Parse(sub));
                teamList.Add(dev);
            }
            newTeam.TeamMembers = teamList;
            bool wasUpdated = _devTeamRepo.UpdateDevTeams(id , newTeam);
            if (wasUpdated)
            {
                Console.WriteLine("Successfully updated Developer Team data");
            }
            else
            {
                Console.WriteLine("Could not update the Developer Team data.");
            }
        }
        private void RemoveDevTeam()
        {
            Console.Clear();
            DisplayAllTeams();
            Console.WriteLine("\n Enter the Project ID of the team you would like to remove:");
            int id = int.Parse(Console.ReadLine());
            bool wasDeleted = _devTeamRepo.RemoveTeamFromList(id);
            if(wasDeleted)
            {
                Console.WriteLine("The Team was removed.");
            }
            else
            {
                Console.WriteLine("The Team was not removed.");
            }

        }
        private void SeedDeveloperList()
        {
            Developer eraserhead = new Developer("Aizawa Shouta", 01694253, true);
            Developer presentMic = new Developer("Yamada Hizashi", 01694352, true);
            Developer midnight = new Developer("Kayama Nemuri", 01694411, false);
            Developer cementoss = new Developer("Ishiyama Ken", 01694798, false);
            Developer allMight = new Developer("Yagi Toshinori", 01694852, true);
            Developer snipe = new Developer("Nara Touru", 01694761, false);
            Developer ectoplasm = new Developer("Nishida Masakazu", 016942379, true);
            Developer powerLoader = new Developer("Maijima Higari", 01694739, false);
            Developer vladKing = new Developer("Kan Sekijiro", 01694179, true);
            Developer houndDog = new Developer("Inui Ryo", 01694689, false);
            Developer recoveryGirl = new Developer("Shuzenji Chiyo", 01694369, true);
            Developer nezu = new Developer("Nezu", 01691111, true);
            Developer thirteen = new Developer("Thirteen", 01691313, true);
            _developerRepo.AddNewDeveloper(eraserhead);
            _developerRepo.AddNewDeveloper(presentMic);
            _developerRepo.AddNewDeveloper(midnight);
            _developerRepo.AddNewDeveloper(cementoss);
            _developerRepo.AddNewDeveloper(allMight);
            _developerRepo.AddNewDeveloper(snipe);
            _developerRepo.AddNewDeveloper(ectoplasm);
            _developerRepo.AddNewDeveloper(powerLoader);
            _developerRepo.AddNewDeveloper(vladKing);
            _developerRepo.AddNewDeveloper(houndDog);
            _developerRepo.AddNewDeveloper(recoveryGirl);
            _developerRepo.AddNewDeveloper(nezu);
            _developerRepo.AddNewDeveloper(thirteen);
        }
        private void SeedDeveloperTeamList()
        {
            List<Developer> developers = new List<Developer>();
            developers.Add(new Developer("Shuzenji Chiyo", 01694369, true));
            developers.Add(new Developer("Aizawa Shouta" , 01694253, true));
            developers.Add(new Developer("Yamada Hizashi" , 01694352, true)); 
            DevTeam uaStaff = new DevTeam("Plus Ultra", 012798, developers);
            DevTeam testTeam = new DevTeam("Why Me", 357, developers);
            _devTeamRepo.AddTeamToList(uaStaff);
            _devTeamRepo.AddTeamToList(testTeam);
        }
    } 
}
