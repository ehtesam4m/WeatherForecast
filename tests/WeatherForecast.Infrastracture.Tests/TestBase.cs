namespace WeatherForecast.Infrastracture.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected TestDatabaseInitializer _testDb;
        public void Dispose()
        {
            _testDb.Dispose();
        }
    }
}
