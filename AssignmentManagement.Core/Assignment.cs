using System;

namespace AssignmentManagement.Core
{
    public class Assignment
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public Priority Priority { get; private set; }

        public Assignment(string title, string description, Priority priority = Priority.Medium)
        {
            Validate(title, nameof(title));
            Validate(description, nameof(description));

            Title = title;
            Description = description;
            Priority = priority; // Default priority
            IsCompleted = false;
        }

        public void Update(string newTitle, string newDescription)
        {
            Validate(newTitle, nameof(newTitle));
            Validate(newDescription, nameof(newDescription));

            Title = newTitle;
            Description = newDescription;
        }

        public void MarkComplete()
        {
            IsCompleted = true;
        }

        private void Validate(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"{fieldName} cannot be blank or whitespace.");
        }
    }
}
