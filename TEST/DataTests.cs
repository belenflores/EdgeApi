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
    }
}