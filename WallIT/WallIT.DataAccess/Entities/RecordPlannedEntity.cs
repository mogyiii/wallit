using System;
using WallIT.DataAccess.Entities.Base;
using WallIT.Shared.Enums;

namespace WallIT.DataAccess.Entities
{
    public class RecordPlannedEntity : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual RecordCategoryEntity RecordCategory { get; set; }
        public virtual double Amount { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual DateTime? DeadlineUTC { get; set; }
        public virtual Repeat IsRepeat { get; set; }
        public virtual bool IsPaid { get; set; }
    }
}
