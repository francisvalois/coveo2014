namespace coveo2014.Services
{
    using com.coveo.blitz.thrift;

    using QueryResult = coveo2014.Domain.QueryResult;

    public interface IQueryService
    {
        QueryResult Query(Query query);
    }
}
