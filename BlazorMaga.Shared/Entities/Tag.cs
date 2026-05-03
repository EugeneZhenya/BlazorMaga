using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Tag
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Mark { get; set; }
        public List<ArticlesTags> ArticlesTags { get; set; } = new List<ArticlesTags>();
    }
}
