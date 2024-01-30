using System.ComponentModel.DataAnnotations;

namespace parus_test_khokhlov.Models
{
    public class CommentModel
    {
        [Key, Required]
        public int Id { get; set; }        
        public string Text { get; set; }
        public int? Project_taskId { get; set; }
        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
    }
}
