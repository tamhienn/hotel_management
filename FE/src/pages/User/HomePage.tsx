import { useEffect, useState } from "react";
import { getRooms } from "../../services/roomService";
import RoomCard from "../../components/Room/RoomCard/RoomCard";

type Room = {
    id: number;
    name: string;
    type: string;
    price: number;
    description: string;
    status: string;
};

function HomePage() {
    const [rooms, setRooms] = useState<Room[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        async function loadRooms() {
            try {
                const data = await getRooms();

                console.log("Dữ liệu nhận được:", data);

                setRooms(data);
            } catch (error) {
                console.error(error);
                setError("Không thể tải danh sách phòng");
            }
        }

        loadRooms();
    }, []);

    return (
        <div>
            <h1>Danh sách phòng</h1>

            {error && <p>{error}</p>}

            {rooms.length === 0 && !error && (
                <p>Đang tải dữ liệu...</p>
            )}

            {rooms.map((room) => (
                <RoomCard
                    key={room.id}
                    room={room}
                />
            ))}
        </div>
    );
}

export default HomePage;