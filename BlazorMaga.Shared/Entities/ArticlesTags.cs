using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaga.Shared.Entities
{
    public class ArticlesTags
    {
        public long ArticleId { get; set; }
        public long TagId { get; set; }
        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}
