﻿using System.Data.Entity;
using System.Security.Claims;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserRepositoru : IRepositoru
    {
        void Create(User user, string password);

    }
}
