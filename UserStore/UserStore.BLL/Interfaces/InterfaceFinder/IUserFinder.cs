using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces.InterfaceFinder
{
    public interface IUserFinder : IFinder
    {
        User FindById(string id);

        User FindByEmail(string email);

        User Find(string email,string password);

    }
}
