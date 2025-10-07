namespace OnlineEduApp.Core.Entities.Exceptions
{
    public sealed class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() : base("Maksimum fiyat 1000'den küçük olmalı, 10'dan ise büyük olmalıdır.")
        {
        }
    }
}
