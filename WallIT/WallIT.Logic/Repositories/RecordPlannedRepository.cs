using AutoMapper;
using NHibernate;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Interfaces.Repositories;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Repositories
{
    public class RecordPlannedRepository : RepositoryBase<RecordPlannedEntity, RecordPlannedDTO>, IRecordPlannedRepository
    {
        public RecordPlannedRepository(ISession session, IMapper mapper) : base(session, mapper)
        { }
    }
}
