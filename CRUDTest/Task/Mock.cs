using CRUD;
using Telerik.JustMock.EntityFramework;

namespace CRUDTest.Task
{
    public class Mock
    {
        public static Database1Entities CreateContext()
        {
            return Telerik.JustMock.Mock.Create<Database1Entities>().PrepareMock();
        }
    }
}