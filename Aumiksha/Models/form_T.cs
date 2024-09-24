using System.ComponentModel.DataAnnotations;

namespace Aumiksha.Models
{
    public class form_T
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string? email { get; set; }
        public string? number { get; set; }
        public string query { get; set; }
    }
}
