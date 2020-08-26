using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WallIT.Logic.Identity;
using WallIT.Logic.Mediator.Commands;
using WallIT.Logic.Mediator.Queries;
using WallIT.Logic.Services;
using WallIT.Shared.DTOs;
using WallIT.Web.Models;

namespace WallIT.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IStringLocalizer<SubjectController> _localizer;
        private readonly RecordCategoryService _recordCategoryService;
        public RecordController(IMediator mediator, UserManager<AppIdentityUser> userManager, IStringLocalizer<SubjectController> localizer, RecordCategoryService recordCategoryService)
        {
            _mediator = mediator;
            _userManager = userManager;
            _localizer = localizer;
            _recordCategoryService = recordCategoryService;
        }
        [Authorize]
        public async Task<IActionResult> RecordCategoryDetails()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var SubjectQuery = new GetSubjectListByUserIdQuery { UserId = user.Id };
            var SubjectResult = await _mediator.Send(SubjectQuery);
            RecordCategoryModel model = new RecordCategoryModel 
            { 
                subjectDTO = SubjectResult,
                recordCategoryDTO = await _recordCategoryService.ConvertRecordCategoryListToRecordDTOAsync(SubjectResult)
            };
            //return Json(model);
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> RecordDetails()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var SubjectQuery = new GetSubjectListByUserIdQuery { UserId = user.Id };
            var SubjectResult = await _mediator.Send(SubjectQuery);
            RecordModel model = new RecordModel
            {
                recordCategoryDTO = await _recordCategoryService.ConvertRecordCategoryListToRecordDTOAsync(SubjectResult)
            };
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> SaveRecordCategory(RecordCategoryDTO model)
        {
            var command = new SaveRecordCategoryCommand{
                RecordCategory = model
            };
            var result = await _mediator.Send(command);
            if (!result.Suceeded)
            {
                foreach (var msg in result.ErrorMessages)
                    ModelState.AddModelError("", _localizer[msg]);

                return View(model);
            }
            return Json(true);
        }
        [Authorize]
        public async Task<IActionResult> SaveRecord(RecordDTO model)
        {
            var command = new SaveRecordCommand
            {
                record = model
            };
            var result = await _mediator.Send(command);
            if (!result.Suceeded)
            {
                foreach (var msg in result.ErrorMessages)
                    ModelState.AddModelError("", _localizer[msg]);

                return View(model);
            }
            return Json(true);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> RecordDetails(int id)
        {
            var query = new GetRecordByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return View(result);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> RecordCategoryDetails(int id)
        {
            var query = new GetRecordCategoryByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return View(result);
        }
    }
    
}