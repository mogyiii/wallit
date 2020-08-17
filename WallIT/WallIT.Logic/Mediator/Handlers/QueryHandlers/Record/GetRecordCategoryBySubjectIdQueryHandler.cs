using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers.Record
{
    public class GetRecordCategoryBySubjectIdQueryHandler : IRequestHandler<GetRecordCategoryBySubjectIdQuery, RecordCategoryDTO>
    {
        private readonly IRecordCategoryRepository _recordrepository;
        public GetRecordCategoryBySubjectIdQueryHandler(IRecordCategoryRepository recordcategory)
        {
            _recordrepository = recordcategory;
        }

        public Task<RecordCategoryDTO> Handle(GetRecordCategoryBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var record = _recordrepository.Get(request.SubjectId);
            return Task.FromResult(record);
        }
    }
}
