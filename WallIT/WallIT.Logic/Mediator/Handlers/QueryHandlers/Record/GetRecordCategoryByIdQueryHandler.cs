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
    public class GetRecordCategoryByIdQueryHandler : IRequestHandler<GetRecordCategoryByIdQuery, RecordCategoryDTO>
    {
        private readonly IRecordCategoryRepository _recordrepository;
        public GetRecordCategoryByIdQueryHandler(IRecordCategoryRepository recordcategory)
        {
            _recordrepository = recordcategory;
        }

        public Task<RecordCategoryDTO> Handle(GetRecordCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var record = _recordrepository.Get(request.Id);
            return Task.FromResult(record);
        }
    }
}
