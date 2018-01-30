using Microsoft.AspNet.Identity.EntityFramework;

namespace MyUserStory.BLL.Entities
{
    public class User : IdentityUser
    {
        public string Hometown { get; set; }
    }
}
