using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please rnter name.")]
        public string Name { get; set; }
    }
}
