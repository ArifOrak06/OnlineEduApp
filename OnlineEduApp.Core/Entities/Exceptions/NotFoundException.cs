namespace OnlineEduApp.Core.Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string errorMessage) :base(errorMessage) { }
    }
}
