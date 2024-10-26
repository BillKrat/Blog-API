using Framework.Shared.Helpers;

namespace Framework.Test
{
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

