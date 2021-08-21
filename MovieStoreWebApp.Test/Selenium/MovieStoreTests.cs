using MovieStoreWebApp.Test.Definitions;
using MovieStoreWebApp.Test.Extensions;
using MovieStoreWebApp.Test.Helpers;
using MovieStoreWebApp.Test.Pages;
using MovieStoreWebApp.Test.Utils;
using NUnit.Framework;
using System.Linq;

namespace MovieStoreWebApp.Test.Selenium
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
            }
        }

        [Test]
        [Description("Testing the search moview operation")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatUserCanSearchMovie()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                Assert.AreEqual(4, moviesPage.Movies.Count());
                moviesPage.SearchMovie("Titanic");
                Assert.AreEqual(1, moviesPage.Movies.Count());
                moviesPage.SearchMovie(string.Empty);
                Assert.AreEqual(4, moviesPage.Movies.Count());
            }
        }

        [Test]
        [NonParallelizable]
        [Description("Testing the Create new movie operation")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatUserCanCreateNewMovie()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                var movies = moviesPage.Movies;
                Assert.IsFalse(movies.Any(m => m == TestData.Movies.TheHangover.Title));
                var createMoviePage = moviesPage.ClickCreateNewLink();
                Assert.IsTrue(createMoviePage.Verify());
                moviesPage = createMoviePage.CreateNewMovie(TestData.Movies.TheHangover);
                movies = moviesPage.Movies;
                Assert.IsTrue(movies.Any(m => m == TestData.Movies.TheHangover.Title));
            }
        }


        [Test]
        [NonParallelizable]
        [Description("Testing the Delete movie operation")]
        [Category(TestCategory.Regression), Category(TestCategory.Positive)]
        public void TestThatUserCanDeleteMovie()
        {
            using (var browser = StartBrowser(_browserType))
            {
                var moviesPage = browser.NavigateTo<MoviesPage>();
                var movies = moviesPage.Movies;
                Assert.IsTrue(movies.Any(m => m == TestData.Movies.TheHangover.Title));
                var deleteMoviePage = moviesPage.ClickDeleteMovieLink(TestData.Movies.TheHangover.Title);
                Assert.IsTrue(deleteMoviePage.VerifyMovie(TestData.Movies.TheHangover.Title));
                moviesPage = deleteMoviePage.ClickDeleteButton();
                movies = moviesPage.Movies;
                Assert.IsFalse(movies.Any(m => m == TestData.Movies.TheHangover.Title));
            }
        }

        [SetUp]
        public void SetUp()
        {
            // SetUp db before test TestThatUserCanDeleteMovie
            if (TestContext.CurrentContext.Test.MethodName == nameof(TestThatUserCanDeleteMovie))
            {
                DBHelper.AddMovie(TestData.Movies.TheHangover);
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Clean db after test TestThatUserCanCreateNewMovie
            if (TestContext.CurrentContext.Test.MethodName == nameof(TestThatUserCanCreateNewMovie))
            {
                DBHelper.DeleteMovie(TestData.Movies.TheHangover.Title);
            }
        }
    }
}
