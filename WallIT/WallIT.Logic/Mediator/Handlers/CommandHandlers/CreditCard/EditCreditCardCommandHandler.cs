using MediatR;
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
    public class EditCreditCardCommandHandler : IRequestHandler<EditCreditCardCommand, ActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        internal static ISession _session;
        public EditCreditCardCommandHandler(ISession session, IUnitOfWork unitOfWork)
        {
            _session = session;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Handle(EditCreditCardCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _unitOfWork.BeginTransaction();
            var user = _session.Load<UserEntity>(request.CreditCard.UserId);
            using (var trans = _session.BeginTransaction())
            {
                var record = new CreditCardEntity
                {
                    Name = request.CreditCard.Name,
                    User = user,
                    ModificationDateUTC = DateTime.UtcNow
                };
                _session.Update(record);
                trans.Commit();
            }

            return new ActionResult { Suceeded = true };
        }
    }
}
