using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMaquilaApi.Models;
using Supabase;
using TMaquilaApi.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace TMaquilaApi.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        readonly Supabase.Client _clientDb;
        private readonly HttpContext _httpContext;

        public UserServiceImpl(IHttpContextAccessor httpContextAccessor, Supabase.Client clientDb) {
             _httpContextAccessor = httpContextAccessor;
             _httpContext = httpContextAccessor.HttpContext!;
             _clientDb = clientDb;
        }
        public async Task<TUser?> GetAuthenticatedUser()
        {
            var userId = JwtUtility.GetUserIdFromToken(_httpContextAccessor?.HttpContext!);
            if (!userId.IsNullOrEmpty()) {
                var guid = Guid.Parse(userId!);
                var result = await _clientDb.From<TUser>().Where(user => user.Id == guid).Get();
                return result.Models.FirstOrDefault();
            }
            
            return null;
        }
    }
}