﻿using AutoMapper;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using WallIT.Shared.Interfaces.DomainModel.DTO;
using WallIT.Shared.Interfaces.DomainModel.Entity;
using WallIT.Shared.Interfaces.Managers;
using WallIT.Shared.Transaction;

namespace WallIT.Logic.Managers
{
    public abstract class ManagerBase<TEntity, TDTO> : IManagerBase<TEntity, TDTO>
        where TEntity : IEntity
        where TDTO : IDTO
    {
        protected readonly ISession _session;
        protected readonly IMapper _mapper;

        public ManagerBase(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        #region Interface implementation

        public TransactionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TransactionResult Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public TransactionResult Save(TDTO dto)
        {
            var isNew = dto.Id == 0;

            var entity = _mapper.Map(dto, isNew
                ? (TEntity)Activator.CreateInstance(typeof(TEntity))
                : _session.Get<TEntity>(dto.Id));

            var result = ValidateSaving(entity);

            if (result.IsSuccess)
            {
                try
                {
                    if (isNew)
                        _session.Save(entity);

                    result.Id = entity.Id;
                }
                catch (Exception ex)
                {
                    // TODO logging
                    result.ErrorMessages.Add(new TransactionErrorMessage
                    {
                        IsPublic = false,
                        Message = ex.Message
                    });
                    result.IsSuccess = false;
                }
            }

            HandleTransactionErrors(result);

            return result;
        }

        #endregion Interface implementation

        #region Virtual methods

        protected virtual TransactionResult ValidateSaving(TEntity entity)
        {
            return new TransactionResult();
        }

        protected virtual void OnSaving(TEntity entity)
        { }

        protected virtual void AfterSaving(TEntity entity)
        { }

        protected virtual void OnDeleting(TEntity entity)
        { }

        protected virtual void AfterDeleting(TEntity entity)
        { }

        #endregion Virtual methods

        #region Private methods

        private void HandleTransactionErrors(TransactionResult result)
        {
            // TODO handle non-public errors
            var errorsToRemove = result.ErrorMessages.Where(x => !x.IsPublic).ToList();

            foreach (var error in errorsToRemove)
                result.ErrorMessages.Remove(error);
        }

        #endregion Private methods
    }
}
