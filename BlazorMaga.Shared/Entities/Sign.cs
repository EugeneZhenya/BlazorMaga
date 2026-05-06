using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Sign
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameLat { get; set; }
        [Required]
        public string NameUkr { get; set; }
        public List<Ephemeri> Ephemeris { get; set; } = new List<Ephemeri>();
        public List<Nakshatra> Nakshatras { get; set; } = new List<Nakshatra>();
    }
}
