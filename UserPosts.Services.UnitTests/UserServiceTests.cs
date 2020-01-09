using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserPosts;
using NUnit;
using UserPosts.Domain;
using NUnit.Framework;
using NSubstitute;
using System.Threading.Tasks;

namespace UserPosts.Services.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void Shoul_dHave_Inactive_When_Less_Than_5Posts()
        {
            //Arrange
            var fakeUserRepository = Substitute.For<IUserRepository>();

            var fakeUser = new User()
            {
                Email = "fake@fake.com",
                Id = 1,
                Name = "name",
                Username = "username"
            };

            fakeUserRepository.GetById(1).Returns(fakeUser);

            var fakePostRepository = Substitute.For<IPostRepository>();

            var dummyPosts = new List<Post>()
            {
                new Post()
                {
                    UserId = 1,
                    Body = "asdsa"
                },
                new Post()
                {
                    UserId = 1,
                    Body = "body 2"
                },
                new Post()
                {
                    UserId = 1,
                    Body = "body 2"
                }
            };

            fakePostRepository.GetPostsByUserId(1).Returns(dummyPosts);

            UserService sut = new UserService(fakeUserRepository, fakePostRepository);
            //Act

            var response = sut.GetUserActiveRespose(1);

            //Assert
            Assert.AreEqual(UserPostsStatus.Inactive, response.Status);
        }


        [Test]
        public void Should_Have_Active_When_More_Than_7Posts()
        {
            //Arrange
            var fakeUserRepo = Substitute.For<IUserRepository>();
            var user = new User()
            {
                Id = 1,
                Email = "em@.com",
                Name = "name",
                Username = "user",
            };
            fakeUserRepo.GetById(1).Returns(user);

            var fakePostRepo = Substitute.For<IPostRepository>();
            var fakePost = new List<Post>()
            {
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                },
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                },
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                },
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                },
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                },
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                },
                new Post
                {
                    Id=1,
                    Body="dasdasd"
                }
            };
            fakePostRepo.GetPostsByUserId(1).Returns(fakePost);
            UserService sut = new UserService(fakeUserRepo, fakePostRepo);

            //Act
            var response = sut.GetUserActiveRespose(1);

            //Assert
            Assert.AreEqual(response.Status, UserPostsStatus.Active);
        }

    }
}
