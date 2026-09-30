using BE.services;
using Microsoft.AspNetCore.Mvc;
using BE.dtos.Room;

namespace BE.controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<List<RoomResponseDto>>> GetAllRoom()
        {
            var room = await _service.GetAllRoom();

            return Ok(room);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RoomResponseDto>> GetRoomById(int id)
        {
            var room = await _service.GetRoomById(id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }


        [HttpPost]
        public async Task<ActionResult<RoomResponseDto>> CreateRoom(CreateRoomDto dto)
        {
            var newroom = await _service.CreateRoom(dto);

            return Ok(newroom);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<RoomResponseDto>> UpdateRoom(int id, UpdateRoomDto dto)
        {
            var updateroom = await _service.UpdateRoom(id, dto);

            if (updateroom == null)
                return NotFound();

            return Ok(updateroom);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deleteroom = await _service.DeleteRoom(id);

            if (!deleteroom)
                return NotFound();

            return Ok(deleteroom);
        }
    }
}
