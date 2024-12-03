CREATE DATABASE Advice;

USE Advice;

CREATE TABLE ProductCategory (
    CategoryID INT IDENTITY PRIMARY KEY ,
    CategoryName NVARCHAR(50),
    Status BIT
);

CREATE TABLE Brand (
    BrandID INT IDENTITY PRIMARY KEY,
    BrandName NVARCHAR(50),
    Status BIT
);
select * from Emloyees
CREATE TABLE Product (
    ProductID INT IDENTITY PRIMARY KEY,
    ProductName NVARCHAR(100),
    Price DECIMAL(18, 2),
    Image NVARCHAR(255),
    Details NVARCHAR(255),
    Description NText,
    StockQuantity INT,
    CategoryID INT,
    BrandID INT,
    Discount INT,
	Evaluate float,
	TotalRatings INT DEFAULT 0 NOT NULL,
	SumRatings INT DEFAULT 0 NOT NULL,
	quantity_sold int,
    FOREIGN KEY (CategoryID) REFERENCES ProductCategory(CategoryID),
    FOREIGN KEY (BrandID) REFERENCES Brand(BrandID)
);


CREATE TABLE Image (
    ImageID INT IDENTITY PRIMARY KEY,
    ImageName NVARCHAR(255),
    ProductID INT,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

select * from OrderDetail

CREATE TABLE Account (
    AccountID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Password NVARCHAR(50),
    Address NVARCHAR(255),
    Gender BIT,
	Points int,
	Status bit,
	City nvarchar(100),
	PASSWORD_HASH nvarchar(256),
	PASSWORD_SALT NVARCHAR(50)
);
select * from Account

CREATE TABLE AccountCustomerRole (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50)
);

CREATE TABLE AccountCustomerPermission (
    AccountID INT,
    RoleID INT,
    PRIMARY KEY (AccountID, RoleID),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
    FOREIGN KEY (RoleID) REFERENCES AccountCustomerRole(RoleID)
);

Select * from Account

CREATE TABLE Orders (
    OrderID NVARCHAR(50) PRIMARY KEY,
    FullName NVARCHAR(100),
    Gender BIT,
    Address NVARCHAR(255),
	OrderTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(18, 2),
    Status int,
    PhoneNumber NVARCHAR(20),
	Note NTEXT,
	City nvarchar(100),
	AccountID int null,
	emloyee_id int,
	FOREIGN KEY (Status) REFERENCES StatusOrder(status_id),
	FOREIGN KEY (emloyee_id) REFERENCES Emloyees(emloyee_id)
);

create table StatusOrder(
	status_id int primary key,
	status_name nvarchar(100),
);

CREATE TABLE OrderDetail (
    OrderDetailID INT IDENTITY PRIMARY KEY,
    Quantity INT,
    UnitPrice DECIMAL(18, 2),
    OrderID NVARCHAR(50),
    ProductID INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

Create Table Emloyees(
	emloyee_id int identity primary key,
	emloyee_fullname nvarchar(100) not null,
	emloyee_email nvarchar(100) not null,
	emloyee_phone nvarchar(20) not null,
	PASSWORD_HASH nvarchar(256) not null,
	PASSWORD_SALT NVARCHAR(50) NOT NULL,
	emloyee_address nvarchar(1000) not null,
	emloyee_status bit,
	emloyee_date date
);



Create table AdminAdvice(
	ID_ADMIN INT IDENTITY PRIMARY KEY,
	FULLNAME NVARCHAR(100) NOT NULL,
    USERNAME NVARCHAR(100) UNIQUE NOT NULL,
    PASSWORD NVARCHAR(256) NOT NULL,
	EMAIL NVARCHAR(100),
	PHONE NVARCHAR(20),
)

CREATE TABLE AccountEmloyeeRole (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50)
);

CREATE TABLE AccountEmloyeePermission (
    EmloyeeID INT,
    RoleID INT,
    PRIMARY KEY (EmloyeeID, RoleID),
    FOREIGN KEY (EmloyeeID) REFERENCES Emloyees(emloyee_id),
    FOREIGN KEY (RoleID) REFERENCES AccountEmloyeeRole(RoleID)
);



CREATE TABLE OrderHistoriyProduct (
    HistoryID INT identity PRIMARY KEY,
    ProductID INT,
    Quantity INT,
    TotalAmount DECIMAL(18, 2),
    AccountID INT,
    OrderID NVARCHAR(50),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
);
select * from OrderHistoriyProduct 

Select * from AdminAdvice

--1: nam --0: nữ
Insert Into Account(FullName, Email, Password, Address, PhoneNumber, Gender) Values (N'Mai Chí Vĩnh', N'vinh123@gmail.com', N'123', N'Ba Tri', N'0394529044', 1)
Insert Into Account(FullName, Email, Password, Address, PhoneNumber, Gender) Values (N'Lê Phước Bình', N'binh123@gmail.com', N'123', N'Lấp Vò', N'0839350984', 1)

