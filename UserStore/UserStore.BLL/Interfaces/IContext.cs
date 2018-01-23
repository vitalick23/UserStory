using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IContext
    {
        IDbSet<ApplicationUser> Users { get; set; }
    }
}
