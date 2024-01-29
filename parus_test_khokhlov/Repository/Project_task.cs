using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parus_test_khokhlov.Repository
{
    [Table("Tasks")]
    public class Project_task
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название задачи")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание задачи")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Комментарии")]
        public List<Comment>? Comments { get; set; }

        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");

        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");


    }
}
