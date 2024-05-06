using TretaPractical.Models;

namespace TretaPractical.Repository
{
    public interface IProject
    {
        Task<Project> AddProject(Project data);
        Task<Project> ProjectEdit();
        Project ProjectDelete(Project data);
        Project ProjectAssign(int projectId, int employeeId);
        List<Project> GetAllProject();
        List<Employee> GetEmployee();
    }
}
