using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Identity;
using WallIT.Logic.Mediator.Commands;
using WallIT.Logic.Mediator.Queries;
using WallIT.Logic.Services;
using WallIT.Shared.DTOs;

namespace WallIT.Web.Controllers
{
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SubjectController> _localizer;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SubjectService _editSubjectService; 
        public SubjectController(IMediator mediator, UserManager<AppIdentityUser> userManager, SubjectService editSubjectService, IStringLocalizer<SubjectController> localizer)
        {
            _mediator = mediator;
            _userManager = userManager;
            _editSubjectService = editSubjectService;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var query = new GetSubjectByIdQuery { Id = id };
            var Subject = await _mediator.Send(query);

            return View(Subject);
        }
        public async Task<IActionResult> List() 
        {
            var query = new GetSubjectListQuery();
            var Subject = await _mediator.Send(query);
            return Json(Subject);
        }
        [Authorize]
        public async Task<IActionResult> SaveSubject(SubjectDTO model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            model.UserId = user.Id;
            var command = new SaveSubjectCommand
            {
                Subject = model
            };
            var CommandResult = await _mediator.Send(command);
            if (!CommandResult.Suceeded)
            {
                foreach (var msg in CommandResult.ErrorMessages)
                    ModelState.AddModelError("", _localizer[msg]);

                return View(model);
            }
            return Json(true);
        }
        [Authorize]
        public async Task<IActionResult> EditSubject(SubjectDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return Json(_editSubjectService.EditSubject(model, model.Id, user.Id));
        }
        [Authorize]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return Json(_deleteSubjectService.DeleteSubject(id, user.Id));
        }
    }
}