using System;
using WallIT.Shared.DTOs.Base;
using WallIT.Shared.Enums;

namespace WallIT.Shared.DTOs
{
    public class RecordDTO : DTOBase
    {
        public RecordCategoryDTO RecordCategory { get; set; }
        public int? RecordCategoryId { get; set; }

        public SubjectDTO Subject { get; set; }
        public int? SubjectId { get; set; }

        public double Amount { get; set; }

        public Currency Currency { get; set; }

        public DateTime TransactionDateUTC { get; set; }
    }
}
