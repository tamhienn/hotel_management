# Hotel Management Database Schema

Tài liệu này mô tả cấu trúc cơ sở dữ liệu trong file `hotel_management.sql` và các mối quan hệ chính giữa các bảng.

## 1. Thông tin chung

- Database: `thietkemoi`
- Hệ quản trị CSDL: Microsoft SQL Server
- Mục tiêu: quản lý khách sạn, phòng, đặt phòng, thanh toán, xác thực người dùng và đánh giá.

## 2. Danh sách bảng

### 2.1 `users`

Lưu trữ thông tin người dùng hệ thống.

Các cột chính:

- `id`: khóa chính
- `full_name`: họ tên
- `date_of_birth`: ngày sinh
- `gender`: giới tính
- `email`: email đăng nhập
- `phone_number`: số điện thoại
- `password_hash`: mật khẩu đã mã hóa
- `role`: vai trò (ví dụ: user, admin)
- `status`: trạng thái tài khoản
- `address`: địa chỉ
- `image_url`: ảnh đại diện
- `email_verified_at`: thời điểm xác minh email
- `created_at`, `updated_at`: thời gian tạo/cập nhật

Mục đích:

- Quản lý thông tin tài khoản người dùng.
- Dùng cho đăng nhập, phân quyền và lưu hồ sơ khách hàng/nhân viên.

### 2.2 `social_logins`

Lưu thông tin đăng nhập qua mạng xã hội hoặc phương thức bên thứ ba.

Các cột chính:

- `id`
- `user_id` : tham chiếu đến người dùng
- `provider`: nhà cung cấp đăng nhập (`Google`, `Facebook`, ...)
- `provider_user_id`: mã người dùng bên nhà cung cấp
- `created_at`

Mục đích:

- Hỗ trợ đăng nhập bằng tài khoản mạng xã hội.

### 2.3 `verification_codes`

Lưu mã xác thực email hoặc các thao tác bảo mật khác.

Các cột chính:

- `id`
- `user_id`
- `code`: mã xác thực
- `purpose`: mục đích xác thực
- `expires_at`: thời hạn
- `verified_at`: thời điểm xác nhận
- `created_at`

Mục đích:

- Xác nhận email, reset mật khẩu hoặc bảo mật tài khoản.

### 2.4 `room_types`

Lưu loại phòng của khách sạn.

Các cột chính:

- `id`
- `name`: tên loại phòng
- `description`: mô tả
- `capacity`: sức chứa
- `base_price`: giá gốc
- `image_url`: ảnh
- `status`: trạng thái
- `created_at`, `updated_at`

Mục đích:

- Phân loại phòng như Standard, Deluxe, Suite...

### 2.5 `rooms`

Lưu chi tiết từng phòng thực tế.

Các cột chính:

- `id`
- `room_type_id`: loại phòng
- `room_number`: số phòng
- `floor`: tầng
- `status`: trạng thái phòng (`available`, `occupied`, `maintenance`, ...)
- `description`: mô tả phòng
- `created_at`, `updated_at`

Mục đích:

- Quản lý trạng thái và vị trí từng phòng.

### 2.6 `bookings`

Lưu thông tin đặt phòng.

Các cột chính:

- `id`
- `booking_code`: mã đặt phòng duy nhất
- `user_id`: khách hàng đặt phòng
- `room_id`: phòng được đặt
- `booking_date`: ngày đặt
- `check_in`: ngày nhận phòng
- `check_out`: ngày trả phòng
- `adults`, `children`: số người lớn/trẻ em
- `total_amount`: tổng tiền
- `status`: trạng thái đặt phòng
- `special_request`: yêu cầu đặc biệt
- `created_at`, `updated_at`

Mục đích:

- Lưu toàn bộ dữ liệu đặt phòng từ đầu đến khi hoàn tất.

### 2.7 `check_ins`

Lưu thông tin check-in/check-out thực tế của đơn đặt phòng.

Các cột chính:

