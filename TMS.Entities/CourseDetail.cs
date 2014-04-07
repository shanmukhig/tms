using System;
using System.Collections.Generic;

namespace TMS.Entities
{
  public class CourseDetail
  {
    public long Id { get; set; }
    public Course Course { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CourseDetailStatus Status { get; set; }
    public IEnumerable<CourseTimeTable> TimeTable { get; set; }
  }
}