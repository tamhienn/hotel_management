
type Room = {
    id: number;
    name: string;
    type: string;
    price: number;
    description: string;
    status: string;
};

type RoomCardProps = {
    room: Room;
};

function RoomCard({ room }: RoomCardProps) {
    return (
        <div className="room-card">

            {/* Hình ảnh phòng */}
            <div className="room-image">
                <span>Room Image</span>
            </div>

            {/* Thông tin phòng */}
            <div className="room-info">

                <h2>{room.name}</h2>

                <p className="room-type">
                    {room.type}
                </p>

                <p className="room-description">
                    {room.description}
                </p>

                {/* Giá + trạng thái */}
                <div className="room-bottom">

                    <span className="room-price">
                        {room.price.toLocaleString("vi-VN")} VNĐ
                    </span>

                    <span className="room-status">
                        {room.status}
                    </span>

                </div>

            </div>

        </div>
    );
}

export default RoomCard;