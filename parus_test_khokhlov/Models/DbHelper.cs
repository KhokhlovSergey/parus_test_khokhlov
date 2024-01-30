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
            var row = _context.Projects.Where(d => d.Id.Equals(id))
                .Include(d => d.Users)
                .Include(d => d.Project_tasks)
                    .ThenInclude(p => p.Comments).FirstOrDefault();
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

        //Добавляем нового пользователя в проект
        public void ProjectAddUser(int projectId, int userId)
        {
            User dbTable = new User();
            dbTable = _context.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
            if(dbTable != null)
            {
                dbTable.ProjectId = projectId;
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.SaveChanges();
            }

        }

        //Удаляем пользователя с проекта
        public void ProjectDelUser(int projectId, int userId)
        {
            User dbTable = new User();
            dbTable = _context.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
            if (dbTable != null)
            {
                dbTable.ProjectId = null;
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.SaveChanges();
            }

        }

        public void ProjectAddTask(int projectId, int taskId)
        {
            ProjectTask dbTable = new ProjectTask();
            dbTable = _context.Tasks.Where(t => t.Id.Equals(taskId)).FirstOrDefault();
            if (dbTable != null)
            {
                dbTable.ProjectId = projectId;
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.SaveChanges();
            }

        }

        //Удаляем задачу с проекта
        public void ProjectDelTask(int projectId, int taskId)
        {
            ProjectTask dbTable = new ProjectTask();
            dbTable = _context.Tasks.Where(t => t.Id.Equals(taskId)).FirstOrDefault();
            if (dbTable != null)
            {
                dbTable.ProjectId = null;
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.SaveChanges();
            }

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

        public UserModel GetUserById(int id)
        {
            var row = _context.Users.Where(d => d.Id.Equals(id)).FirstOrDefault();
            return new UserModel()
            {
                Id = row.Id,
                Login = row.Login,
                Name = row.Name,
                Lastname = row.Lastname,
                Email = row.Email,
                ProjectId = row.ProjectId,
                Created_at = row.Created_at,
                Change_at = row.Change_at
            };

        }
        
        //Создание пользователя или обновление пользователя
        public void SaveUser(UserModel userModel)
        {
            User dbTable = new User();
            if (userModel.Id > 0)
            {
                //Редактирование проекта *UPDATE
                dbTable = _context.Users.Where(u => u.Id.Equals(userModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Login = userModel.Login;
                    dbTable.Email = userModel.Email;
                    dbTable.ProjectId = userModel.ProjectId;
                    dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            // Заводим нового пользователя
            else
            {
                dbTable.Login = userModel.Login;
                dbTable.Name = userModel.Name;
                dbTable.Lastname = userModel.Lastname;
                dbTable.Email = userModel.Email;
                dbTable.ProjectId = null;
                dbTable.Created_at = DateTime.Now.ToString("dd-MM-yyyy");
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Users.Add(dbTable);
            }

            _context.SaveChanges();
        }

        //Удаление пользователя *DELETE
        public void DeleteUser(int id)
        {
            var order = _context.Users.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Users.Remove(order);
                _context.SaveChanges();
            }
        }

        //Заводим новую таску или изменяем старую
        public void SaveTask(ProjectTaskModel taskModel)
        {
            ProjectTask dbTable = new ProjectTask();
            if (taskModel.Id > 0)
            {
                //Редактирование задачи *UPDATE
                dbTable = _context.Tasks.Where(t => t.Id.Equals(taskModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Name = taskModel.Name;
                    dbTable.Description = taskModel.Description;
                    dbTable.Status = taskModel.Status;
                    dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            // Это заводим новую задачу *POST
            else
            {
                dbTable.Name = taskModel.Name;
                dbTable.Description = taskModel.Description;
                dbTable.Status = taskModel.Status;
                dbTable.ProjectId = taskModel.ProjectId;
                dbTable.Created_at = DateTime.Now.ToString("dd-MM-yyyy");
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Tasks.Add(dbTable);
            }

            _context.SaveChanges();
        }

        public List<ProjectTaskModel> GetTaskByProject(int projectId)
        {

            List<ProjectTaskModel> response = new List<ProjectTaskModel>();
            var taskstlist = _context.Tasks.Where(t => t.ProjectId.Equals(projectId)).Include(c => c.Comments).ToList();
            taskstlist.ForEach(row => response.Add(new ProjectTaskModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                Status = row.Status,
                ProjectId = row.ProjectId,
                Comments = row.Comments,
                Created_at = row.Created_at,
                Change_at = row.Change_at

            }));
            return response;
        }

        public ProjectTaskModel GetTaskById(int id)
        {
            var row = _context.Tasks.Where(t => t.Id.Equals(id)).FirstOrDefault();
            return new ProjectTaskModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description= row.Description,
                Status = row.Status,
                ProjectId = row.ProjectId,
                Comments = row.Comments,
                Created_at = row.Created_at,
                Change_at = row.Change_at
            };

        }

        public List<ProjectTaskModel> GetTaskByStatus(string  status)
        {

            List<ProjectTaskModel> response = new List<ProjectTaskModel>();
            var taskstlist = _context.Tasks.Where(t => t.Status.Equals(status)).Include(c => c.Comments).ToList();
            //var projectList= _context.Projects.Include(t => t.Project_tasks).Where()
            taskstlist.ForEach(row => response.Add(new ProjectTaskModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                Status = row.Status,
                ProjectId = row.ProjectId,
                Comments = row.Comments,
                Created_at = row.Created_at,
                Change_at = row.Change_at

            }));
            return response;
        }

        //Удаление задачи
        public void DeleteTask(int id)
        {
            var order = _context.Tasks.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Tasks.Remove(order);
                _context.SaveChanges();
            }
        }

        public void SaveComment(CommentModel commentModel)
        {
            Comment dbTable = new Comment();
            if (commentModel.Id > 0)
            {
                //Редактирование комментария *UPDATE
                dbTable = _context.Comments.Where(t => t.Id.Equals(commentModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Text = commentModel.Text;
                    dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            // Это заводим новый проект *POST
            else
            {
                dbTable.Text = commentModel.Text;
                dbTable.Project_taskId = commentModel.Project_taskId;
                dbTable.Created_at = DateTime.Now.ToString("dd-MM-yyyy");
                dbTable.Change_at = DateTime.Now.ToString("dd-MM-yyyy");
                _context.Comments.Add(dbTable);
            }

            _context.SaveChanges();
        }

        //Получение списка комментариев к задаче
        public List<CommentModel> GetCommentsByTask(int taskId)
        {

            List<CommentModel> response = new List<CommentModel>();
            var taskstlist = _context.Comments.Where(t => t.Project_taskId.Equals(taskId)).ToList();
            //var projectList= _context.Projects.Include(t => t.Project_tasks).Where()
            taskstlist.ForEach(row => response.Add(new CommentModel()
            {
                Id = row.Id,
                Text = row.Text,
                Project_taskId = row.Project_taskId,
                Created_at = row.Created_at,
                Change_at = row.Change_at

            }));
            return response;
        }

        //Удаление коммента *DELETE
        public void DeleteComment(int id)
        {
            var order = _context.Comments.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Comments.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
