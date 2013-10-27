namespace Portfolio.Data.Queries
{
    public interface IQueryStore
    {
        TQuery GetQuery<TQuery>();
    }
}
