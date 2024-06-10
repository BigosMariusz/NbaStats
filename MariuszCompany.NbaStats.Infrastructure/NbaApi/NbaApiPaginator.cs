namespace MariuszCompany.NbaStats.Infrastructure.NbaApi
{
    public class NbaApiPaginator
    {
        private int _requestCounter = 0;
        private readonly int _requestLimit;
        public NbaApiPaginator(int requestLimit)
        {
            _requestLimit = requestLimit;
        }

        public int? NextCursor { get; private set; } = 0;

        public void SaveRequest(int? nextCursor)
        {
            NextCursor = nextCursor;
            _requestCounter++;
        }

        public bool AllPagesDownloaded
        {
            get
            {
                // Due to query limits, we only allow a certain amount of data to be downloaded.
                // If there were no limits in this API the only condition should be NextCursor == null
                return NextCursor == null || _requestLimit == _requestCounter;
            }
        }
    }
}
