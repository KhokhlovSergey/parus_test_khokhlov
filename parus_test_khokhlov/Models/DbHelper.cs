using Microsoft.EntityFrameworkCore;
using parus_test_khokhlov.Repository;
using System.Threading.Tasks;

namespace parus_test_khokhlov.Models
{
    public class DbHelper
    {
        private AppDbContext _context;

        public DbHelper(AppDbContext context)
        {
            _context = context;
        }

        //Получение списка проектов без вложенных сущностей *GET
        public List<ProjectModel> GetProjects()
        {
            List<ProjectModel> response = new List<ProjectModel>();
            var projectlist = _context.Projects.ToList();
            projectlist.ForEach(row => response.Add(new ProjectModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                Created_at = row.Created_at,
                Change_at = row.Change_at
            }));
            return response;
        }

        //Получение конкретного проекта с иерархией вложенных сущностей *Get
        public ProjectModel GetProjectById(int id)
        {
            ProjectModel response = new ProjectModel();
            //var row = _context.Projects.Where(d => d.Id.Equals(id)).FirstOrDefault();
            //var usersList = _context.Users.Include(u => u.Project).Where(u => u.ProjectId.Equals(id)).ToList();
            //var tasksList = _context.Tasks.Include(t => t.Project).Where(t => t.ProjectId.Equals(id)).ToList();
            var row = _context.Projects.Where(d => d.Id.Equals(id))
                .Include(d => d.Users)
                .Include(d => d.Project_tasks)
                    .ThenInclude(p => p.Comments).FirstOrDefault();
            //_context.Users.Where(p => p.ProjectId == row.Id).Load();
            //_context.Tasks.Where(p => p.ProjectId == row.Id).Load();
            return new ProjectModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                Created_at = row.Created_at,
                Change_at = row.Change_at,
                Project_tasks = row.Project_tasks,
                Users = row.Users
            };
           
        }        

        //Записть и апдейт проекта 
        public void SaveProgect(ProjectModel projectModel)
        {
            Project dbTable = new Project();
            if(projectModel.Id > 0 )
            {
                //Редактирование проекта *UPDATE
                dbTable = _context.Projects.Where(d => d.Id.Equals(projectModel.Id)).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.Name = projectModel.Name;
                    dbTable.Description = projectModel.Description;
                    projectModel.Created_at = dbTable.Created_at;
                    dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            // Это заводим новый проект *POST
            else
            {
                dbTable.Name = projectModel.Name;
                dbTable.Description = projectModel.Description;
                dbTable.Created_at = DateTime.Now.ToString("dd-MM-yyyy");
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Projects.Add(dbTable);
            }

            _context.SaveChanges();
        }

        //Удаление проекта *DELETE
        public void DeleteProject(int id)
        {
            var order = _context.Projects.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Projects.Remove(order);
                _context.SaveChanges();
            }
        }



        public List<UserModel> GetUsersByProject(int projectId)
        {
            List<UserModel> response = new List<UserModel>();
            var userstlist = _context.Users.Where(u => u.ProjectId.Equals(projectId)).ToList();
            userstlist.ForEach(row => response.Add(new UserModel()
            {
                Id = row.Id,
                Login = row.Login,
                Name = row.Name,
                Lastname = row.Lastname,
                Email = row.Email,
                ProjectId = row.ProjectId,
                Created_at = row.Created_at,
                Change_at = row.Change_at

            }));
            return response;
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> response = new List<UserModel>();
            var usersList = _context.Users.ToList();
            usersList.ForEach(row => response.Add(new UserModel()
            {
                Id = row.Id,
                Login = row.Login,
                Name = row.Name,
                Lastname = row.Lastname,
                Email = row.Email,
                ProjectId = row.ProjectId,
                Created_at = row.Created_at,
                Change_at = row.Change_at
            }));
            return response;
        }



    }
}
