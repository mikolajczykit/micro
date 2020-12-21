﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Application.Queries
{
    public interface IUserQueries
    {
        Task<List<UserViewModel>> GetUsersAsync();
    }
}
