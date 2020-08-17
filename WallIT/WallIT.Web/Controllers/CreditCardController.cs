using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WallIT.Logic.Identity;
using WallIT.Logic.Mediator.Commands;
using WallIT.Shared.DTOs;

namespace WallIT.Web.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppIdentityUser> _userManager;

        public CreditCardController(IMediator mediator, UserManager<AppIdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult CreditCardDetails()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreditCardDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            model.UserId = user.Id;
            var command = new SaveCreditCardCommand 
            { 
                CreditCard = model,
            };
            var result = await _mediator.Send(command);
            if (result.Suceeded)
                return Json(true);
            else
            {
                foreach (var msg in result.ErrorMessages)
                    ModelState.AddModelError("", msg);

                return Json(model);
            }
        }
    }
}