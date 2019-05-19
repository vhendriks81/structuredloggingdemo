namespace DemoApi.Models
{
    public class Rockstar : Person
    {
        public string Title { get; }

        public Rockstar(string name, string socialSecurityNumber, string title)
            : base(name, socialSecurityNumber)
        {
            Title = title;
        }
    }
}
