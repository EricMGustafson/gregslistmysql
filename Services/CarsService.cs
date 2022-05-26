using System;
using System.Collections.Generic;
using gregslistmysql.Models;
using gregslistmysql.Repositories;

namespace gregslistmysql.Services
{
  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    internal List<Car> Get()
    {
      return _repo.Get();
    }

    internal Car Get(string id)
    {
      throw new NotImplementedException();
    }

    internal Car Create(Car carData)
    {
      return _repo.Create(carData);
    }

    internal Car Edit(Car carData)
    {
      throw new NotImplementedException();
    }

    internal void Delete(string id)
    {
      throw new NotImplementedException();
    }
  }
}