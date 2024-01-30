using parus_test_khokhlov.Repository;
using System.ComponentModel.DataAnnotations;

namespace parus_test_khokhlov.Models
{
    public class UserModel
    {        
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }        
        public string Lastname { get; set; }        
        public string Email { get; set; }
        public int? ProjectId { get; set; }
        public string Created_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public string Change_at { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
    }
}
