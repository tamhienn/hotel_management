using BE.Dto;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    // xác định đây là API Controller và bật các cơ chế hỗ trợ API.
    [ApiController]

    //  xác định URL để truy cập Controller.
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        // get
        [HttpGet]
        public async Task<ActionResult<List<RoomDto>>> GetAllAsync()
        {
            var rooms = await _service.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetByIdAsync(long id)
        {
            var room = await _service.GetByIdAsync(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        // post
        [HttpPost]
        public async Task<ActionResult<RoomDto>> CreateAsync(CreateRoomDto room)
        {
            var newRoom = await _service.CreateAsync(room);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newRoom.Id }, newRoom);
        }

        // put
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomDto>> UpdateAsync(long id, UpdateRoomDto room)
        {
            var updatedRoom = await _service.UpdateAsync(id, room);
            if (updatedRoom == null) return NotFound();
            return Ok(updatedRoom);
        }

        // delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
 