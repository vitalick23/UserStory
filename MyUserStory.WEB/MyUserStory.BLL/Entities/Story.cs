using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyUserStory.BLL.Entities
{
    public class Story
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Theme { get; set; }
        public string Stories { get; set; }
        public DateTime TimePublicate { get; set; }
        public virtual User User { get; set; }

       
        }
}
