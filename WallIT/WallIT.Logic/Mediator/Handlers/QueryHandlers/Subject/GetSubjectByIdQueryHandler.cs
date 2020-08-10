using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectDTO>
    {
        private readonly ISubjectRepository _SubjectRepository;

        public GetSubjectByIdQueryHandler(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }

        public Task<SubjectDTO> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Subject = _SubjectRepository.Get(request.Id);

            return Task.FromResult(Subject);
        }
    }
}
