using AutoMapper;
using NHibernate;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Repositories
{
    public class RecordCategoryRepository : RepositoryBase<RecordCategoryEntity, RecordCategoryDTO>, IRecordCategoryRepository
    {
        public RecordCategoryRepository(ISession session, IMapper mapper) : base(session, mapper)
        { }

        public RecordCategoryDTO[] GetAllBySubjectId(int id)
        {
            var result = _session.QueryOver<RecordCategoryEntity>()
                .Where(x => x.Subject.Id == id)
                .List();

            if (result == null)
                return null;

            var dto = _mapper.Map<RecordCategoryDTO[]>(result);
            return dto;
        }
    }
}
