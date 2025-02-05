using System;
using System.Collections.Generic;

namespace userprofileAPI.Models;

public partial class ContactRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? SubmittedOn { get; set; }
}
