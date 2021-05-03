using EdgeApi.Data;
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

        [Test]
        public void CreatePostTestShouldSucced()
        {
            var post = new Post();
            post.id = 0;
            post.title = "prueba";
            post.userId = 10;
            post.body = "prueba para Edge";
            Response response = PostsAccess.CreatePost(post);
            Assert.IsTrue(response.Posts[0].id == 101);
        }

        [Test]
        public void CreatePostTestReturnValidationError()
        {
            Response response = PostsAccess.CreatePost(null);
            Assert.IsTrue(response.ErrorCode == EdgeApi.ErrorCode.Validation);
        }

        [Test]
        public void UpdatePostTestShouldSucced()
        {
            var post = new Post();
            post.id = 1;
            post.title = "prueba actualizado";
            post.userId = 10;
            post.body = "prueba para Edge";
            Response response = PostsAccess.UpdatePost(post);
            Assert.IsTrue(response.Posts[0].id == 1);
        }

        [Test]
        public void UpdatePostTestReturnValidationError()
        {
            Response response = PostsAccess.UpdatePost(null);
            Assert.IsTrue(response.ErrorCode == EdgeApi.ErrorCode.Validation);
        }
    }
}