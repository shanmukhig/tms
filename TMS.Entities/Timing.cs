using System;

namespace TMS.Entities
{
  public class Timing
  {
    public int? Month { get; set; }
    public int? Year { get; set; }
    public int? Hours { get; set; }
    public int? Minutes { get; set; }
    public int? Seconds { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
  }
}