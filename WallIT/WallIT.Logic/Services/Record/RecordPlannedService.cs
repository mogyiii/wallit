﻿using MediatR;
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
    public class RecordPlannedService
    {
        private readonly IMediator _mediator;

        public RecordPlannedService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult> EditRecordPlanned(RecordPlannedDTO RecordPlanned,int UserId)
        {
            var result = new ActionResult();

            var query = new GetSubjectBySubjectAndUserId
            {
                SubjectId = RecordPlanned.RecordCategory.SubjectId.Value,
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
                var command = new EditRecordPlannedCommand
                {
                    RecordPlanned = RecordPlanned
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
        public async Task<ActionResult> DeleteRecordPlanned(RecordPlannedDTO RecordPlanned, int UserId)
        {
            var result = new ActionResult();
            var query = new GetSubjectBySubjectAndUserId
            {
                SubjectId = RecordPlanned.RecordCategory.SubjectId.Value,
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
                var command = new DeleteRecordPlannedCommand
                {
                    Id = RecordPlanned.Id
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
    }
}
