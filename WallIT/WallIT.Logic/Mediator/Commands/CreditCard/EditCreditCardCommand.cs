﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WallIT.Logic.DTOs;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Commands
{
    public class EditCreditCardCommand : IRequest<ActionResult>
    {
        public CreditCardDTO CreditCard { get; set; }
    }
}
