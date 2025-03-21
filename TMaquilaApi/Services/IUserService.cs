using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMaquilaApi.Models;

namespace TMaquilaApi.Services
{
    public interface IUserService
    {
        Task<TUser?> GetAuthenticatedUser();
    }
}