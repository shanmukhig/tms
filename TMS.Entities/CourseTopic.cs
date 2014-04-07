namespace TMS.Entities
{
  public class CourseTopic
  {
    public string Title { get; set; }
    public CourseDetailStatus Progress { get; set; }
    public string Duration { get; set; }
    public bool IsTagged { get; set; }
  }
}