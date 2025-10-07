namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(int courseId) : base($"Course ID : {courseId} olan sistemde bulunmamaktadır.") { }
    }
}
