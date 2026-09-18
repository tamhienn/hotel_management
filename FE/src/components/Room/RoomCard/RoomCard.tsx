import type { Room } from "../../../type/room";

// _room chính là prop mà HomePage truyền xuống cho RoomCard.
// _room property nhan data co typedata la Room
type RoomCardProps = {
  _room: Room;
};

// Component hiển thị một phòng
function RoomCard(_props: RoomCardProps) {
  // Lấy room từ props
  const room = _props._room;

  return (
    <div>
      <h2>{room.name}</h2>

      <p>Giá: {room.price} VNĐ</p>

      <p>mô tả : {room.description}</p>

      <p>Trạng thái: {room.status}</p>
    </div>
  );
}

export default RoomCard;
