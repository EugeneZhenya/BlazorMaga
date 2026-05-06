using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Topic
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int MenuId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }
        public List<Article> Articles { get; set; }
        public Menu Menu { get; set; }
    }
}
