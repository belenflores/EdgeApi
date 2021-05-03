using EdgeApi.DataAccess;
using EdgeApi.POCO;
using NUnit.Framework;

namespace APITests
{
    public class Tests
    {  

        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void GetAllPostsTestShouldSucced()
        {
            Response response = PostsAccess.GetAllPosts();
            Assert.IsTrue(response.Posts.Count > 1);
        }

        [Test]
        public void GetpostByIdTestShouldSucced()
        {
            Response response = PostsAccess.GetPostById(10);
            Assert.IsTrue(response.Posts[0].id == 10);
        }

        [Test]
        public void GetpostByIdTestShouldReturnValidationError()
        {
            Response response = PostsAccess.GetPostById(0);
            Assert.IsTrue(response.ErrorCode == EdgeApi.ErrorCode.Validation);
        }
    }
}