using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Ephemeri
    {
        [Key]
        public long Id { get; set; }
        public DateOnly BirthDate { get; set; }
        public int SignId { get; set; }
        public int Degree { get; set; }
        public int Minutes { get; set; }
        public Sign Sign { get; set; }
    }
}
