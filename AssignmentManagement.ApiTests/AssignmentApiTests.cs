
using System.Net;
using System.Net.Http.Json;
using AssignmentManagement.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using Xunit;

namespace AssignmentManagement.ApiTests
{
    public class AssignmentApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;


        public AssignmentApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public void PrintCurrentDirectory()
        {
            Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");
        }

        [Fact]
        public async Task CanCreateAssignment()
        {
            var assignment = new Assignment("Test Assignment", "This is a test assignment.");
            var response = await _client.PostAsJsonAsync("/api/assignment", assignment);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CanGetAllAssignments()
        {
            //create new assignment
            var assignment = new Assignment("Test2 Assignment", "This is a test assignment.");
            await _client.PostAsJsonAsync("/api/assignment", assignment);
            var response = await _client.GetAsync("/api/assignment");
            response.EnsureSuccessStatusCode();

            var assignments = await response.Content.ReadFromJsonAsync<List<Assignment>>();
            Assert.Contains(assignments, a => a.Title == "Test2 Assignment");
        }
    }
}
