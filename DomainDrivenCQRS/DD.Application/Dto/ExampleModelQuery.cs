namespace DD.Application.Dto
{
    public class ExampleModelQueryDto
    {
        public OrderBy OrderBy { get; set; }
    }

    public enum OrderBy
    {
        NameAsc,
        NameDesc,
        IdAsc,
        IdDesc
    }
}
