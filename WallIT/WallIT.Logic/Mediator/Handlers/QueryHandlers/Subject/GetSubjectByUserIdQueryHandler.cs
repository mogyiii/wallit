using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.DTOs;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers.Subject
{
    public class GetSubjectByUserIdQueryHandler : IRequestHandler<GetSubjectByUserIdQuery, SubjectDTO>
    {
        private readonly ISubjectRepository _SubjectRepository;
        public GetSubjectByUserIdQueryHandler(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }

        public Task<SubjectDTO> Handle(GetSubjectByUserIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Subject = _SubjectRepository.Get(request.UserId);

            return Task.FromResult(Subject);
        }
    }
}
