using System.Collections;

namespace Board.Tests
{
    public class UserIdTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() =>
            UserListFixture.Ids.Select(x => new object[] { x }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}