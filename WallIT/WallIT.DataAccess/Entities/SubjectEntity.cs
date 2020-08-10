using WallIT.DataAccess.Entities.Base;
using WallIT.Shared.Enums;

namespace WallIT.DataAccess.Entities
{
    public class SubjectEntity : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual double Balance { get; set; }
        public virtual SubjectType SubjectType { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual CreditCardEntity CreditCard { get; set; }
    }
}
