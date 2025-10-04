namespace OnlineEduApp.Core.Entities.RequestFeatures
{
    public class PagedList<T>: List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                CurrentPage = pageNumber,
                TotalCount = count,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var newPaggingItems = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(newPaggingItems, count, pageNumber, pageSize);
            // PagedList sayfalanmış verileri ve sayfalama künye bilgilerinin tutulduğu bir MetaData nesnesini de içerir.
            // Service katmanında PagedList<t> olarak gelen yapıyı sunum katmanına (tupple) olarak göndermek icap eder, HEm verileri, hem metaData bilgilerini,
            // Son olarak künye bilgilerini de Response header ına ekleyebiliriz.   
        }
    }
}
