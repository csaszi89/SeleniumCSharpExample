using NUnit.Framework;

namespace MovieStoreWebApp.Test
{
    public class TestSetInitializer
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // TODO: call RunMovieStoreWebApp.bat to start the web server
        }

        [OneTimeSetUp]
        public void OneTimeTearDown()
        {
            // TODO: kill RunMovieStoreWebApp.bat to start the web server
        }
    }
}
