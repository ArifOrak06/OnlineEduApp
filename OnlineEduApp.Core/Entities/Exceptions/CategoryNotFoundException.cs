namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId) : base($"Category ID : {categoryId} olan sistemde bulunmamaktadır.")
        {
        }
    }
}
