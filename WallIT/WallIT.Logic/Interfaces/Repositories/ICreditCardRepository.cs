﻿using WallIT.DataAccess.Entities;
using WallIT.Shared.DTOs;
using WallIT.Shared.Interfaces.Repositories;

namespace WallIT.Logic.Interfaces.Repositories
{
    public interface ICreditCardRepository : IRepository<CreditCardEntity, CreditCardDTO>
    {
        CreditCardDTO[] GetAllByUserId(int UserId);
    }
}
