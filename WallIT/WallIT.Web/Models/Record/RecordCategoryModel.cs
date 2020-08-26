using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallIT.Shared.DTOs;

namespace WallIT.Web.Models
{
    public class RecordCategoryModel
    {
        public int Id { get; set; }
        public RecordCategoryDTO[] recordCategoryDTO { get; set; }
        public int? recordCategoryId { get; set; }
        public string Name { get; set; }
        public SubjectDTO[] subjectDTO { get; set; }
        public int SubjectId { get; set; }
    }
}