Insert into AdminAdvice(

Insert Into StatusOrder (status_id, status_name) values(1, N'Chờ xác nhận')
Insert Into StatusOrder (status_id, status_name) values(2, N'Đã xác nhận')
Insert Into StatusOrder (status_id, status_name) values(3, N'Đang chuẩn bị hàng')
Insert Into StatusOrder (status_id, status_name) values(4, N'Hàng đang được giao')
Insert Into StatusOrder (status_id, status_name) values(5, N'Hàng đã giao đến bạn')

Insert into AccountEmloyeeRole(RoleID, RoleName) values(3, N'Thêm sản phẩm')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(4, N'Sửa sản phẩm')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(5, N'Xóa sản phẩm')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(6, N'Thêm Thương Hiệu')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(7, N'Sửa Thương Hiệu')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(8, N'Xóa Thương Hiệu')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(9, N'Thêm Loại Sản Phẩm')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(10, N'Sửa Loại Sản Phẩm')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(11, N'Xóa Loại Sản Phẩm')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(12, N'Sửa Đơn Hàng')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(13, N'Xóa Đơn Hàng')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(14, N'Thêm Tài Khoản Nhân Viên')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(15, N'Sửa Tài Khoản Nhân Viên')
Insert into AccountEmloyeeRole(RoleID, RoleName) values(15, N'Xóa Tài Khoản Nhân Viên')

Insert Into ProductCategory(CategoryName, Status) Values (N'Mỏng nhẹ', 1)--1
Insert Into ProductCategory(CategoryName, Status) Values (N'Văn phòng', 1)--2
Insert Into ProductCategory(CategoryName, Status) Values (N'Gaming', 1)--3
Insert Into ProductCategory(CategoryName, Status) Values (N'MacBook', 1)--4
Insert Into ProductCategory(CategoryName, Status) Values (N'Cao cấp', 1)--5

Insert Into Brand(BrandName, Status) Values (N'Acer', 1) --1
Insert Into Brand(BrandName, Status) Values (N'Asus', 1)--2
Insert Into Brand(BrandName, Status) Values (N'Apple', 1)--3
Insert Into Brand(BrandName, Status) Values (N'Dell', 1)--4
Insert Into Brand(BrandName, Status) Values (N'Lenovo', 1)--5
Insert Into Brand(BrandName, Status) Values (N'HP', 1)--6
Insert Into Brand(BrandName, Status) Values (N'MSI', 1)--7

Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Macbook Air M3 15 2024', 31990000, N'Macbook Air M3 15 2024.jpg', N'M.HÌNH 13.6 ,Liquid Retina' + CHAR(13) + CHAR(10) + N'CPU Apple, M3' + CHAR(13) + CHAR(10) + N'RAM LPDDR4, 16 GB' + CHAR(13) + CHAR(10) + N'PIN 30 W', 
N'Macbook Air M3 15 2024 trợ thủ tuyệt vời cho công việc và giải trí của bạn đã lộ diện, MacBook Air M3 13 2024 lên kệ với sức mạnh tuyệt vời của chip xử lý M3 cao cấp. Sản phẩm cung cấp thời lượng pin lên đến 18 tiếng trải nghiệm. Phiên bản bạn đang theo dõi được trang bị tới 16GB RAM cùng bộ nhớ trong 512GB, đáp ứng linh hoạt nhu cầu trải nghiệm của bạn.', 20, 4, 3, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'HP 245 G10 R7- 7730U', 15790000, N'Laptop HP 245 G10 R7.jpg', N'M.HÌNH 14 inch, Anti-Glare' + CHAR(13) + CHAR(10) + N'CPU AMD, Ryzen 7 ' + CHAR(13) + CHAR(10) + N'RAM DDR4, 16 GB (1 thanh 16 GB) ' + CHAR(13) + CHAR(10) + N'PIN 41 Wh, 45 W', 
N'HP 245 G10 R7 không chỉ đơn thuần là một chiếc laptop mà còn là người bạn đồng hành lý tưởng cho dân văn phòng và học sinh, sinh viên. Được trang bị bộ vi xử lý AMD Ryzen 7 mạnh mẽ, thiết kế mỏng nhẹ và nhiều tính năng tiện ích, HP 245 G10 R7 mang đến hiệu suất vượt trội và trải nghiệm sử dụng mượt mà trong mọi tình huống. Dù bạn đang tìm kiếm một công cụ hỗ trợ đắc lực cho công việc hay một thiết bị giải trí di động, HP 245 G10 R7 chắc chắn sẽ làm bạn hài lòng với sự linh hoạt và hiệu quả mà nó mang lại.',25, 1, 6, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Acer Swift Go AI SFG14', 22790000, N'Laptop Acer Swift Go AI SFG14.jpg', N'M.HÌNH 14 inch, LED-backlit' + CHAR(13) + CHAR(10) + N'CPU Intel, Core Ultra 5' + CHAR(13) + CHAR(10) + N'RAM LPDDR5X, 16 GB (1 thanh 16 GB)' + CHAR(13) + CHAR(10) + N'PIN 65 Wh, 65 W',
N'Không chỉ mạnh mẽ và mỏng nhẹ, Acer Swift Go 14 AI SFG14-73-53X7 còn tạo nên tiêu chuẩn mới cho dòng laptop hiện đại với loạt tính năng AI tiên phong. Bộ vi xử lý Intel Core Ultra, chuẩn Intel Evo, màn hình 2.8K siêu nét cùng sự hỗ trợ từ trí tuệ nhân tạo AI sẽ giúp bạn có được những trải nghiệm làm việc hiệu quả nhất từ trước đến nay.',15, 1, 1, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Dell Inspiron N3520 i5', 16390000, N'Laptop Dell Inspiron N3520 i5.jpg', N'M.HÌNH 15.6, Anti-Glare LED-Blacklit' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i5, 1235U' + CHAR(13) + CHAR(10) + N'RAM DDR4, 16 GB' + CHAR(13) + CHAR(10) + N'PIN 41WHr', 
N'Một chiếc máy tính xách tay 15,6 inch có thiết kế tinh tế và đầy đủ các tính năng cần thiết giúp bạn kết nối suốt cả ngày. Màn hình 15,6 inch FHD (1920x1080) 120Hz Không cảm ứng Chống chói, WVA, Đèn nền LED, 250 nit, Viền hẹp. Bộ xử lý Intel Core i5-1235U thế hệ thứ 12 (Bộ nhớ đệm 12MB, lên đến 4,4 GHz, 10 lõi). Đồ họa Intel Iris Xe. Ổ đĩa thể rắn 512GB M.2 PCIe NVMe. Bộ nhớ 16 GB, (2x8 GB), DDR4, 2666 MHz.', 7, 2, 4, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Asus Vivobook X1404ZA-NK387W i3', 10090000, N'Laptop Asus Vivobook X1404ZA-NK387W i3.jpg', N'M.HÌNH 14 inch, FHD' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i3, 1215U' + CHAR(13) + CHAR(10) + N'RAM DDR4, 8 GB' + CHAR(13) + CHAR(10) + N'PIN 42 Wh, 45 W',
N'ASUS Vivobook 14 X1404ZA-NK387W sở hữu những tính năng khó tin trong tầm giá 10 triệu đồng. Ngoài cấu hình miễn chê với bộ vi xử lý Intel thế hệ thứ 12, laptop còn có thiết kế mỏng nhẹ thời trang, màn hình Full HD và nhiều điều thú vị khác.',30, 2, 2, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Lenovo IdeaPad Slim 5 14Q8X9 X1P-42-100', 23490000, N'Laptop Lenovo IdeaPad Slim 5 14Q8X9 X1P-42-100.png', N'M.HÌNH 14 inch, OLED' + CHAR(13) + CHAR(10) + N'CPU Qualcomm, Snapdragon X Plus' + CHAR(13) + CHAR(10) + N'RAM LPDDR5X, 16 GB' + CHAR(13) + CHAR(10) + N'PIN 57 Wh, 65 W', 
N'Laptop Lenovo IdeaPad Slim 5 14Q8X9 83HL000KVN là một sản phẩm cao cấp được thiết kế với hiệu suất vượt trội và tính linh hoạt, hướng đến người dùng cần một thiết bị mỏng nhẹ, mạnh mẽ và đáp ứng đầy đủ các nhu cầu công việc lẫn giải trí. Với vi xử lý Snapdragon X Plus tiên tiến, màn hình OLED sắc nét và nhiều tính năng hiện đại, chiếc laptop này là sự lựa chọn lý tưởng cho những ai luôn di chuyển và cần sự bền bỉ.', 35, 1,5,5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'HP ProBook 440 G10 i7-1360P', 25190000, N'Laptop HP ProBook 440 G10 i7-1360P.png', N'M.HÌNH 14 inch, Anti-Glare' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i7' + CHAR(13) + CHAR(10) + N'RAM DDR4, 16 GB' + CHAR(13) + CHAR(10) + N'PIN 51 WHrs, 65 W',
N'HP ProBook 440 G10 là một lựa chọn tuyệt vời cho người dùng doanh nghiệp khi chiếc laptop này trang bị bộ vi xử lý Intel Core i7 1360P siêu mạnh, màn hình cảm ứng rõ nét, thiết kế gọn nhẹ và khả năng bảo mật bằng AI.',10, 1, 6, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'HP 15 fd0234TU i5 1334U', 16290000, N'Laptop HP 15 fd0234TU i5 1334U.jpg', N'M.HÌNH 15.6", Full HD' + CHAR(13) + CHAR(10) + N'CPU Intel Core i5 Raptor Lake' + CHAR(13) + CHAR(10) + N'RAM DDR4 2 khe' + CHAR(13) + CHAR(10) + N'PIN 3-cell, 41Wh',
N'Với lớp vỏ màu bạc tự nhiên sang trọng, Laptop HP 15 fd0234TU kết hợp hài hòa giữa vẻ đẹp hiện đại và tính năng công nghệ cao. Kích thước lý tưởng 35.98 x 23.6 x 1.86 cm và trọng lượng nhẹ chỉ 1.59 kg mang đến sự di động hoàn hảo, cho phép bạn dễ dàng mang theo từ văn phòng đến quán cà phê hay trong các chuyến công tác quốc tế.',30, 2, 6, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Lenovo Ideapad Slim 3 15IAH8 i5 12450H', 14290000, N'Lenovo Ideapad Slim 3 15IAH8 i5 12450H.jpg', N'M.HÌNH 15.6", Full HD' + CHAR(13) + CHAR(10) + N'CPU Intel Core i5 Alder Lake' + CHAR(13) + CHAR(10) + N'RAM LPDDR5 (Onboard)' + CHAR(13) + CHAR(10) + N'PIN 47 Wh, 65 W',
N'Laptop Lenovo IdeaPad Slim 3 15IAH8-83ER000BVN sở hữu cấu hình phần cứng mạnh mẽ vượt trội. Hiệu năng xử lý từ chip Intel Core i5-12450H hàng đầu thị trường. Màn hình 15.6 inch thoải mái trải nghiệm giải trí và học tập. Dung lượng bộ nhớ khủng tới 512GB thoải mái lưu trữ. Đây chính là mẫu laptop văn phòng phù hợp để bạn rinh về.',30, 2, 5, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Acer Aspire 3 A315 58 529V i5', 9990000, N'Acer Aspire 3 A315 58 529V i5.jpg', N'M.HÌNH 15.6", Full HD' + CHAR(13) + CHAR(10) + N'CPU Intel Core i5 Tiger Lake	' + CHAR(13) + CHAR(10) + N'RAM DDR4 (Onboard)' + CHAR(13) + CHAR(10) + N'PIN 2-cell, 36.7Wh',N'Laptop Acer Aspire 3 A315-58-529V NX.ADDSV.00N sẽ giúp cho việc học tập và làm việc của bạn trở nên dễ dàng hơn. Máy sở hữu ngoại hình mỏng nhẹ nhưng lại có khả năng xử lý ấn tượng từ chip Intel cùng dung lượng bộ nhớ cao.',20, 2, 1, 5) 
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values (N'MSI Modern 15 B12MO i5', 12490000, N'MSI Modern 15 B12MO i5.jpg', N'M.HÌNH 15.6", Full HD' + CHAR(13) + CHAR(10) + N'CPU Intel Core i5 Alder Lake' + CHAR(13) + CHAR(10) + N'RAM DDR4 (Onboard), 16GB' + CHAR(13) + CHAR(10) + N'PIN 3-Cell, 39.3 Wh', 
N'Laptop MSI Modern 15 B12MO-628VN có thông số rất toàn diện, giúp cho người dùng học tập và làm việc hiệu quả. Đặc biệt, đây là chiếc laptop MSI Modern được nâng cấp toàn diện so với thế hệ tiền nhiệm. ', 24, 2, 7, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'MacBook Air 13 inch M1 2020', 28490000, N'MacBook Air 13 inch M1 2020.jpg', N'M.HÌNH 13.3", IPS LCD LED Backlit' + CHAR(13) + CHAR(10) + N'CPU Apple, M1' + CHAR(13) + CHAR(10) + N'RAM LPDDR4, 16GB' + CHAR(13) + CHAR(10) + N'PIN Lithium polymer, 18 Giờ', 
N'MacBook Air 13 M1 có khả năng đồ họa khó tin trên một chiếc laptop siêu nhỏ gọn. GPU tích hợp trên Apple M1 có tới 8 nhân và là GPU tích hợp mạnh nhất thế giới laptop hiện nay. So với thế hệ trước, MacBook Air 13 2020 M1 có khả năng xử lý đồ họa mạnh gấp 5 lần. Giờ đây ngay trên chiếc MacBook Air cực kỳ di động, bạn đã có thể xem và chỉnh sửa video 4K mượt mà, thậm chí là chơi game cũng như chạy các tác vụ đồ họa chuyên sâu.', 30, 4, 3, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'MacBook Air 15 inch M2 2023', 27490000, N'MacBook Air 15 inch M2 2023.jpg', N'M.HÌNH 15.3", Liquid Retina' + CHAR(13) + CHAR(10) + N'CPU Apple, M2' + CHAR(13) + CHAR(10) + N'RAM 8 GB' + CHAR(13) + CHAR(10) + N'PIN Lithium polymer, 18 Giờ', 
N'MacBook Air M2 2023 giờ đây sẽ mở ra trải nghiệm hình ảnh rộng lớn hơn khi gia tăng kích cỡ màn hình Liquid Retina lên ngưỡng 15 inch ấn tượng. Độ tương thích tuyệt đối giữa chip M2 và nền tảng macOS đem lại trải nghiệm mượt mà và chuyên nghiệp nhất, giúp phản hồi cực nhanh mọi tác vụ của bạn.', 35, 4, 3, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Macbook Air M2 13 inch 2022', 34990000, N'Macbook Air M2 13 inch 2022.jpg', N'13.6", Liquid Retina FHD webcam' + CHAR(13) + CHAR(10) + N'CPU Apple M2' + CHAR(13) + CHAR(10) + N'RAM 16GB, 512GB SSD' + CHAR(13) + CHAR(10) + N'PIN 53 Wh', 
N'MacBook Air M2 2022 13 inch (16GB/512GB SSD) là chiếc MacBook đến từ thương hiệu Apple - một trong những nhà sản xuất nổi tiếng với sự đẳng cấp trong thế giới công nghệ. MacBook Air M2 2022 13 inch mang đến hiệu suất vượt trội và thiết kế sang trọng, luôn sẵn sàng chinh phục bất kỳ người dùng nào đang tìm kiếm một sản phẩm đẳng cấp để làm việc hiệu năng cao. ', 10, 5, 3, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Apple MacBook Pro 16 inch M3 Max', 109990000, N'Apple MacBook Pro 16 inch M3 Max.jpg', N'M.HÌNH 16.2", XDR' + CHAR(13) + CHAR(10) + N'CPU Apple M3 , 400GB/s' + CHAR(13) + CHAR(10) + N'RAM 96 GB , 1 TB SSD' + CHAR(13) + CHAR(10) + N'PIN 22 , 140 W', 
N'Máy tính xách tay Apple MacBook Pro 16 inch M3 Max với CPU 14 lõi, GPU 30 lõi: Được xây dựng cho Apple Intelligence, Màn hình Liquid Retina XDR 16,2 inch, Bộ nhớ hợp nhất 96 GB, Bộ nhớ SSD 1 TB; Màu đen không gian', 5, 5, 3, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'MacBook Pro 16 inch M2 Max 2023', 75990000, N'MacBook Pro 16 inch M2 Max 2023.jpg', N'M.HÌNH 16.2", Retina' + CHAR(13) + CHAR(10) + N'CPU Apple, M2 Max' + CHAR(13) + CHAR(10) + N'RAM 32 GB' + CHAR(13) + CHAR(10) + N'PIN Lithium polymer, 22 Giờ', 
N'Phiên bản dành cho những ai kiếm tìm sức mạnh tối thượng trên thế hệ MacBook mới nhất. Sự kết hợp giữa chip M2 Max cực mạnh với 32GB RAM và ổ cứng 1TB SSD sẽ làm hài lòng những người dùng khó tính nhất. Mọi tác vụ nặng đều được giải quyết trong nháy mắt và tái hiện trên màn hình Liquid Retina XDR đỉnh cao.', 15, 5, 3, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Dell XPS 14 9440 U7', 74990000, N'Dell XPS 14 9440 U7.jpg', N'M.HÌNH 14.5", Anti-Glare' + CHAR(13) + CHAR(10) + N'CPU Intel, Ultra 7' + CHAR(13) + CHAR(10) + N'RAM 64 GB (2 thanh 32 GB)' + CHAR(13) + CHAR(10) + N'Ổ CỨNG , M.2 NVMe', 
N'Tinh tế và toát lên phong thái doanh nhân, Dell XPS 14 9440 U7 155H là mẫu laptop đẳng cấp dành cho những người dùng chuyên nghiệp. Nét đẹp tối giản với lối thiết kế thanh thoát kết hợp cùng cấu hình mạnh mẽ mà chip Intel Core Ultra 7 đem lại có thể làm hài lòng những người dùng khó tính nhất.', 25, 5, 4, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Acer Gaming Predator Helios Neo 14 PHN14-51-99Y8', 46890000, N'Acer Gaming Predator Helios Neo 14 PHN14-51-99Y8.png', N'M.HÌNH 14.5", LED-backlit' + CHAR(13) + CHAR(10) + N'CPU Intel, Core Ultra 9' + CHAR(13) + CHAR(10) + N'RAM LPDDR5X, 32 GB' + CHAR(13) + CHAR(10) + N'Ổ CỨNG SSD, 1 M.2 NVMe', 
N'Acer Predator Helios Neo 14 PHN14-51-99Y8 là siêu phẩm Predator Gaming mới nhất với sự xuất hiện của AI, trang bị bộ vi xử lý Intel Core Ultra 9 và card đồ họa RTX 4060 cực khủng nhưng vẫn vô cùng nhỏ gọn với màn hình 14,5 inch và trọng lượng nhẹ bất ngờ chỉ 1,9kg.', 25, 5, 1, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Lenovo Gaming Legion 9 16IRX8 i9 13980HX', 128990000, N'Laptop Lenovo Gaming Legion 9 16IRX8 i9 13980HX.png', N'M.HÌNH 16", Anti-Glare' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i9' + CHAR(13) + CHAR(10) + N'RAM DDR5, 64 GB' + CHAR(13) + CHAR(10) + N'PIN 99.9 Wh', 
N'Lenovo Legion 9 16IRX8 mang sứ mệnh thay đổi toàn bộ ngành công nghiệp chơi game di động với công nghệ làm mát chất lỏng mang tính cách mạng, các tính năng AI và hiệu năng đỉnh nhất từ RTX 4090. Legion 8 cũng không kém phần phong cách với thiết kế Carbon đặc biệt và màn hình Mini-Led trải nghiệm khó quên.', 12, 5, 5, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'MSI Gaming Vector GP78HX 13VI-476VN i9-13980HX', 89990000, N'MSI Gaming Vector GP78HX 13VI-476VN i9-13980HX.jpg', N'M.HÌNH 17", QHD+' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i9, 13980HX' + CHAR(13) + CHAR(10) + N'CART NVIDIA GeForce RTX 4090 16GB GDDR6' + CHAR(13) + CHAR(10) + N'RAM DDR5, 32 GB' + CHAR(13) + CHAR(10) + N'PIN 90 WHrs' , 
N'Chiếc máy tính mạnh mẽ, thông minh và phong cách hàng đầu hiện tại, MSI Gaming Vector GP78 HX 13VI-476VN đại diện cho sự sáng tạo cùng khả năng làm việc, chơi game không giới hạn. Bạn hãy tự do với những ý tưởng đột phá, MSI Gaming Vector GP78 HX 13VI-476VN sẽ nhanh chóng biến chúng thành hiện thực.', 3, 5, 7, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Acer Aspire Lite AL16-51P-55N7 i5 1235U', 14990000, N'Laptop Acer Aspire Lite AL16-51P-55N7 i5 1235U.png', N'M.HÌNH 16", Anti-glare LED-backlit' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i5, 1235U' + CHAR(13) + CHAR(10) + N'RAM DDR5, 16GB' + CHAR(13) + CHAR(10) + N'RPIN Li-ion, 76 Whr', 
N'Acer Aspire Lite AL16-51P-55N7 là chiếc laptop văn phòng thế hệ mới được Acer trình làng đầu năm 2024. Sở hữu cấu hình với sự góp mặt của chipset Intel Core i5 1235U, 16GB RAM, ổ cứng SSD 512GB và màn hình 16 inch siêu sắc nét, đây sẽ là lựa chọn lý tưởng hàng đầu cho những người đang tìm kiếm chiếc laptop mạnh mẽ ở phân khúc tầm trung.', 13, 2, 1, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Dell Latitude 3440 i5-1235U', 20490000, N'Dell Latitude 3440 i5-1235U.jpg', N'M.HÌNH 14.1", LCD, FHD' + CHAR(13) + CHAR(10) + N'CPU Intel, Core i5, 1235U' + CHAR(13) + CHAR(10) + N'RAM DDR4, 16 GB' + CHAR(13) + CHAR(10) + N'CART Intel Iris Xe Graphics G7 80EUs', 
N'Dell Latitude 3440 là một mẫu laptop văn phòng với thiết kế chắc chắn, hiệu năng mạnh mẽ và tính năng bảo mật cao, đây là sự lựa chọn hoàn hảo cho các doanh nhân hiện đại và các bạn sinh viên muốn một chiếc laptop có hiệu suất cao. Dell Latitude 3440 không chỉ mang đến sự bền bỉ và tin cậy mà còn cung cấp hiệu suất vượt trội và các tính năng hỗ trợ công việc hàng ngày một cách hiệu quả.', 23, 2, 4, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Asus TUF Gaming FA507NUR-LP101W R7-7435HS', 28490000, N'Asus TUF Gaming FA507NUR-LP101W R7-7435HS.png', N'M.HÌNH 15.6", Anti-Glare' + CHAR(13) + CHAR(10) + N'CPU AMD, Ryzen 7, 7435HS' + CHAR(13) + CHAR(10) + N'RAM DDR5, 16 GB' + CHAR(13) + CHAR(10) + N'PIN Lithium-ion, 90 WHrs', 
N'Không chỉ gây ấn tượng bởi thiết kế cá tính độc đáo, Asus TUF Gaming FA507NUR-LP101W còn mang trong mình cấu hình nổi bật với CPU Ryzen 7 kết hợp cùng card đồ họa RTX 4050, cung cấp sức mạnh tuyệt vời để bạn thoải mái chơi game hoặc thực hiện các tác vụ liên quan đến đồ họa.', 23, 3, 2, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Lenovo LOQ 15IAX9 (83GS001RVN)', 26990000, N'Lenovo LOQ 15IAX9 (83GS001RVN).png', N'M.HÌNH 15.6", IPS' + CHAR(13) + CHAR(10) + N'CPU Intel Core i5' + CHAR(13) + CHAR(10) + N'RAM DDR5, 32GB' + CHAR(13) + CHAR(10) + N'PIN 60Wh, 170W', 
N'Laptop Lenovo LOQ 15IAX9 (83GS001RVN) - Chính hãng là dòng máy gaming đời mới sở hữu sức mạnh vượt trội cả về vẻ ngoài lẫn cấu hình bên trong. Tích hợp chipset Intel Core i5-12450HX, thiết bị mang đến hiệu năng ấn tượng cho mọi công việc và tựa game đình đám. RAM 12GB và ổ SSD 512GB giúp tăng tốc độ xử lý, hạn chế giật lag cùng với không gian lưu trữ rộng lớn. Máy còn có card đồ họa NVIDIA GeForce RTX 3050, cải thiện chất lượng đồ họa từ thiết kế sáng tạo đến gaming đỉnh cao.', 20, 3, 5, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount)
Values(N'Lenovo ThinkBook 16 G6 IRL 21KH00Q0VN', 20490000, N'Lenovo ThinkBook 16 G6 IRL 21KH00Q0VN.png', N'M.HÌNH 16", IPS' + CHAR(13) + CHAR(10) + N'CPU Intel Core i5, 13420H' + CHAR(13) + CHAR(10) + N'RAM DDR5, 512GB SSD' + CHAR(13) + CHAR(10) + N'PIN 71Wh', 
N'Lenovo ThinkBook 14 Gen 6 (14" Intel) có cấu hình mạnh mẽ khi được trang bị bộ vi xử lý Intel® Core™ thế hệ 13 dòng H chuyên về hiệu năng. Con chip Intel Core i5 13420H, với 8 lõi 12 luồng và tốc độ tối đa 4.60 GHz thường chỉ thấy trên các laptop chơi game, mang lại hiệu suất vượt trội, giúp nâng cao năng suất làm việc. Lenovo ThinkBook 14 G6 IRL xử lý mọi việc một cách nhanh chóng và hiệu quả, tiết kiệm thời gian cho bạn.', 20, 2, 5, 5)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount, Evaluate, TotalRatings, SumRatings)
Values(N'HP Spectre X360 14-eu0050TU', 56990000, N'HP Spectre X360 14-eu0050TU.jpg', N'M.HÌNH 14" ,OLED' + CHAR(13) + CHAR(10) + N'CPU Intel, Core Ultra 7' + CHAR(13) + CHAR(10) + N'RAM LPDDR5, 32 GB' + CHAR(13) + CHAR(10) + N'PIN 75 WHrs, 65 W', 
N'Sở hữu màn hình OLED cảm ứng tràn viền cùng bộ vi xử lý mạnh mẽ cho các tác vụ văn phòng, Zenbook 14 OLED UM3402 là lựa chọn tuyệt vời cho những ai đang kiếm tìm một mẫu laptop vừa sang trọng, vừa cơ động, mang lại trải nghiệm tốt trong mọi khía cạnh, từ năng lực hiển thị, sức mạnh hiệu năng, chất lượng âm thanh và pin thật ấn tượng.
', 25, 5, 6, 9, 0, 0, 0)
Insert Into Product(ProductName, Price, Image, Details, Description, StockQuantity, CategoryID, BrandID, Discount, Evaluate, TotalRatings, SumRatings)
Values(N'Asus Zenbook 14 OLED UM3402YA-KM826W', 23990000, N'Asus Zenbook 14 OLED UM3402YA-KM826W.jpg', N'M.HÌNH 14" ,OLED' + CHAR(13) + CHAR(10) + N'CPU AMD, Ryzen 5' + CHAR(13) + CHAR(10) + N'RAM LPDDR4X, 16 GB' + CHAR(13) + CHAR(10) + N'PIN 4 Cell, 65 W', 
N'Laptop HP Spectre X360 14 eu0050TU Ultra 7 155H tự hào là một ultrabook cao cấp với thiết kế thời thượng và sang trọng. Máy mang lại trải nghiệm sử dụng linh hoạt và đẳng cấp với hiệu suất mạnh mẽ nhờ con chip Intel Core Ultra thế hệ mới, cùng với đó là sự hỗ trợ của AI chuyên nghiệp. Thiết bị đáp ứng hoàn hảo nhu cầu làm việc đa nhiệm và giải trí đa phương tiện của người dùng.'
, 20, 2, 2, 15, 0, 0, 0)

---ProductID = 1 
Insert Into Image(ImageName, ProductID) Values(N'1 Apple MacBook Air 15 inch M3.jpg',1)
Insert Into Image(ImageName, ProductID) Values(N'2 Apple MacBook Air 15 inch M3.jpg',1)
Insert Into Image(ImageName, ProductID) Values(N'3 Apple MacBook Air 15 inch M3.jpg',1)
Insert Into Image(ImageName, ProductID) Values(N'4 Apple MacBook Air 15 inch M3.jpg',1)
---ProductID = 2 
Insert Into Image(ImageName, ProductID) Values(N'1 HP 245 G10 R7- 7730U.jpg',2)
Insert Into Image(ImageName, ProductID) Values(N'2 HP 245 G10 R7- 7730U.jpg',2)
Insert Into Image(ImageName, ProductID) Values(N'3 HP 245 G10 R7- 7730U.jpg',2)
Insert Into Image(ImageName, ProductID) Values(N'4 HP 245 G10 R7- 7730U.jpg',2)
---ProductID = 3
Insert Into Image(ImageName, ProductID) Values(N'1 Acer Swift Go AI SFG14.jpg',3)
Insert Into Image(ImageName, ProductID) Values(N'2 Acer Swift Go AI SFG14.jpg',3)
Insert Into Image(ImageName, ProductID) Values(N'3 Acer Swift Go AI SFG14.jpg',3)
Insert Into Image(ImageName, ProductID) Values(N'4 Acer Swift Go AI SFG14.jpg',3)
---ProductID = 4
Insert Into Image(ImageName, ProductID) Values(N'1 Dell Inspiron N3520 i5.png',4)
Insert Into Image(ImageName, ProductID) Values(N'2 Dell Inspiron N3520 i5.png',4)
Insert Into Image(ImageName, ProductID) Values(N'3 Dell Inspiron N3520 i5.png',4)
Insert Into Image(ImageName, ProductID) Values(N'4 Dell Inspiron N3520 i5.png',4)
---ProductID = 5
Insert Into Image(ImageName, ProductID) Values(N'1 Asus Vivobook X1404ZA-NK387W i3.jpg',5)
Insert Into Image(ImageName, ProductID) Values(N'2 Asus Vivobook X1404ZA-NK387W i3.jpg',5)
Insert Into Image(ImageName, ProductID) Values(N'3 Asus Vivobook X1404ZA-NK387W i3.jpg',5)
Insert Into Image(ImageName, ProductID) Values(N'4 Asus Vivobook X1404ZA-NK387W i3.jpg',5)
---ProductID = 6
Insert Into Image(ImageName, ProductID) Values(N'1 Lenovo IdeaPad Slim 5 14Q8X9 X1P-42-100.png',6)
Insert Into Image(ImageName, ProductID) Values(N'2 Lenovo IdeaPad Slim 5 14Q8X9 X1P-42-100.png',6)
Insert Into Image(ImageName, ProductID) Values(N'3 Lenovo IdeaPad Slim 5 14Q8X9 X1P-42-100.png',6)
Insert Into Image(ImageName, ProductID) Values(N'4 Lenovo IdeaPad Slim 5 14Q8X9 X1P-42-100.png',6)
---ProductID = 7
Insert Into Image(ImageName, ProductID) Values(N'1 HP ProBook 440 G10 i7-1360P.png',7)
Insert Into Image(ImageName, ProductID) Values(N'2 HP ProBook 440 G10 i7-1360P.png',7)
Insert Into Image(ImageName, ProductID) Values(N'3 HP ProBook 440 G10 i7-1360P.png',7)
Insert Into Image(ImageName, ProductID) Values(N'4 HP ProBook 440 G10 i7-1360P.png',7)
---ProductID = 8
Insert Into Image(ImageName, ProductID) Values(N'1 HP 15 fd0234TU i5 1334U.jpg',8)
Insert Into Image(ImageName, ProductID) Values(N'2 HP 15 fd0234TU i5 1334U.jpg',8)
Insert Into Image(ImageName, ProductID) Values(N'3 HP 15 fd0234TU i5 1334U.jpg',8)
Insert Into Image(ImageName, ProductID) Values(N'4 HP 15 fd0234TU i5 1334U.jpg',8)
---ProductID = 9
Insert Into Image(ImageName, ProductID) Values(N'1 Lenovo Ideapad Slim 3 15IAH8 i5 12450H.jpg',9)
Insert Into Image(ImageName, ProductID) Values(N'2 Lenovo Ideapad Slim 3 15IAH8 i5 12450H.jpg',9)
Insert Into Image(ImageName, ProductID) Values(N'3 Lenovo Ideapad Slim 3 15IAH8 i5 12450H.jpg',9)
Insert Into Image(ImageName, ProductID) Values(N'4 Lenovo Ideapad Slim 3 15IAH8 i5 12450H.jpg',9)
---ProductID = 10
Insert Into Image(ImageName, ProductID) Values(N'1 Acer Aspire 3 A315 58 529V i5.jpg',10)
Insert Into Image(ImageName, ProductID) Values(N'2 Acer Aspire 3 A315 58 529V i5.jpg',10)
Insert Into Image(ImageName, ProductID) Values(N'3 Acer Aspire 3 A315 58 529V i5.jpg',10)
Insert Into Image(ImageName, ProductID) Values(N'4 Acer Aspire 3 A315 58 529V i5.jpg',10)
---ProductID = 11
Insert Into Image(ImageName, ProductID) Values(N'1 MSI Modern 15 B12MO i5.jpg',11)
Insert Into Image(ImageName, ProductID) Values(N'2 MSI Modern 15 B12MO i5.jpg',11)
Insert Into Image(ImageName, ProductID) Values(N'3 MSI Modern 15 B12MO i5.jpg',11)
Insert Into Image(ImageName, ProductID) Values(N'4 MSI Modern 15 B12MO i5.jpg',11)
---ProductID = 12
Insert Into Image(ImageName, ProductID) Values(N'1 MacBook Air 13 inch M1 2020.jpg',12)
Insert Into Image(ImageName, ProductID) Values(N'2 MacBook Air 13 inch M1 2020.jpg',12)
Insert Into Image(ImageName, ProductID) Values(N'3 MacBook Air 13 inch M1 2020.jpg',12)
Insert Into Image(ImageName, ProductID) Values(N'4 MacBook Air 13 inch M1 2020.jpg',12)
---ProductID = 13
Insert Into Image(ImageName, ProductID) Values(N'1 MacBook Air 15 inch M2 2023.jpg',13)
Insert Into Image(ImageName, ProductID) Values(N'2 MacBook Air 15 inch M2 2023.jpg',13)
Insert Into Image(ImageName, ProductID) Values(N'3 MacBook Air 15 inch M2 2023.jpg',13)
Insert Into Image(ImageName, ProductID) Values(N'4 MacBook Air 15 inch M2 2023.jpg',13)
---ProductID = 14
Insert Into Image(ImageName, ProductID) Values(N'1 Macbook Air M2 13 inch 2022.jpg',14)
Insert Into Image(ImageName, ProductID) Values(N'2 Macbook Air M2 13 inch 2022.jpg',14)
Insert Into Image(ImageName, ProductID) Values(N'3 Macbook Air M2 13 inch 2022.jpg',14)
Insert Into Image(ImageName, ProductID) Values(N'4 Macbook Air M2 13 inch 2022.jpg',14)
---ProductID = 15
Insert Into Image(ImageName, ProductID) Values(N'1 Apple MacBook Pro 16 inch M3 Max.jpg',15)
Insert Into Image(ImageName, ProductID) Values(N'2 Apple MacBook Pro 16 inch M3 Max.jpg',15)
Insert Into Image(ImageName, ProductID) Values(N'3 Apple MacBook Pro 16 inch M3 Max.jpg',15)
Insert Into Image(ImageName, ProductID) Values(N'4 Apple MacBook Pro 16 inch M3 Max.jpg',15)
---ProductID = 16
Insert Into Image(ImageName, ProductID) Values(N'1 MacBook Pro 16 inch M2 Max 2023.jpg',16)
Insert Into Image(ImageName, ProductID) Values(N'2 MacBook Pro 16 inch M2 Max 2023.jpg',16)
Insert Into Image(ImageName, ProductID) Values(N'3 MacBook Pro 16 inch M2 Max 2023.jpg',16)
Insert Into Image(ImageName, ProductID) Values(N'4 MacBook Pro 16 inch M2 Max 2023.jpg',16)
---ProductID = 17
Insert Into Image(ImageName, ProductID) Values(N'1 Dell XPS 14 9440 U7.jpg',17)
Insert Into Image(ImageName, ProductID) Values(N'2 Dell XPS 14 9440 U7.jpg',17)
Insert Into Image(ImageName, ProductID) Values(N'3 Dell XPS 14 9440 U7.jpg',17)
Insert Into Image(ImageName, ProductID) Values(N'4 Dell XPS 14 9440 U7.jpg',17)
---ProductID = 18
Insert Into Image(ImageName, ProductID) Values(N'1 Acer Gaming Predator Helios Neo 14 PHN14-51-99Y8.png',18)
Insert Into Image(ImageName, ProductID) Values(N'2 Acer Gaming Predator Helios Neo 14 PHN14-51-99Y8.png',18)
Insert Into Image(ImageName, ProductID) Values(N'3 Acer Gaming Predator Helios Neo 14 PHN14-51-99Y8.png',18)
Insert Into Image(ImageName, ProductID) Values(N'4 Acer Gaming Predator Helios Neo 14 PHN14-51-99Y8.png',18)
---ProductID = 19
Insert Into Image(ImageName, ProductID) Values(N'1 Lenovo Gaming Legion 9 16IRX8 i9 13980HX.png',19)
Insert Into Image(ImageName, ProductID) Values(N'2 Lenovo Gaming Legion 9 16IRX8 i9 13980HX.png',19)
Insert Into Image(ImageName, ProductID) Values(N'3 Lenovo Gaming Legion 9 16IRX8 i9 13980HX.png',19)
Insert Into Image(ImageName, ProductID) Values(N'4 Lenovo Gaming Legion 9 16IRX8 i9 13980HX.png',19)
---ProductID = 20
Insert Into Image(ImageName, ProductID) Values(N'1 MSI Gaming Vector GP78HX 13VI-476VN i9-13980HX.jpg',20)
Insert Into Image(ImageName, ProductID) Values(N'2 MSI Gaming Vector GP78HX 13VI-476VN i9-13980HX.jpg',20)
Insert Into Image(ImageName, ProductID) Values(N'3 MSI Gaming Vector GP78HX 13VI-476VN i9-13980HX.jpg',20)
Insert Into Image(ImageName, ProductID) Values(N'4 MSI Gaming Vector GP78HX 13VI-476VN i9-13980HX.jpg',20)
---ProductID = 21
Insert Into Image(ImageName, ProductID) Values(N'1 Acer Aspire Lite AL16-51P-55N7 i5 1235U.png',21)
Insert Into Image(ImageName, ProductID) Values(N'2 Acer Aspire Lite AL16-51P-55N7 i5 1235U.png',21)
Insert Into Image(ImageName, ProductID) Values(N'3 Acer Aspire Lite AL16-51P-55N7 i5 1235U.png',21)
Insert Into Image(ImageName, ProductID) Values(N'4 Acer Aspire Lite AL16-51P-55N7 i5 1235U.png',21)
---ProductID = 22
Insert Into Image(ImageName, ProductID) Values(N'1 Dell Latitude 3440 i5-1235U.jpg',22)
Insert Into Image(ImageName, ProductID) Values(N'2 Dell Latitude 3440 i5-1235U.jpg',22)
Insert Into Image(ImageName, ProductID) Values(N'3 Dell Latitude 3440 i5-1235U.jpg',22)
Insert Into Image(ImageName, ProductID) Values(N'4 Dell Latitude 3440 i5-1235U.jpg',22)
---ProductID = 23
Insert Into Image(ImageName, ProductID) Values(N'1 Asus TUF Gaming FA507NUR-LP101W.png',23)
Insert Into Image(ImageName, ProductID) Values(N'2 Asus TUF Gaming FA507NUR-LP101W.png',23)
Insert Into Image(ImageName, ProductID) Values(N'3 Asus TUF Gaming FA507NUR-LP101W.png',23)
Insert Into Image(ImageName, ProductID) Values(N'4 Asus TUF Gaming FA507NUR-LP101W.png',23)
---ProductID = 24
Insert Into Image(ImageName, ProductID) Values(N'1 Lenovo LOQ 15IAX9 (83GS001RVN).png',24)
Insert Into Image(ImageName, ProductID) Values(N'2 Lenovo LOQ 15IAX9 (83GS001RVN).png',24)
Insert Into Image(ImageName, ProductID) Values(N'3 Lenovo LOQ 15IAX9 (83GS001RVN).png',24)
Insert Into Image(ImageName, ProductID) Values(N'4 Lenovo LOQ 15IAX9 (83GS001RVN).png',24)
---ProductID = 25
Insert Into Image(ImageName, ProductID) Values(N'1 Lenovo ThinkBook 16 G6 IRL 21KH00Q0VN.png',25)
Insert Into Image(ImageName, ProductID) Values(N'2 Lenovo ThinkBook 16 G6 IRL 21KH00Q0VN.png',25)
Insert Into Image(ImageName, ProductID) Values(N'3 Lenovo ThinkBook 16 G6 IRL 21KH00Q0VN.png',25)
Insert Into Image(ImageName, ProductID) Values(N'4 Lenovo ThinkBook 16 G6 IRL 21KH00Q0VN.png',25)
---ProductID = 26 hiện tại 30
Insert Into Image(ImageName, ProductID) Values(N'1 HP Spectre X360 14-eu0050TU.jpg',30)
Insert Into Image(ImageName, ProductID) Values(N'2 HP Spectre X360 14-eu0050TU.jpg',30)
Insert Into Image(ImageName, ProductID) Values(N'3 HP Spectre X360 14-eu0050TU.jpg',30)
Insert Into Image(ImageName, ProductID) Values(N'4 HP Spectre X360 14-eu0050TU.jpg',30)
---ProductID = 27 hiện tại 31
Insert Into Image(ImageName, ProductID) Values(N'1 Asus Zenbook 14 OLED UM3402YA-KM826W.jpg',31)
Insert Into Image(ImageName, ProductID) Values(N'2 Asus Zenbook 14 OLED UM3402YA-KM826W.jpg',31)
Insert Into Image(ImageName, ProductID) Values(N'3 Asus Zenbook 14 OLED UM3402YA-KM826W.jpg',31)
Insert Into Image(ImageName, ProductID) Values(N'4 Asus Zenbook 14 OLED UM3402YA-KM826W.jpg',31)
