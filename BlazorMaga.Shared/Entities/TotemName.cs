using System.ComponentModel.DataAnnotations;

namespace BlazorMaga.Shared.Entities
{
    public class TotemName
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<NakshatrasTotem> NakshatrasTotems { get; set; } = new List<NakshatrasTotem>();
    }
}