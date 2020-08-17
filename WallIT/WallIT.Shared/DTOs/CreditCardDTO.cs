using WallIT.Shared.DTOs.Base;

namespace WallIT.Shared.DTOs
{
    public class CreditCardDTO : DTOBase
    {
        public string Name { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
