using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallIT.Shared.DTOs;
using WallIT.Shared.Enums;

namespace WallIT.Web.Models
{
    public class RecordModel
    {
        public float Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime? TransactionDateUTC { get; set; }
        public RecordCategoryDTO[] recordCategoryDTO { get; set; }
        public int recordCategoryId { get; set; }
    }
    
}
