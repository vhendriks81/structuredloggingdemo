namespace DemoApi.Models
{
    using System;
    using Destructurama.Attributed;

    public class Person
    {
        public Person(string name, string socialSecurityNumber)
        {
            Name = name;
            Id = Guid.NewGuid();
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Guid Id { get; }

        [NotLogged]
        public string Name { get; }

        [LogMasked(ShowFirst = 3)]
        public string SocialSecurityNumber { get; }
    }
}
