# PROJECT2_NHOM5 🎬

*"Transforming Entertainment, Empowering Every Viewer Experience"*

## 📋 Tổng quan

**PROJECT2_NHOM5** là một hệ thống đặt vé xem phim trực tuyến được phát triển bằng ASP.NET Core MVC, cung cấp trải nghiệm đặt vé mượt mà và quản lý rạp chiếu phim hiện đại.

## 🚀 Tính năng chính

### 👥 Dành cho Khách hàng (Guest)
- **Đăng ký & Đăng nhập**: Hệ thống xác thực an toàn
- **Tìm kiếm phim**: Lọc theo thể loại, trạng thái, từ khóa
- **Chọn ghế**: Giao diện trực quan để chọn ghế trong rạp
- **Đặt vé**: Quy trình đặt vé đơn giản và nhanh chóng
- **Thanh toán**: Hỗ trợ nhiều phương thức thanh toán
- **Mã giảm giá**: Áp dụng mã giảm giá cho đơn hàng
- **Quản lý vé**: Xem lịch sử đặt vé và trạng thái thanh toán

### 🔧 Dành cho Quản trị viên (Admin)
- **Quản lý phim**: Thêm, sửa, xóa thông tin phim
- **Quản lý rạp**: Cấu hình rạp chiếu và ghế ngồi
- **Quản lý suất chiếu**: Tạo lịch chiếu phim
- **Quản lý vé**: Theo dõi và quản lý vé đã bán
- **Quản lý thanh toán**: Xem lịch sử giao dịch
- **Quản lý mã giảm giá**: Tạo và quản lý mã giảm giá
- **Thống kê doanh thu**: Báo cáo doanh thu chi tiết
- **Quản lý người dùng**: Quản lý tài khoản khách hàng

## 🛠️ Công nghệ sử dụng

### Backend
- **ASP.NET Core 8.0** - Framework web hiện đại
- **Entity Framework Core** - ORM cho database
- **SQL Server** - Hệ quản trị cơ sở dữ liệu
- **C#** - Ngôn ngữ lập trình chính

### Frontend
- **HTML5 & CSS3** - Cấu trúc và styling
- **Bootstrap 5** - Framework CSS responsive
- **JavaScript** - Tương tác phía client
- **jQuery** - Thư viện JavaScript

### Tools & Libraries
- **NuGet** - Quản lý packages
- **Git** - Version control
- **JSON** - Định dạng dữ liệu
- **Markdown** - Documentation

## 📁 Cấu trúc dự án

