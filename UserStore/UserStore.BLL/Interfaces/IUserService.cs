﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IdentityResult> Create(User userDto, string password);
        Task<ClaimsIdentity> Authenticate(User userDto);

        Task<User> FindById(string id);
    } 
}
