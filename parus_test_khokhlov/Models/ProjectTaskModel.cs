using parus_test_khokhlov.Repository;
using System.ComponentModel.DataAnnotations;

namespace parus_test_khokhlov.Models
{
    public class ProjectTaskModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? ProjectId { get; set; }
        public List<Comment>? Comments { get; set; }
        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
    }
}