```
Project2_Nhom5/
├── 📁 Areas/                          # Khu vực chức năng
│   ├── 📁 Admin/                       # Khu vực quản trị
│   │   ├── 📄 AdminAreaRegistration.cs # Đăng ký area admin
│   │   ├── 📁 Controllers/             # Controllers cho admin (11 files)
│   │   │   ├── AuthController.cs       # Xác thực admin
│   │   │   ├── DiscountsController.cs  # Quản lý mã giảm giá
│   │   │   ├── HomeController.cs       # Dashboard admin
│   │   │   ├── MoviesController.cs     # Quản lý phim
│   │   │   ├── PaymentsController.cs   # Quản lý thanh toán
│   │   │   ├── RevenuesController.cs   # Quản lý doanh thu
│   │   │   ├── SeatsController.cs      # Quản lý ghế ngồi
│   │   │   ├── ShowtimesController.cs  # Quản lý suất chiếu
│   │   │   ├── TheatersController.cs   # Quản lý rạp chiếu
│   │   │   ├── TicketsController.cs   # Quản lý vé
│   │   │   └── UsersController.cs      # Quản lý người dùng
│   │   ├── 📁 Models/                  # Models cho admin
│   │   │   └── BulkSeatCreateModel.cs  # Model tạo ghế hàng loạt
│   │   └── 📁 Views/                   # Views cho admin (50+ files)
│   │       ├── 📁 Auth/                # Views đăng nhập
│   │       ├── 📁 Discounts/           # Views mã giảm giá
│   │       ├── 📁 Home/                # Views dashboard
│   │       ├── 📁 Movies/              # Views quản lý phim
│   │       ├── 📁 Payments/            # Views thanh toán
│   │       ├── 📁 Revenues/            # Views doanh thu
│   │       ├── 📁 Seats/               # Views ghế ngồi
│   │       ├── 📁 Showtimes/           # Views suất chiếu
│   │       ├── 📁 Theaters/            # Views rạp chiếu
│   │       ├── 📁 Tickets/             # Views vé
│   │       ├── 📁 Users/               # Views người dùng
│   │       └── 📁 Shared/              # Views chung
│   └── 📁 Guest/                       # Khu vực khách hàng
│       ├── 📁 Controllers/             # Controllers cho guest (5 files)
│       │   ├── BookingController.cs    # Đặt vé và thanh toán
│       │   ├── HomeController.cs       # Trang chủ guest
│       │   ├── MoviesController.cs     # Xem phim
│       │   ├── ShowtimesController.cs  # Xem suất chiếu
│       │   └── TheatersController.cs   # Xem rạp chiếu
│       ├── 📁 Models/                  # Models cho guest (5 files)
│       │   ├── BookingModels.cs        # Models đặt vé
│       │   ├── GuestHomeViewModel.cs   # ViewModel trang chủ
│       │   ├── LoginViewModel.cs       # Model đăng nhập
│       │   ├── PendingPaymentViewModel.cs # Model thanh toán chờ
│       │   └── RegisterViewModel.cs    # Model đăng ký
│       └── 📁 Views/                   # Views cho guest (15+ files)
│           ├── 📁 Booking/             # Views đặt vé
│           ├── 📁 Home/                 # Views trang chủ
│           ├── 📁 Movies/              # Views phim
│           ├── 📁 Showtimes/           # Views suất chiếu
│           └── 📁 Theaters/            # Views rạp chiếu
├── 📁 Controllers/                     # Controllers chính
│   └── HomeController.cs               # Controller trang chủ chính
├── 📁 Data/                            # Database scripts
│   ├── fix_seat_data.sql               # Script sửa dữ liệu ghế
│   └── sample_data.sql                 # Dữ liệu mẫu
├── 📁 Migrations/                      # Entity Framework migrations
├── 📁 ModelBinders/                    # Custom model binders (5 files)
│   ├── DateOnlyJsonConverter.cs        # Converter DateOnly
│   ├── DateOnlyModelBinder.cs          # Model binder DateOnly
│   ├── DateOnlyTimeOnlyModelBinderProvider.cs # Provider binders
│   ├── TimeOnlyJsonConverter.cs        # Converter TimeOnly
│   └── TimeOnlyModelBinder.cs          # Model binder TimeOnly
├── 📁 Models/                          # Data models (11 files)
│   ├── Discount.cs                     # Model mã giảm giá
│   ├── ErrorViewModel.cs               # Model lỗi
│   ├── Movie.cs                        # Model phim
│   ├── Payment.cs                      # Model thanh toán
│   ├── Project2_Nhom5Context.cs       # DbContext chính
│   ├── Revenue.cs                      # Model doanh thu
│   ├── Seat.cs                         # Model ghế ngồi
│   ├── Showtime.cs                     # Model suất chiếu
│   ├── Theater.cs                      # Model rạp chiếu
│   ├── Ticket.cs                       # Model vé
│   └── User.cs                         # Model người dùng
├── 📁 Services/                        # Business logic services (3 files)
│   ├── AuthService.cs                  # Service xác thực
│   ├── PaymentService.cs               # Service thanh toán
│   └── RevenueService.cs               # Service doanh thu
├── 📁 Scripts/                         # Scripts tùy chỉnh
├── 📁 Views/                           # Shared views (6 files)
│   ├── 📁 Home/                        # Views trang chủ
│   └── 📁 Shared/                      # Views chung
│       ├── _Layout.cshtml              # Layout chính
│       ├── _Layout.cshtml.css          # CSS layout
│       ├── _Navbar.cshtml              # Navigation bar
│       ├── _ValidationScriptsPartial.cshtml # Scripts validation
│       └── Error.cshtml                # View lỗi
├── 📁 wwwroot/                         # Static files
│   ├── 📁 css/                         # Stylesheets (3 files)
│   │   ├── icon-fixes.css              # CSS sửa icon
│   │   ├── perfect-icon-center.css     # CSS căn giữa icon
│   │   └── site.css                    # CSS chính
│   ├── 📁 img/                         # Images (20+ files)
│   │   ├── hero-cinema.jpg             # Ảnh hero
│   │   └── poster_*.jpg/webp           # Posters phim
│   ├── 📁 js/                          # JavaScript files (2 files)
│   │   ├── form-login.js               # JS form đăng nhập
│   │   └── site.js                     # JS chính
│   └── 📁 lib/                         # Third-party libraries
│       ├── 📁 bootstrap/               # Bootstrap framework
│       ├── 📁 jquery/                  # jQuery library
│       ├── 📁 jquery-validation/       # jQuery validation
│       └── 📁 jquery-validation-unobtrusive/ # Unobtrusive validation
├── 📄 Program.cs                       # Entry point ứng dụng
├── 📄 Project2_Nhom5.csproj           # Project file
├── 📄 appsettings.json                 # Cấu hình ứng dụng
├── 📄 appsettings.Development.json    # Cấu hình development
└── 📄 Project2_Nhom5.sln              # Solution file
```

