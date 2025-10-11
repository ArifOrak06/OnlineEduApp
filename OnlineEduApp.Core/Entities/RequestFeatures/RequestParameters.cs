namespace OnlineEduApp.Core.Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;

        // Auto-implemented properties for pagination
        public int PageNumber { get; set; }

        // Full property 1
        private int _pageSize;
        // Full Property 2
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; } // prop'a atanan dğer maxPageSize'den büyükse maxPageSize değeri olan 50 atanır, küçükse prop'a atanan değer atanır.

        }
    }
}
