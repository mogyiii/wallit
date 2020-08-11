using System;
using WallIT.Shared.DTOs.Base;
using WallIT.Shared.Enums;

namespace WallIT.Shared.DTOs
{
    public class RecordPlannedDTO : DTOBase
    {
        public string Name { get; set; }
        public int? RecordCategoryId { get; set; }
        public RecordCategoryDTO RecordCategory { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime? DeadlineUTC { get; set; }
        public bool IsRepeat { get; set; }
        public bool IsPaid { get; set; }
    }
}
