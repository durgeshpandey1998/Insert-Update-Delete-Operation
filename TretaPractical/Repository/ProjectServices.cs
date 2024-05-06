using TretaPractical.Data;
using TretaPractical.Models;

namespace TretaPractical.Repository
{
    public class ProjectServices : IProject
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProjectServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }
        public Task<Project> AddProject(Project data)
        {
           _applicationDbContext.Projects.Add(data);
            _applicationDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public List<Project> GetAllProject()
        {
           var project = _applicationDbContext.Projects.ToList();
            return project;

        }

        public List<Employee> GetEmployee()
        {
            var employee = _applicationDbContext.Employees.ToList();
            return employee;
        }

        public Project ProjectAssign(int projectId, int employeeId)
        {
            ProjectAssign projectAssign = new ProjectAssign();
            var employee= _applicationDbContext.Employees.Where(x=>x.Id==employeeId).FirstOrDefault();
            var countproject = _applicationDbContext.ProjectAssigns.Where(x=>x.EmployeeIdRef==employeeId).Count();  
            if (countproject <1 && employee.EmployeeType=="Developer")
            {
               projectAssign.EmployeeIdRef= employeeId;
                projectAssign.ProjectIdRef = projectId;
                _applicationDbContext.ProjectAssigns.Add(projectAssign);
                _applicationDbContext.SaveChanges();

            }
            if (countproject < 2 && employee.EmployeeType == "TeamLeader")
            {
                projectAssign.EmployeeIdRef = employeeId;
                projectAssign.ProjectIdRef = projectId;
                _applicationDbContext.ProjectAssigns.Add(projectAssign);
                _applicationDbContext.SaveChanges();
            }
            if (countproject < 3 && employee.EmployeeType == "ProjectManager")
            {
                projectAssign.EmployeeIdRef = employeeId;
                projectAssign.ProjectIdRef = projectId;
                _applicationDbContext.ProjectAssigns.Add(projectAssign);
                _applicationDbContext.SaveChanges();
            }
            throw new NotImplementedException();
        }

        public Project ProjectDelete(Project data)
        {
            throw new NotImplementedException();
        }

        public Task<Project> ProjectEdit()
        {
            throw new NotImplementedException();
        }
    }
}
