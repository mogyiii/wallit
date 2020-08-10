using System.ComponentModel;
using WallIT.Shared.DTOs.Base;
using WallIT.Shared.Enums;

namespace WallIT.Shared.DTOs
{
    public class SubjectDTO : DTOBase
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Balance")]
        public double Balance { get; set; }

        [DisplayName("Type")]
        public SubjectType SubjectType { get; set; }

        [DisplayName("Currency")]
        public Currency Currency { get; set; }

        public int? UserId { get; set; }

        public UserDTO User { get; set; }
        public int? CreditCardId { get; set; }
        public CreditCardDTO CreditCard { get; set; }
    }
}
