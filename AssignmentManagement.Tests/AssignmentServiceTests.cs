namespace AssignmentManagement.Tests
{
    using AssignmentManagement.Core;
    using AssignmentManagement.UI;
    using System.Collections.Generic;
    using Xunit;

    public class AssignmentServiceTests
    {
        [Fact]
        public void ListIncomplete_ShouldReturnOnlyAssignmentsThatAreNotCompleted()
        {
            // Arrange
            var service = new AssignmentService(new AssignmentFormatter(), new ConsoleAppLogger());
            var a1 = new Assignment("Incomplete Task", "Do something");
            var a2 = new Assignment("Completed Task", "Do something else");
            a2.MarkComplete();

            service.AddAssignment(a1);
            service.AddAssignment(a2);

            // Act
            var result = service.ListIncomplete();

            // Assert
            Assert.Single(result);
            Assert.Equal("Incomplete Task", result[0].Title);
        }

        [Fact]
        public void Formatter_ShouldReturnFormattedString()
        {
            // Arrange
            var assignment = new Assignment("Sample", "Description");
            var formatter = new AssignmentFormatter();

            // Act
            var result = formatter.Format(assignment);

            // Assert
            Assert.Contains("Sample", result);
            Assert.Contains("Incomplete", result);
        }

        [Fact]
        public void Logger_ShouldLogWhenAssignmentAdded()
        {
            // Arrange
            var logger = new FakeLogger();
            var formatter = new AssignmentFormatter();
            var service = new AssignmentService(formatter, logger);
            var assignment = new Assignment("Log Test", "Logging this task");

            // Act
            service.AddAssignment(assignment);

            // Assert
            Assert.NotEmpty(logger.Messages);
            Assert.Contains("Log Test", logger.Messages[0]);
        }
    }

    public class FakeLogger : IAppLogger
    {
        public List<string> Messages { get; } = new List<string>();

        public void Log(string message)
        {
            Messages.Add(message);
        }
    }
}

