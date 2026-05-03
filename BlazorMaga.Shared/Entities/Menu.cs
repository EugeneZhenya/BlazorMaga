using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Topic> Topics { get; set; }
    }
}
