using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers
{
    public class GetSubjectBySubjectAndUserIdCommandHandler : IRequestHandler<GetSubjectBySubjectAndUserId, SubjectDTO>
    {
        private readonly ISubjectRepository _SubjectRepository;
        public GetSubjectBySubjectAndUserIdCommandHandler(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }

        public Task<SubjectDTO> Handle(GetSubjectBySubjectAndUserId request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Subject = _SubjectRepository.GetSubjectBySubjectAndUserId(request.SubjectId, request.UserId);

            return Task.FromResult(Subject);
        }
    }
}
