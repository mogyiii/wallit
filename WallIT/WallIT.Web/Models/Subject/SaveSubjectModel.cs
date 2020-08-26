using System.Collections.Generic;
using WallIT.Shared.DTOs;
using WallIT.Shared.Enums;

namespace WallIT.Web.Models
{
    public class SaveSubjectModel
    {
        public int SelectCreditCard{ get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public SubjectType SubjectType { get; set; }
        public Currency Currency { get; set; }
    }
}
