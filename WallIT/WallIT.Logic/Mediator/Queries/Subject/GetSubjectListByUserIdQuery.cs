using MediatR;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Queries
{
    public class GetSubjectListByUserIdQuery : IRequest<SubjectDTO[]>
    {
        public int UserId { get; set; }
    }
}
