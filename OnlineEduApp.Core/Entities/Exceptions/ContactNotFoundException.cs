namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class ContactNotFoundException : NotFoundException
    {
        public ContactNotFoundException(int id) : base($"İletişim Metin Id : {id} olan metin sistemde bulunamamıştır.")
        {
        }
    }
}
