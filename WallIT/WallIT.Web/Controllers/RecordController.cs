using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WallIT.Logic.Identity;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppIdentityUser> _userManager;
        public RecordController(IMediator mediator, UserManager<AppIdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> RecordDetails()//Test
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var SubjectQuery = new GetSubjectByUserIdQuery { UserId = user.Id };
            var SubjectResult = await _mediator.Send(SubjectQuery);
            return Json(SubjectResult);
            //return View(recordDTO);
        }
        [Authorize]
        public IActionResult RecordCategoryDetails()
        {
            return View();
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