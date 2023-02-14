using System;
using System.Collections.Generic;

namespace Superhero.Models;

public partial class Student
{
    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int StuId { get; set; }

    public int StuRoll { get; set; }

    public string Branch { get; set; } = null!;

    public int Marks { get; set; }
}
