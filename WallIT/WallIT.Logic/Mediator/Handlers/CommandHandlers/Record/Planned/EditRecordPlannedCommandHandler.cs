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
    public class EditRecordPlannedCommandHandler : IRequestHandler<EditRecordPlannedCommand, ActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        internal static ISession _session;
        public EditRecordPlannedCommandHandler(ISession session, IUnitOfWork unitOfWork)
        {
            _session = session;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Handle(EditRecordPlannedCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _unitOfWork.BeginTransaction();
            var category = _session.Load<RecordCategoryEntity>(request.RecordPlanned.RecordCategoryId);
            using (var trans = _session.BeginTransaction())
            {
                var record = new RecordPlannedEntity
                {
                    RecordCategory = category,
                    Amount = request.RecordPlanned.Amount,
                    Name = request.RecordPlanned.Name,
                    ModificationDateUTC = DateTime.UtcNow
                };
                _session.Update(record);
                trans.Commit();
            }

            return new ActionResult { Suceeded = true };
        }
    }
}
