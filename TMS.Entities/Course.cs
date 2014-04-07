using System.Collections.Generic;

namespace TMS.Entities
{
  public class Course : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int? DurationInDays { get; set; }
    public decimal? Price { get; set; }
    public IEnumerable<CourseTopic> CourseTopics { get; set; }
  }
}