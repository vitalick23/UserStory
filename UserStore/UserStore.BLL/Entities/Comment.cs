using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.BLL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Story")]
        public int StoriesId { get; set; }

        public string Text { get; set; }

        public DateTime TimePublicate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Story Story { get; set; }
    }
}
