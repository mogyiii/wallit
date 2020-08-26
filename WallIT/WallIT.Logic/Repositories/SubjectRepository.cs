using AutoMapper;
using NHibernate;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Shared.DTOs;
using WallIT.Shared.Interfaces.DomainModel.DTO;

namespace WallIT.Logic.Repositories
{
    public class SubjectRepository : RepositoryBase<SubjectEntity, SubjectDTO>, ISubjectRepository
    {
        public SubjectRepository(ISession session, IMapper mapper) : base(session, mapper)
        { }

        public SubjectDTO[] GetAllByUserId(int UserId)
        {
            var result = _session.QueryOver<SubjectEntity>()
                .Where(x => x.User.Id == UserId)
                .List();

            if (result == null)
                return null;

            var dto = _mapper.Map<SubjectDTO[]>(result);
            return dto;
        }

        public SubjectDTO GetSubjectBySubjectAndUserId(int SubjectId, int UserId)
        {
            var result = _session.QueryOver<SubjectEntity>()
                .Where(x => x.Id == SubjectId)
                .Where(x => x.User.Id == UserId);

            if (result == null)
                return null;

            var dto = _mapper.Map<SubjectDTO>(result);
            return dto;
        }
    }
}
