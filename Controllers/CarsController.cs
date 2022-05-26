using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using gregslistmysql.Models;
using gregslistmysql.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gregslistmysql.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<List<Car>> Get()
    {
      try
      {
        List<Car> cars = _cs.Get();
        return Ok(cars);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Car> Get(string id)
    {
      try
      {
        Car car = _cs.Get(id);
        return Ok(car);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    // [Authorize]
    public async Task<ActionResult<Car>> Create([FromBody] Car carData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        carData.CreatorId = userInfo.Id;
        Car car = _cs.Create(carData);
        return Ok(car);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Car> Edit(int id, [FromBody] Car carData)
    {
      try
      {
        carData.Id = id;
        Car updated = _cs.Edit(carData);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(string id)
    {
      try
      {
        _cs.Delete(id);
        return Ok("Deleted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}