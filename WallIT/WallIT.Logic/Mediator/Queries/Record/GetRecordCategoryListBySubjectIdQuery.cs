﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Queries
{
    public class GetRecordCategoryListBySubjectIdQuery : IRequest<RecordCategoryDTO[]>
    {
        public int SubjectId { get; set; }
    }
}
