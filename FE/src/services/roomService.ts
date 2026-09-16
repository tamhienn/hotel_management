const API_URL = "http://localhost:5154/api/room";

export async function getRooms() {
    const response = await fetch(API_URL);

    if (!response.ok) {
        throw new Error("Không thể lấy dữ liệu phòng");
    }

    return await response.json();
}