## 🗄️ Cơ sở dữ liệu

### Các bảng chính:
- **Phim** - Thông tin phim
- **Rap** - Thông tin rạp chiếu
- **SuatChieu** - Lịch chiếu phim
- **Ghe** - Thông tin ghế ngồi
- **Ve** - Vé đã đặt
- **ThanhToan** - Lịch sử thanh toán
- **NguoiDung** - Thông tin người dùng
- **MaGiamGia** - Mã giảm giá
- **DoanhThu** - Báo cáo doanh thu

## ⚙️ Cài đặt và chạy dự án

### Yêu cầu hệ thống:
- .NET 8.0 SDK
- SQL Server (LocalDB hoặc SQL Server Express)
- Visual Studio 2022 hoặc VS Code

### Các bước cài đặt:

1. **Clone repository:**
```bash
git clone <repository-url>
cd Project2_Nhom5
```

2. **Cài đặt dependencies:**
```bash
dotnet restore
```

3. **Cấu hình database:**
- Cập nhật connection string trong `appsettings.json`
- Chạy migration để tạo database:
```bash
dotnet ef database update
```

4. **Chạy ứng dụng:**
```bash
dotnet run
```

5. **Truy cập ứng dụng:**
- Khách hàng: `https://localhost:7295`
- Admin: `https://localhost:7295/Admin`

## 🔐 Tài khoản mặc định

### Admin:
- **Username:** `quangtam`
- **Password:** `password1`

### Khách hàng:
- Đăng ký tài khoản mới hoặc sử dụng tài khoản có sẵn

## 📱 Giao diện người dùng

### Trang chủ khách hàng:
- Hiển thị danh sách phim đang chiếu
- Tìm kiếm và lọc phim
- Thông tin rạp chiếu

### Trang đặt vé:
- Chọn ghế trực quan
- Tính toán giá vé tự động
- Áp dụng mã giảm giá
- Thanh toán an toàn

### Dashboard Admin:
- Thống kê tổng quan
- Quản lý nội dung
- Báo cáo doanh thu

## 🔌 API Endpoints

### 👥 Guest APIs:
- `POST /Guest/Booking/CreatePendingTickets` - Tạo vé chờ thanh toán
- `POST /Guest/Booking/ProcessSelectedPayments` - Xử lý thanh toán
- `GET /Guest/Booking/GetSelectedTicketsInfo` - Lấy thông tin vé đã chọn
- `POST /Guest/Booking/ApplyDiscount` - Áp dụng mã giảm giá
- `DELETE /Guest/Booking/DeletePendingTickets` - Xóa vé chờ

### 🔧 Admin APIs:
- `GET /Admin/Movies` - Danh sách phim (có tìm kiếm)
- `POST /Admin/Movies/Create` - Tạo phim mới
- `PUT /Admin/Movies/Edit/{id}` - Cập nhật phim
- `DELETE /Admin/Movies/Delete/{id}` - Xóa phim
- `GET /Admin/Showtimes` - Quản lý suất chiếu
- `GET /Admin/Tickets` - Quản lý vé
- `GET /Admin/Payments` - Quản lý thanh toán
- `GET /Admin/Revenues` - Báo cáo doanh thu

