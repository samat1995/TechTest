using System;
using System.Threading.Tasks;
using AutomationTests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FluentAssertions;
using System.Net;
using AutomationTests.Types.Helpers;

namespace AutomationTests
{
    [TestClass]
    public class UnitTests
    {
        private JsonPlaceholderService _jsonPlaceholderService;

        public UnitTests()
        {
            _jsonPlaceholderService = new JsonPlaceholderService();
        }


        [TestMethod]
        public async Task GetAllPostsTest()
        {
            // act
            var allPosts = await _jsonPlaceholderService.GetAllPostsAsync();

            // assert
            allPosts.Should().NotBeNull();
            allPosts.Count().Should().BeGreaterThan(0);
        }


        [TestMethod]
        public async Task CreatePostTest()
        {
            // arrange
            var newPost = new PostCreation
            {
                Title = Guid.NewGuid().ToString("N"),
                Body = Guid.NewGuid().ToString("N"),
                UserId = new Random().Next()
            };


            // act
            var createdPost = await _jsonPlaceholderService.CreatePost(newPost);

            // assert
            createdPost.Should().NotBeNull();
            var retrievedPost = await _jsonPlaceholderService.GetPostAsync(createdPost.Id);

            createdPost.Title.Should().Be(newPost.Title);
            createdPost.Body.Should().Be(newPost.Body);
            createdPost.UserId.Should().Be(newPost.UserId);

            retrievedPost.Title.Should().Be(newPost.Title);
            retrievedPost.Body.Should().Be(newPost.Body);
            retrievedPost.UserId.Should().Be(newPost.UserId);
        }


        [TestMethod]
        public async Task DeletePostTest()
        {
            // arrange
            var postsPreCreation = await _jsonPlaceholderService.GetAllPostsAsync();
            var postToDelete = postsPreCreation.First();

            // act
            var response = await _jsonPlaceholderService.DeletePost(postToDelete.Id);

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var retrievedPost = await _jsonPlaceholderService.GetPostAsync(postToDelete.Id);
            retrievedPost.Should().BeNull();
        }
    }
}
