namespace Demo.Models
{
    using System;

    public class Todo
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public User AssignedTo { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsDone { get; set; }
    }
}
