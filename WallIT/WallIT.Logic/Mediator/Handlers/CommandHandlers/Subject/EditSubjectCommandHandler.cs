﻿using MediatR;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WallIT.DataAccess.Entities;
using WallIT.Logic.DTOs;
using WallIT.Logic.Mediator.Commands;
using WallIT.Shared.Interfaces.UnitOfWork;

namespace WallIT.Logic.Mediator.Handlers.CommandHandlers
{
    public class EditSubjectCommandHandler : IRequestHandler<EditSubjectCommand, ActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        internal static ISession _session;
        public EditSubjectCommandHandler(ISession session, IUnitOfWork unitOfWork)
        {
            _session = session;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _unitOfWork.BeginTransaction();
            var user = _session.Load<UserEntity>(request.Subject.UserId);
            using (var trans = _session.BeginTransaction())
            {
                var Subject = new SubjectEntity
                {
                    Balance = request.Subject.Balance,
                    SubjectType = request.Subject.SubjectType,
                    Currency = request.Subject.Currency,
                    Name = request.Subject.Name,
                    ModificationDateUTC = DateTime.UtcNow,
                    User = user
                };
                _session.Update(Subject);
                trans.Commit();
            }

            return new ActionResult { Suceeded = true };
        }
    }
}
