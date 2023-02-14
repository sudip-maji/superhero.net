using System;
using System.Collections.Generic;

namespace Superhero.Models;

public partial class Order
{
    public decimal OrdNum { get; set; }

    public decimal Amount { get; set; }

    public decimal AdvanceAmount { get; set; }

    public DateTime OrdDate { get; set; }

    public string CustCode { get; set; } = null!;

    public string AgentCode { get; set; } = null!;

    public string OrdDescription { get; set; } = null!;

    public virtual Agent AgentCodeNavigation { get; set; } = null!;

    public virtual Customer CustCodeNavigation { get; set; } = null!;
}
