using BE.Model;
using BE.Service;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService service;

        public RoomController(RoomService service)
        {
            this.service = service;
        }

        // GET: api/room
        // Lấy tất cả Room
        [HttpGet]
        public async Task<List<RoomModel>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        // GET: api/room/1
        // Lấy Room theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetByIdAsync(long id)
        {
            var room = await service.GetByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/room
        // Thêm Room
        [HttpPost]
        public async Task<ActionResult<RoomModel>> CreateAsync(RoomModel room)
        {
            var newRoom = await service.CreateAsync(room);

            return Ok(newRoom);
        }

        // PUT: api/room/1
        // Cập nhật Room
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomModel>> UpdateAsync(
            long id,
            RoomModel room)
        {
            var updatedRoom = await service.UpdateAsync(id, room);

            if (updatedRoom == null)
            {
                return NotFound();
            }

            return Ok(updatedRoom);
        }

        // DELETE: api/room/1
        // Xóa Room
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await service.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}