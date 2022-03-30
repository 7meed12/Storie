namespace Api.Helpers
{
    public class Pagination<T> where T: class
    {
        public Pagination(int pageIndex, int pgaeSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PgaeSize = pgaeSize;
            Count = count;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PgaeSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
