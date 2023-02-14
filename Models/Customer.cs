using System;
using System.Collections.Generic;

namespace Superhero.Models;

public partial class Customer
{
    public string CustCode { get; set; } = null!;

    public string CustName { get; set; } = null!;

    public string? CustCity { get; set; }

    public string WorkingArea { get; set; } = null!;

    public string Country { get; set; } = null!;

    public decimal? Grade { get; set; }

    public decimal OpeningAmt { get; set; }

    public decimal ReceiveAmt { get; set; }

    public decimal PaymentAmt { get; set; }

    public decimal OutstandingAmt { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string AgentCode { get; set; } = null!;

    public virtual Agent AgentCodeNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
