using System;
using System.Collections.Generic;
using gregslistmysql.Models;
using gregslistmysql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistmysql.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {
    private readonly HousesService _hs;
    public HousesController(HousesService hs)
    {
      _hs = hs;
    }
    [HttpGet]
    public ActionResult<List<House>> Get()
    {
      try
      {
        List<House> houses = _hs.Get();
        return Ok(houses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<List<House>> Get(string id)
    {
      try
      {
        House house = _hs.Get(id);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<House> Create([FromBody] House houseData)
    {
      try
      {
        House newHouse = _hs.Create(houseData);
        return Ok(newHouse);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<House> Edit(int id, [FromBody] House houseData)
    {
      try
      {
        houseData.Id = id;
        House updated = _hs.Edit(houseData);
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
        _hs.Delete(id);
        return Ok("Deleted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}