### 📊 Dashboard APIs:
- `GET /Admin/Home/Index` - Thống kê tổng quan
- `GET /Guest/Home/Index` - Trang chủ khách hàng

## 🎨 Screenshots & Demo

### 🏠 Trang chủ khách hàng:
- Hiển thị danh sách phim đang chiếu
- Tìm kiếm và lọc theo thể loại
- Giao diện responsive, thân thiện

### 🎫 Quy trình đặt vé:
1. **Chọn phim** → Xem thông tin chi tiết
2. **Chọn suất chiếu** → Chọn ngày giờ phù hợp  
3. **Chọn ghế** → Giao diện trực quan
4. **Thanh toán** → Hỗ trợ nhiều phương thức
5. **Hoàn thành** → Nhận mã đặt vé

### 🔧 Dashboard Admin:
- **Thống kê tổng quan**: Số phim, rạp, vé, doanh thu
- **Quản lý nội dung**: CRUD operations cho tất cả entities
- **Báo cáo**: Doanh thu theo thời gian, phim, rạp
- **Quản lý người dùng**: Xem danh sách và thông tin khách hàng

## 🔧 Tính năng kỹ thuật

### 🔒 Bảo mật:
- **Xác thực người dùng**: Cookie-based authentication
- **Phân quyền truy cập**: Admin vs Guest areas
- **Bảo vệ CSRF**: Anti-forgery tokens
- **Validation dữ liệu**: Server-side và client-side
- **SQL Injection Protection**: Entity Framework parameterized queries

### ⚡ Performance:
- **Database Optimization**: Indexed queries, efficient joins
- **Lazy Loading**: Entity Framework lazy loading
- **Caching**: Static file caching
- **Compression**: Response compression
- **Async Operations**: Async/await pattern

### 📱 Responsive Design:
- **Mobile-first**: Bootstrap responsive grid
- **Cross-browser**: Chrome, Firefox, Safari, Edge
- **Touch-friendly**: Mobile navigation và interactions
- **Progressive Enhancement**: Graceful degradation

### 🏗️ Architecture:
- **MVC Pattern**: Clean separation of concerns
- **Repository Pattern**: Data access abstraction
- **Service Layer**: Business logic encapsulation
- **Dependency Injection**: Built-in DI container
- **Area-based Organization**: Modular structure

## 🐛 Xử lý lỗi

### Các lỗi đã được sửa:
- ✅ Lỗi tìm kiếm thể loại phim
- ✅ Lỗi hiển thị thống kê admin
- ✅ Lỗi tạo phim mới (truncation)
- ✅ Lỗi tính giá vé khi đặt nhiều vé

### Error Handling:
- Logging chi tiết
- Thông báo lỗi thân thiện
- Rollback transaction
- Validation dữ liệu

## 📊 Thống kê dự án

### 📈 Số liệu tự động:
- **📁 Tổng số files:** 183 files
- **💻 C# Code:** 6,897 dòng
- **🎨 Razor Views:** 20,038 dòng  
- **📱 Controllers:** 16 controllers
- **🗄️ Models:** 11 data models
- **🔧 Services:** 3 business services
- **🎬 Images:** 20+ poster phim
- **📚 Libraries:** Bootstrap, jQuery, Validation

### 🏗️ Kiến trúc:
- **Areas:** 2 (Admin + Guest)
- **Database Tables:** 9 bảng chính
- **Migrations:** Entity Framework migrations
- **Model Binders:** 5 custom binders
- **Static Assets:** CSS, JS, Images

### 🎯 Tính năng:
- **Admin Features:** 11 modules quản lý
- **Guest Features:** 5 modules khách hàng
- **Payment Methods:** Multiple options
- **Discount System:** Flexible pricing
- **Responsive Design:** Mobile-friendly

## 🤝 Đóng góp

1. Fork dự án
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📝 License

Dự án này được phát triển cho mục đích học tập và nghiên cứu.

## 👥 Nhóm phát triển

**Nhóm 5** - Dự án ASP.NET Core MVC

## 📞 Liên hệ

Nếu có thắc mắc hoặc góp ý, vui lòng tạo issue trên repository.

---

**Cảm ơn bạn đã quan tâm đến dự án! 🎬✨**
