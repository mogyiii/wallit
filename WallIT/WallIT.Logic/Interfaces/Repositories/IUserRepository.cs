﻿using WallIT.DataAccess.Entities;
using WallIT.Shared.DTOs;
using WallIT.Shared.Interfaces.Repositories;

namespace WallIT.Logic.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity, UserDTO>
    {
        UserDTO FindByUserName(string normalizedUserName);

        UserDTO[] GetByClaim(string claimType, string claimValue);
    }
}
