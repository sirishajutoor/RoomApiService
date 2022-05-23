using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomService.Models;
using RoomService.Repository;

namespace RoomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public IActionResult Get()
        {
            List<Room> rooms = RoomRepository.GetRooms();


            return Ok(rooms);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            
            var room = rooms.SingleOrDefault(x => x.RoomId == id);
            if (room == null)
            {
                return NotFound("No room Found");
            }
            return Ok(room);
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            rooms.Add(room);
            if (rooms.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(rooms);
        }
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var room = rooms.SingleOrDefault(x => x.RoomId == id);
            if (room == null)
            {
                return NotFound("No room Found");
            }
            rooms.Remove(  room);
            if (rooms.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(rooms);
        }
    }
}
