using MovieStoreWebApp.Test.Utils;
using MovieStoreWebApp.Test.Utils.DbHandlers;
using MovieStoreWebApp.Test.Utils.Definitions;
using MovieStoreWebApp.Test.Utils.Extensions;
using MovieStoreWebApp.Test.Utils.Pages;
using NUnit.Framework;
using System.Linq;

namespace MovieStoreWebApp.Test
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.MicrosoftEdge)]
    [Parallelizable(ParallelScope.All)]
    public class MoviesPageTests : MovieStoreTestBase
    {
        private readonly BrowserType _browserType;

        public MoviesPageTests(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_NavigateToMoviesPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(browser.NavigateTo<MoviesPage>().Verify());
            }
        }

        [Test]
        [Category(TestCategory.Smoke)]
        public void Test_SeedData()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                var movies = moviesPage.Movies;
                Assert.IsTrue(movies.Any(m => m == "Titanic"));
                Assert.IsTrue(movies.Any(m => m == "Scream"));
                Assert.IsTrue(movies.Any(m => m == "American Pie"));
                Assert.IsTrue(movies.Any(m => m == "The Lion King"));
                Assert.AreEqual(4, movies.Count());
            }
        }

        [Test]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void Test_Search()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                Assert.AreEqual(4, moviesPage.Movies.Count());
                moviesPage.SearchMovie(TestData.Movies.Titanic.Title);
                Assert.AreEqual(1, moviesPage.Movies.Count());
                moviesPage.SearchMovie(string.Empty);
                Assert.AreEqual(4, moviesPage.Movies.Count());
            }
        }

        [Test]
        [NonParallelizable]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void Test_Create()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                Assert.IsFalse(moviesPage.Movies.Any(m => m == TestData.Movies.TheHangover.Title));
                var createMoviePage = moviesPage.ClickCreateNewLink();
                Assert.IsTrue(createMoviePage.Verify());
                moviesPage = createMoviePage.CreateNewMovie(TestData.Movies.TheHangover);
                Assert.IsTrue(moviesPage.Movies.Any(m => m == TestData.Movies.TheHangover.Title));
            }
        }

        [Test]
        [NonParallelizable]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void Test_Delete()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                Assert.IsTrue(moviesPage.Movies.Any(m => m == TestData.Movies.TheHangover.Title));
                moviesPage.DeleteMovie(TestData.Movies.TheHangover.Title);
                Assert.IsFalse(moviesPage.Movies.Any(m => m == TestData.Movies.TheHangover.Title));
            }
        }

        [Test]
        [Description("Testing that deleting a movie can be cancelled")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void Test_CancelDelete()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                Assert.IsTrue(moviesPage.Movies.Any(m => m == TestData.Movies.Titanic.Title));
                moviesPage.DeleteMovie(TestData.Movies.Titanic.Title, true);
                Assert.IsTrue(moviesPage.Movies.Any(m => m == TestData.Movies.Titanic.Title));
            }
        }

        [Test]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void Test_Details()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                var detailsPage = moviesPage.ClickDetailsLink(0);
                Assert.IsTrue(detailsPage.VerifyMovieDetails(TestData.Movies.Titanic.Title));

            }
        }

        [SetUp]
        public void SetUp()
        {
            if (TestContext.CurrentContext.Test.MethodName == nameof(Test_Delete))
            {
                var handler = new MoviesHandler();
                handler.Create(TestData.Movies.TheHangover);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Test.MethodName == nameof(Test_Create))
            {
                var handler = new MoviesHandler();
                handler.Delete(TestData.Movies.TheHangover.Title);
            }
        }
    }
}
