using parus_test_khokhlov.Repository;

namespace parus_test_khokhlov.Models
{
    public class DbHelper
    {
        private AppDbContext _context;

        public DbHelper(AppDbContext context)
        {
            _context = context;
        }

        //Поиск проекта *GET
        public List<ProjectModel> GetProjects()
        {
            List<ProjectModel> response = new List<ProjectModel>();
            var datalist = _context.Projects.ToList();
            datalist.ForEach(row => response.Add(new ProjectModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                Created_at = row.Created_at,
                Change_at = row.Change_at
            }));
            return response;
        }

        public ProjectModel GetProjectById(int id)
        {
            ProjectModel response = new ProjectModel();
            var row = _context.Projects.Where(d => d.Id.Equals(id)).FirstOrDefault();

            return new ProjectModel()
            {
                Id = row.Id,
                Name = row.Name,
                Description = row.Description,
                Created_at = row.Created_at,
                Change_at = row.Change_at
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
    }
}
