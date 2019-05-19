namespace DemoApi.Services
{
    using System;
    using System.Collections.Generic;
    using DemoApi.Models;
    using Microsoft.Extensions.Logging;

    public class DemoService : IDemoService
    {
        private readonly ILogger<DemoService> _logger;
        private readonly Random _random = new Random();
        private readonly List<Rockstar> _rockstars;

        public DemoService(ILogger<DemoService> logger)
        {
            _logger = logger;

            // Create a simple in-memory data seed.
            _rockstars = new List<Rockstar>
            {
                new Rockstar("John", "1234567890", ".NET Developer"),
                new Rockstar("Peter", "6734345623", ".NET Developer"),
                new Rockstar("Luc", "3473475464", "Java Developer")
            };
        }

        public IEnumerable<Rockstar> GetAllRockstars()
        {
            return _rockstars;
        }

        public void MessageRockstar(Rockstar rockstar, string message)
        {
            _logger.LogDebug("Sending a message to {@rockstar}", rockstar);

            if (_random.Next(2) == 0)
            {
                throw new Exception("Woops.. random exception!");
            }
        }

        public Rockstar GetRandomRockstar()
        {
            return _rockstars[_random.Next(_rockstars.Count)];
        }
    }
}
