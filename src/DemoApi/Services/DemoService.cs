using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DemoApi.Services
{
    using DemoApi.Models;

    public class DemoService : IDemoService
    {
        private readonly ILogger<DemoService> _logger;

        private List<Rockstar> _rockstars;

        private readonly Random _random = new Random();

        public DemoService(ILogger<DemoService> logger)
        {
            _logger = logger;

            _rockstars = new List<Rockstar>()
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
