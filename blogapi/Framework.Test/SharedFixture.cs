using Framework.Shared.Helpers;

namespace Framework.Test
{
    /// <summary>======================================================================
    /// Namespace: Framework.Test
    ///  Filename: SharedFixture.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Unit test for the Framework.Shared project
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    /// 
    /// =====================================================================</summary>
    [TestClass]
    public class SharedFixture
    {
        [TestMethod]
        public async Task AsyncHelperTest()
        {
            var testValue = "MyTest";
            var args = new MockEventArgs { Name = testValue }; // Para for sync function

            Func<MockEventArgs, MockData> syncFunc =
                (args) => new MockData { Name = args.Name };

            var result = await AsyncHelper.ToAsync(args, syncFunc);
            Assert.AreEqual(testValue, result.Name);

            result = await AsyncHelper.ToAsync(args, SetData);
            Assert.AreEqual(testValue, result.Name);
        }
        public MockData SetData(EventArgs e)
        {
            var args = e as MockEventArgs;
            return new MockData { Name = args.Name };
        }
    }

    public class MockEventArgs() : EventArgs { public string? Name { get; set; } }
    public class MockData() { public string? Name { get; set; } }
}

