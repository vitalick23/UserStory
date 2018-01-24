using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.BLL.Entities
{
    public class Story
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Theme { get; set; }
        public string Stories { get; set; }
        public DateTime TimePublicate { get; set; }
        public virtual User User { get; set; }
    }
}
