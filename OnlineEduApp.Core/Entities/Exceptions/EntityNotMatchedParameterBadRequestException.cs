namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class EntityNotMatchedParameterBadRequestException: BadRequestException
    {
        public EntityNotMatchedParameterBadRequestException() : base("Parametre olarak gönderilen obje Id değeri ile Route üzerinden gönderilen Id değerleri eşleşmemektedir.")
        {
        }
    }
}
