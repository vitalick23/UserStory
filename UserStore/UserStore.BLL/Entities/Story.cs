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
        [ForeignKey("ApplicationUser")]
        public string IdUser { get; set; }
        public string Theme { get; set; }
        public string Stories { get; set; }
        public DateTime TimePublicate { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
