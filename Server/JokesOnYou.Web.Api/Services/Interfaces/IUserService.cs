﻿using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(String id);
        //Task<User> CreateUser(UserRegisterDTO registerDTO);
        Task<UserReplyDTO> GetUserReplyById(string id);
        Task UpdateUser(UserUpdateDTO user);
        //Task<User> Authenticate(string username, string password);
        Task<IEnumerable<UserReplyDTO>> GetAll();
    }
}
