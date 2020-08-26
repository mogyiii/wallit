using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WallIT.Logic.DTOs;
using WallIT.Logic.Mediator.Commands;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Services
{
    public class RecordCategoryService
    {
        private readonly IMediator _mediator;

        public RecordCategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult> EditRecordCategory(RecordCategoryDTO recordcategory, int UserId)
        {
            var result = new ActionResult();
            var query = new GetSubjectBySubjectAndUserId
            {
                SubjectId = recordcategory.SubjectId.Value,
                UserId = UserId
            };
            var Subject = await _mediator.Send(query);
            if (Subject == null)
            {
                result.Suceeded = false;
                result.ErrorMessages.Add("You don't have the right to edit this!");
                return result;
            }
            else
            {
                var command = new EditRecordCategoryCommand
                {
                    RecordCategory = recordcategory
                };
                var CommandResult = await _mediator.Send(command);
                if (CommandResult.Suceeded)
                {
                    result.Suceeded = true;
                }
                else
                {
                    foreach (var msg in result.ErrorMessages)
                        result.ErrorMessages.Add(msg);
                }
            }

            return result;
        }
        public async Task<ActionResult> DeleteRecordCategory(RecordCategoryDTO recordcategory, int UserId)
        {
            var result = new ActionResult();
            var query = new GetSubjectBySubjectAndUserId
            {
                SubjectId = recordcategory.SubjectId.Value,
                UserId = UserId
            };
            var QueryResult = await _mediator.Send(query);
            if (QueryResult == null)
            {
                result.Suceeded = false;
                result.ErrorMessages.Add("You don't have the right to delete this!");
                return result;
            }
            else
            {
                var command = new DeleteRecordCategoryCommand
                {
                    Id = recordcategory.Id
                };
                var CommandResult = await _mediator.Send(command);
                if (CommandResult.Suceeded)
                {
                    result.Suceeded = true;
                }
                else
                {
                    foreach (var msg in result.ErrorMessages)
                        result.ErrorMessages.Add(msg);
                }

            }
            return result;
        }
        public async Task<List<RecordCategoryDTO>> GetRecordCategoryDTOs(SubjectDTO[] SubjectResult)
        {
            List<RecordCategoryDTO> recordCategoryModels = new List<RecordCategoryDTO>();
            for (var i = 0; i < SubjectResult.Length; i++)
            {
                var RecordCategoryListQuery = new GetRecordCategoryListBySubjectIdQuery { SubjectId = SubjectResult[i].Id };
                var RecordCategorylist = await _mediator.Send(RecordCategoryListQuery);
                for (var j = 0; j < RecordCategorylist.Length; j++)
                {
                    recordCategoryModels.Add(RecordCategorylist[j]);
                }
            }
            return recordCategoryModels;
        }
        public async Task<RecordCategoryDTO[]> ConvertRecordCategoryListToRecordDTOAsync(SubjectDTO[] SubjectResult)
        {
            List<RecordCategoryDTO> recordCategoryList = await GetRecordCategoryDTOs(SubjectResult);
            RecordCategoryDTO[] recordCategoryDTO = new RecordCategoryDTO[recordCategoryList.Count];
            for (var i = 0; i < recordCategoryList.Count; i++)
            {
                recordCategoryDTO[i] = recordCategoryList[i];
            }
            return recordCategoryDTO;
        }
    }
}
