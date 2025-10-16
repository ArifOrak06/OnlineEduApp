namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class ArgumentNullBadRequestException : BadRequestException
    {
        public ArgumentNullBadRequestException() : base("Parametre null değer içeremez parametre")
        {
            
        }
    }
}
