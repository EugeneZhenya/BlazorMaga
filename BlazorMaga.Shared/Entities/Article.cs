using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class Article
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public Topic Topic { get; set; }
        public List<ArticlesTags> ArticlesTags { get; set; } = new List<ArticlesTags>();

        [NotMapped]
        public bool isFirst { get; set; } = false;
    }
}
