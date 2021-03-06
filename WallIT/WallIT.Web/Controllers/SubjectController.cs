﻿using MediatR;
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
using WallIT.Web.Models;

namespace WallIT.Web.Controllers
{
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SubjectController> _localizer;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SubjectService _SubjectService; 
        public SubjectController(IMediator mediator, UserManager<AppIdentityUser> userManager, SubjectService SubjectService, IStringLocalizer<SubjectController> localizer)
        {
            _mediator = mediator;
            _userManager = userManager;
            _SubjectService = SubjectService;
            _localizer = localizer;
        }
        [Authorize]
        public IActionResult SubjectDetails()
        {
            return View();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> SubjectDetails(int id)
        {
            var query = new GetSubjectByIdQuery { Id = id };
            var Subject = await _mediator.Send(query);

            return View(Subject);
        }
        [Authorize]
        public async Task<IActionResult> SubjectList() 
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var query = new GetSubjectListByUserIdQuery { 
                UserId = user.Id
            };
            var Subject = await _mediator.Send(query);
            return Json(Subject);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveSubject(SaveSubjectModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var SubjectDTO = new SubjectDTO
            {
                UserId = user.Id,
                CreditCardId = model.SelectCreditCard,
                Balance = model.Balance,
                Currency = model.Currency,
                Name = model.Name,
                SubjectType = model.SubjectType
            };
            
            var command = new SaveSubjectCommand
            {
                Subject = SubjectDTO
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
            return Json(_SubjectService.EditSubject(model, model.Id, user.Id));
        }
        [Authorize]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return Json(_SubjectService.DeleteSubject(id, user.Id));
        }
    }
}