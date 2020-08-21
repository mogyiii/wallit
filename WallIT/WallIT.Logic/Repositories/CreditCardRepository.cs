using AutoMapper;
using NHibernate;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Repositories
{
    public class CreditCardRepository : RepositoryBase<CreditCardEntity, CreditCardDTO>, ICreditCardRepository
    {
        public CreditCardRepository(ISession session, IMapper mapper) : base(session, mapper)
        { }

        public CreditCardDTO[] GetAllByUserId(int UserId)
        {
            var result = _session.QueryOver<CreditCardEntity>()
                .Where(x => x.User.Id == UserId)
                .List();

            if (result == null)
                return null;

            var dto = _mapper.Map<CreditCardDTO[]>(result);
            return dto;
        }
    }
}
