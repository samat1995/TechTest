using System;
using System.Threading.Tasks;
using AutomationTests.Services;
using AutomationTests.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FluentAssertions;

namespace AutomationTests
{
    [TestClass]
    public class UnitTest1
    {
        private JsonPlaceholderService _jsonPlaceholderService;

        public UnitTest1()
        {
            _jsonPlaceholderService = new JsonPlaceholderService();
        }


        [TestMethod]
        public async Task CreatedPostTests()
        {
            // arrange

            var postsPreCreation = await _jsonPlaceholderService.GetAllPostsAsync();
            var newPost = new
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
            retrievedPost.Title.Should().Be(newPost.Title);
            retrievedPost.Body.Should().Be(newPost.Body);
            retrievedPost.UserId.Should().Be(newPost.UserId);
        }
    }
}
