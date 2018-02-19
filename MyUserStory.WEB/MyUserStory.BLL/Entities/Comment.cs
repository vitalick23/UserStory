using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyUserStory.BLL.Entities
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Story")]
        public string StoriesId { get; set; }

        public string Text { get; set; }

        public DateTime TimePublicate { get; set; }

        public virtual User User { get; set; }

        public virtual Story Story { get; set; }
    }
}
