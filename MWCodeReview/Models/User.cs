using System;
using System.Collections.Generic;

namespace MWCodeReview.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LaseName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
