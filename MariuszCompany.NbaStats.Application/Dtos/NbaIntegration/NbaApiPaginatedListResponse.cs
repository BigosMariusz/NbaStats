namespace MariuszCompany.NbaStats.Application.Dto.NbaIntegration
{
    public class NbaApiPaginatedListResponse<T> : NbaApiListResponse<T>
    {
        public MetaOfResponse Meta { get; set; }
    }
}
