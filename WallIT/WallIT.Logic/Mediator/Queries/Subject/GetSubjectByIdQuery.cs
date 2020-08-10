using MediatR;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Queries
{
    public class GetSubjectByIdQuery : IRequest<SubjectDTO>
    {
        public int Id { get; set; }
    }
}
