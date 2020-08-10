using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Queries
{
    public class GetSubjectBySubjectAndUserId : IRequest<SubjectDTO>
    {
        public int UserId { get; set; }
        public int SubjectId { get; set; }
    }
}
