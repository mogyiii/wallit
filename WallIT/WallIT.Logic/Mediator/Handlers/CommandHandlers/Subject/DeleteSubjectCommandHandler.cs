using MediatR;
using NHibernate;
using WallIT.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.DTOs;
using WallIT.Logic.Mediator.Commands;
using WallIT.Shared.Interfaces.UnitOfWork;

namespace WallIT.Logic.Mediator.Handlers.CommandHandlers
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, ActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        internal static ISession _session;
        public DeleteSubjectCommandHandler(ISession session, IUnitOfWork unitOfWork)
        {
            _session = session;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _unitOfWork.BeginTransaction();
            var Subject = _session.Load<SubjectEntity>(request.Id);
            using (var trans = _session.BeginTransaction())
            {
                _session.Delete(Subject);
                trans.Commit();
            }
            return new ActionResult { Suceeded = true };
        }
    }
}
