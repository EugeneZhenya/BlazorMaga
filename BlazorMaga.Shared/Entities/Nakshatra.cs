using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Nakshatra
    {
        [Key]
        public int Id { get; set; }
        public int NakshatraId { get; set; }
        public int SignId { get; set; }
        public int StartDeg { get; set; }
        public int StartMin { get; set; }
        public int EndDeg { get; set; }
        public int EndMin { get; set; }
        public NakshatraName NakshatraNavigation { get; set; }
        public Sign Sign { get; set; }
    }
}
