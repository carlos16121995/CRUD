namespace CRUD.Domain.Infra.Requests
{
    public class BasePagedRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderByProperty { get; set; } = "Id";
    }
}
