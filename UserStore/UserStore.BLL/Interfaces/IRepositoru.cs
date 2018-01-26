using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.BLL.Interfaces
{
    public interface IRepositoru<T> where T: DbSet
    {
        DbSet<T> Database { get; }
    }
}
