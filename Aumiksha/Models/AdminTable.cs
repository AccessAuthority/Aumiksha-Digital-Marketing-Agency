using System.ComponentModel.DataAnnotations;

namespace Aumiksha.Models
{
    public class AdminTable
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
