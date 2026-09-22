
// useState → lưu và cập nhật dữ liệu.
// useEffect → thực hiện công việc sau khi component render.
import { useEffect, useState } from "react";
import { getRooms } from "../../services/roomService";
import RoomCard from "../../components/Room/RoomCard/RoomCard";
import type { Room } from "../../type/room";
import { ButtonDefault } from "@/components/common/AppButton";
import { InputBasic} from "@/components/common/AppInput";
import { CardDemo} from "@/components/common/AppCard";
import { DialogDemo} from "@/components/common/AppModal";

function HomePage() {

  
  // Danh sách phòng
  // tạo một state có kiểu danh sách Room, ban đầu là mảng rỗng. 
  // rooms là giá trị hiện tại, còn setRooms là hàm dùng để cập nhật giá trị của rooms
  const [rooms, setRooms] = useState<Room[]>([]);


    // useEffect sẽ chạy đoạn code bên trong
    // sau khi HomePage render
  useEffect(() => {
    async function loadRooms() {
      // Gọi Backend để lấy danh sách phòng
      const data = await getRooms();

      // Lưu dữ liệu vào rooms
      setRooms(data);
    }
    // goi ham de code ben trong thuc su chay
    // neu khong co thi chi moi tao ham,chua chay
    loadRooms();
  }, []);

  return (
   <div>
    
      <h1>Danh sách phòng</h1>
      
      {/* map() dung de duyet phan tu va tao ra gia tri tuong ung */}
      {/* Hiển thị tất cả phòng */}
      {rooms.map((room) => (
      
      // key la ID nhan dien phan tu trong list
        <RoomCard key={room.id} _room={room} />
      ))}
      <CardDemo/>
      <InputBasic/>
      <DialogDemo/>
      <ButtonDefault />

      
    </div>

    
  );
}

export default HomePage;
