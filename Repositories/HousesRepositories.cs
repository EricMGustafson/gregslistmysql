using System.Data;

namespace gregslistmysql.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}