using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using gregslistmysql.Models;

namespace gregslistmysql.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Car Create(Car carData)
    {
      string sql = "INSERT INTO art (title, imgUrl, creatorId) values (@Title, @ImgUrl, @CreatorId); SELECT LAST_INSERT_ID();";
      carData.Id = _db.ExecuteScalar<int>(sql, carData);
      return carData;
    }

    internal List<Car> Get()
    {
      string sql = "SELECT c.*, act.* FROM car c JOIN accounts act ON c.creatorId = act.Id";
      return _db.Query<Car, Account, Car>(sql, (car, account) =>
      {
        car.Creator = account;
        return car;
      }).ToList();
    }
  }
}