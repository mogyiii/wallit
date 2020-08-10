using MediatR;
using WallIT.Logic.DTOs;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Commands
{
    public class EditSubjectCommand : IRequest<ActionResult>
    {
        public SubjectDTO Subject { get; set; }
    }
}
