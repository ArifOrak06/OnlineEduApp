namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class AboutNotFoundException : NotFoundException
    {
        public AboutNotFoundException(int id) :base($"Hakkımızda Metni Id : {id} ye sahip metin sistemde bulunamamıştır.")
        {
            
        }
    }
}
