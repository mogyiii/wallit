using WallIT.DataAccess.Entities.Base;
using WallIT.Shared.Enums;

namespace WallIT.DataAccess.Entities
{
    public class RecordTemplateEntity : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual RecordCategoryEntity RecordCategory { get; set; }
        public virtual SubjectEntity Subject { get; set; }
        public virtual double Amount { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