- `id`
- `booking_id`: tham chiếu đến đơn đặt phòng
- `actual_check_in`: thời gian nhận phòng thực tế
- `actual_check_out`: thời gian trả phòng thực tế
- `check_in_by`: người nhận phòng
- `check_out_by`: người xử lý trả phòng
- `status`: trạng thái check-in
- `created_at`, `updated_at`

Mục đích:

- Theo dõi quá trình vào/ra phòng thực tế.

### 2.8 `bank_accounts`

Lưu thông tin tài khoản ngân hàng dùng cho thanh toán hoặc chuyển khoản.

Các cột chính:

- `id`
- `bank_name`: tên ngân hàng
- `account_name`: tên chủ tài khoản
- `account_number`: số tài khoản
- `branch`: chi nhánh
- `qr_code_url`: link mã QR
- `is_active`: trạng thái kích hoạt
- `created_at`, `updated_at`

Mục đích:

- Hỗ trợ thanh toán và hiển thị thông tin ngân hàng cho khách.

### 2.9 `payments`

Lưu thông tin thanh toán của từng booking.

Các cột chính:

- `id`
- `booking_id`
- `amount`: số tiền thanh toán
- `payment_type`: loại thanh toán
- `payment_method`: phương thức thanh toán
- `payment_status`: trạng thái thanh toán
- `transaction_code`: mã giao dịch duy nhất
- `card_brand`, `card_last4`, `card_expiry_month`, `card_expiry_year`: thông tin thẻ
- `payer_bank_name`
- `payer_account_last4`
- `bank_account_id`
- `expires_at`
- `paid_at`
- `created_at`, `updated_at`

Mục đích:

- Quản lý thanh toán, giao dịch, và trạng thái nợ/đã thanh toán.

### 2.10 `reviews`

Lưu đánh giá của khách sau khi sử dụng dịch vụ.

Các cột chính:

- `id`
- `booking_id`
- `rating`: số sao đánh giá
- `comment`: nhận xét
- `status`: trạng thái đánh giá
- `created_at`, `updated_at`

Mục đích:

- Theo dõi phản hồi từ khách hàng và hiển thị rating cho phòng/dịch vụ.

## 3. Mối quan hệ giữa các bảng

- `users` 1 - n `bookings`
- `rooms` n - 1 `room_types`
- `rooms` 1 - n `bookings`
- `bookings` 1 - 1 `check_ins`
- `bookings` 1 - n `payments`
- `bookings` 1 - n `reviews`
- `users` 1 - n `social_logins`
- `users` 1 - n `verification_codes`

## 4. Luồng nghiệp vụ điển hình

1. Người dùng đăng ký / đăng nhập tài khoản.
2. Hệ thống tạo mã xác thực nếu cần xác nhận email.
3. Khách đặt phòng bằng `bookings`.
4. Hệ thống kiểm tra phòng và trạng thái đặt chỗ.
5. Khách nhận phòng -> lưu thông tin vào `check_ins`.
6. Khách thanh toán -> lưu vào `payments`.
7. Sau khi trải nghiệm, khách có thể đánh giá -> lưu vào `reviews`.

## 5. Các ràng buộc đặc biệt

- `bookings.booking_code` là duy nhất.
- Mỗi booking chỉ có tối đa một bản ghi trong `check_ins`.
- `payments.transaction_code` là duy nhất.
- Một số trường như `status`, `role`, `payment_status` nên được chuẩn hóa theo enum/lookup nếu hệ thống mở rộng.

## 6. Gợi ý khi làm việc với schema

- Khi truy vấn đặt phòng, ưu tiên join giữa `bookings` và `rooms`, `users`, `room_types`.
- Khi làm màn hình thanh toán, kiểm tra `payments` và `bank_accounts` trước.
- Khi phát triển UI, nên map các trạng thái (`status`) thành enum hoặc constant trên frontend/backend.

## 7. Kết luận

Database này tập trung vào hệ thống đặt phòng khách sạn với các chức năng chính:

- quản lý người dùng
- quản lý phòng và loại phòng
- đặt phòng
- check-in/check-out
- thanh toán
- đánh giá khách hàng


