using System;
using System.Collections.Generic;

namespace todoApp.Models
{
    public partial class TodoTask
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
