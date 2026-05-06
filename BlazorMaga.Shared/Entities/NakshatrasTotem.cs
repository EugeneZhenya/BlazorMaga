using System.ComponentModel.DataAnnotations;

namespace BlazorMaga.Shared.Entities
{
    public class NakshatrasTotem
    {
        [Required]
        public int NakshatraId { get; set; }
        [Required]
        public int TotemId { get; set; }
        public bool Gender { get; set; }
        public NakshatraName Nakshatra { get; set; }
        public TotemName Totem { get; set; }
    }
}