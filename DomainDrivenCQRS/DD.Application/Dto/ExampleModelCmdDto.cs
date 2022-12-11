namespace DD.Application.Dto
{
    public class ExampleModelCmdDto
    {
        public int Id { get; }
        public string Name { get; }

        public ExampleModelCmdDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
