using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers
{
    public class SubjectListQueryHandler : IRequestHandler<GetSubjectListQuery, SubjectDTO[]>
    {
        private readonly ISubjectRepository _SubjectRepository;

        public SubjectListQueryHandler(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }
        public Task<SubjectDTO[]> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Subject = _SubjectRepository.GetAll();
            return Task.FromResult(Subject);
        }
    }
}
