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
    public class GetRecordCategoryListBySubjectIdQueryHandler : IRequestHandler<GetRecordCategoryListBySubjectIdQuery, RecordCategoryDTO[]>
    {
        private readonly IRecordCategoryRepository _recordrepository;
        public GetRecordCategoryListBySubjectIdQueryHandler(IRecordCategoryRepository recordcategory)
        {
            _recordrepository = recordcategory;
        }

        public Task<RecordCategoryDTO[]> Handle(GetRecordCategoryListBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var record = _recordrepository.GetAllBySubjectId(request.SubjectId);
            return Task.FromResult(record);
        }
    }
}
