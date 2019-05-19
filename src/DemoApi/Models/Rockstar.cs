namespace DemoApi.Models
{
    public class Rockstar : Person
    {
        public Rockstar(string name, string socialSecurityNumber, string title)
            : base(name, socialSecurityNumber)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
