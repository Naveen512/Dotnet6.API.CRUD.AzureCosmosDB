using Dot6.API.CosmosDB.Demo.Models;

namespace Dot6.API.CosmosDB.Demo.Services;

public interface ICarCosmosService
{
    Task<List<Car>> Get(string sqlCosmosQuery);
    Task<Car> AddAsync(Car newCar);
    Task<Car> Update(Car carToUpdate);

    Task Delete(string id, string make);
}