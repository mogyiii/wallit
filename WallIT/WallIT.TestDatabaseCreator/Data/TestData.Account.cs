using WallIT.DataAccess.Entities;
using WallIT.Shared.Enums;

namespace WallIT.TestDatabaseCreator.Data
{
    internal static partial class TestData
    {
        internal static void CreateSubjects()
        {
            var user1 = session.Load<UserEntity>(1);

            var Subject1 = new SubjectEntity
            {
                Name = "Credit Card Subject",
                Balance = 20000,
                SubjectType = SubjectType.CreditCard,
                Currency = Currency.HUF,
                User = user1
            };
            InsertEntity(Subject1);

            var Subject2 = new SubjectEntity
            {
                Name = "Credit Card Subject",
                Balance = 3450,
                SubjectType = SubjectType.Cash,
                Currency = Currency.HUF,
                User = user1
            };
            InsertEntity(Subject2);
        }
    }
}
