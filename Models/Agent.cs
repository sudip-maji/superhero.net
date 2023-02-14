using System;
using System.Collections.Generic;

namespace Superhero.Models;

public partial class Agent
{
    public string AgentCode { get; set; } = null!;

    public string? AgentName { get; set; }

    public string? WorkingArea { get; set; }

    public int? Commission { get; set; }

    public string? PhoneNo { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
