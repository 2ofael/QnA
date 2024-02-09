namespace QnA.HelperClasses
{
    public class Pagination<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public int PreviousPageNumber => HasPreviousPage ? PageNumber - 1 : 1;
        public int NextPageNumber => HasNextPage ? PageNumber + 1 : TotalPages;

        public Pagination(IEnumerable<T> items, int pageNumber, int pageSize, int totalItems)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
        }

        public IEnumerable<T> GetItemsForCurrentPage()
        {
            return Items.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}
