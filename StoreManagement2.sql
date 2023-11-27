SELECT * FROM Customers

SELECT * FROM Categories

SELECT * FROM Reviews

CREATE PROC CustomerDelete
(
@CustomerID int
)
AS

--Lần lượt xóa từng bản ghi mà CustomerID cần xóa làm khóa ngoại
IF EXISTS (SELECT * FROM ORDERS WHERE CustomerID = @CustomerID)
BEGIN
	--Xóa OrderDetails
	DELETE OrderDetails WHERE OrderID in
		(SELECT OrderID FROM Orders WHERE CustomerID = @CustomerID)
	--Sau ddos xoas Order
	DELETE Orders WHERE CustomerID = @CustomerID
END
--Tiếp đến xóa Customers
DELETE FROM Customers WHERE CustomerID = @CustomerID
GO