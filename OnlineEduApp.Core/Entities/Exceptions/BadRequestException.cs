namespace OnlineEduApp.Core.Entities.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string errorMessage) : base(errorMessage)
        {
            
        }
    }
}
