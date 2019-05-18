namespace DemoApi.Services
{
    using System.Collections.Generic;
    using DemoApi.Models;

    public interface IDemoService
    {
        void MessageRockstar(Rockstar rockstar, string message);

        Rockstar GetRandomRockstar();

        IEnumerable<Rockstar> GetAllRockstars();
    }
}
