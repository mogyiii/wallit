using WallIT.Shared.DTOs.Base;
using WallIT.Shared.Enums;

namespace WallIT.Shared.DTOs
{
    public class RecordTemplateDTO : DTOBase
    {
        public string Name { get; set; }
        public RecordCategoryDTO RecordCategory { get; set; }
        public SubjectDTO Subject { get; set; }
        public int? SubjectId { get; set; }
        public int? RecordCategoryId { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
