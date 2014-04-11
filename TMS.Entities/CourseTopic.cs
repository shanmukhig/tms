using System.Collections.Generic;

namespace TMS.Entities
{
  public class CourseTopic
  {
    public int SequenceId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? DurationInHours { get; set; }
    public IEnumerable<CourseTopic> CourseTopics { get; set; }
  }
}