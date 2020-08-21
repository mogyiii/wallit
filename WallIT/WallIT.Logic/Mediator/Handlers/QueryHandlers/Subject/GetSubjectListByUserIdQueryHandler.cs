using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers
{
    public class GetSubjectListByUserIdQueryHandler : IRequestHandler<GetSubjectListByUserIdQuery, SubjectDTO[]>
    {
        private readonly ISubjectRepository _SubjectRepository;

        public GetSubjectListByUserIdQueryHandler(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }
        public Task<SubjectDTO[]> Handle(GetSubjectListByUserIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Subject = _SubjectRepository.GetAllByUserId(request.UserId);
            return Task.FromResult(Subject);
        }
    }
}
