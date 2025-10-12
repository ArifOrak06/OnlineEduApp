namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class TestimonialNotFoundException : NotFoundException
    {
        public TestimonialNotFoundException(int id) : base($"Testimonial Id : {id} sistemde kayıtlı değildir.!")
        {
        }
    }
}
