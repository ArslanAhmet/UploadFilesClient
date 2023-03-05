namespace AsyaLogic.Infrastructure.Helpers
{
    public class PagingParameters
    {
        private const int maxPageSize = 30;
        private int _pageSize = 30;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
