using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Logic.Mediator.Queries;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mediator.Handlers.QueryHandlers.CreditCard
{
    public class GetCreditCardListByUserIdQueryHandler : IRequestHandler<GetCreditCardListByUserIdQuery, CreditCardDTO[]>
    {
        private readonly ICreditCardRepository _creditcardrepository;
        public GetCreditCardListByUserIdQueryHandler(ICreditCardRepository creditcardrepository)
        {
            _creditcardrepository = creditcardrepository;
        }

        public Task<CreditCardDTO[]> Handle(GetCreditCardListByUserIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Subject = _creditcardrepository.GetAllByUserId(request.UserId);
            return Task.FromResult(Subject);
        }
    }
}
