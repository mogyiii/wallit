﻿using AutoMapper;
using NHibernate;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Interfaces.Managers;
using WallIT.Shared.DTOs;
using WallIT.Shared.Interfaces.UnitOfWork;
using WallIT.Shared.Transaction;

namespace WallIT.Logic.Managers
{
    public class CreditCardManager : ManagerBase<CreditCardEntity, CreditCardDTO>, ICreditCardManager
    {
        public CreditCardManager(ISession session, IMapper mapper, IUnitOfWork unitOfWork) : base(session, mapper, unitOfWork)
        { }

        protected override TransactionResult ValidateSaving(CreditCardEntity entity)
        {
            var result = new TransactionResult
            {
                Succeeded = true
            };

            if (string.IsNullOrEmpty(entity.Name))
            {
                result.Succeeded = false;
                // TODO localization
                result.ErrorMessages.Add(new TransactionErrorMessage
                {
                    IsPublic = true,
                    Message = "Name is required!"
                });
            }

            return result;
        }
    }
}
