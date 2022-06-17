using MovieStoryWebApp.Test.Utils;
using MovieStoryWebApp.Test.Utils.Definitions;
using MovieStoryWebApp.Test.Utils.Extensions;
using MovieStoryWebApp.Test.Utils.Helpers;
using MovieStoryWebApp.Test.Utils.Pages;
using NUnit.Framework;
using System.Linq;

namespace MovieStoreWebApp.Test
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.MicrosoftEdge)]
    [Parallelizable(ParallelScope.All)]
    public class MovieStoreTests : MovieStoreTestBase
    {
        private readonly BrowserType _browserType;

        public MovieStoreTests(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [Test]
        [Description("The MovieStore Home page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatHomePageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(browser.NavigateTo<HomePage>().Verify());
            }
        }

        [Test]
        [Description("The MovieStore Movies page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatMoviesPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(browser.NavigateTo<MoviesPage>().Verify());
            }
        }

        [Test]
        [Description("The MovieStore Privacy page can be open")]
        [Category(TestCategory.Smoke)]
        public void TestThatPrivacyPageCanBeOpen()
        {
            using (var browser = StartBrowser(_browserType))
            {
                Assert.IsTrue(browser.NavigateTo<PrivacyPage>().Verify());
            }
        }

        [Test]
        [Description("The Movies button navigates to the Movies page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToMoviesPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var moviesPage = homePage.ClickMoviesLink();
                Assert.IsTrue(moviesPage.Verify());
            }
        }

        [Test]
        [Description("The Privacy button navigates to the Privacy page")]
        [Category(TestCategory.Smoke)]
        public void TestThatUserCanNavigateToPrivacyPage()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var homePage = browser.NavigateTo<HomePage>();
                var privacyPage = homePage.ClickPrivacyLink();
                Assert.IsTrue(privacyPage.Verify());
            }
        }

        [Test]
        [Description("Testing seed data is present correctly")]
        [Category(TestCategory.Smoke)]
        public void TestThatSeedDataIsPresentCorrectly()
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
        [Description("Testing the search moview operation")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatMovieCanBeSearched()
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
        [Description("Testing the Create new movie operation")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatMovieCanBeCreated()
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
        [Description("Testing the Delete movie operation")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatMovieCanBeDeleted()
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
        public void TestThatDeletingMovieCanBeCancelled()
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
        [Description("Testing that movie details page can be open")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatMovieDetailsPageCanBeOpen()
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
            // SetUp db before test TestThatMovieCanBeDeleted
            if (TestContext.CurrentContext.Test.MethodName == nameof(TestThatMovieCanBeDeleted))
            {
                DBHelper.AddMovie(TestData.Movies.TheHangover);
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Clean db after test TestThatMovieCanBeCreated
            if (TestContext.CurrentContext.Test.MethodName == nameof(TestThatMovieCanBeCreated))
            {
                DBHelper.DeleteMovie(TestData.Movies.TheHangover.Title);
            }
        }
    }
}
