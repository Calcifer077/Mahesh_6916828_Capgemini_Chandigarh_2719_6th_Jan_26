use ProcFunDb;

go

-- Customers
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100)
);

-- Orders
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(18,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(18,2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- Departments
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Employees
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(100),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

go

go
INSERT INTO Customers VALUES
(101, 'Rahul Sharma', 'rahul@email.com'),
(102, 'Priya Singh', 'priya@email.com');

INSERT INTO Orders VALUES
(1, 101, '2025-01-10', 500),
(2, 101, '2025-02-15', 800),
(3, 102, '2025-03-01', 300);

INSERT INTO OrderDetails VALUES
(1, 1, 10, 2, 200),
(2, 1, 11, 1, 100),
(3, 2, 12, 4, 200),
(4, 3, 13, 1, 300);

INSERT INTO Departments VALUES
(1, 'HR'),
(2, 'Sales');

INSERT INTO Employees VALUES
(1, 'Amit', 2),
(2, 'Neha', 2),
(3, 'Ravi', 1);
go

-- question 1
CREATE OR ALTER PROCEDURE GetCustomerOrderSummary
    @CustomerID INT
AS
BEGIN
    SELECT 
        c.CustomerID,
        c.Name,
        o.OrderID,
        o.OrderDate,
        SUM(od.Quantity * od.Price) AS OrderTotal
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    WHERE c.CustomerID = @CustomerID
    GROUP BY c.CustomerID, c.Name, o.OrderID, o.OrderDate
END;

EXEC GetCustomerOrderSummary @CustomerID = 101;

-- question 2
CREATE OR ALTER PROCEDURE GetEmployeeSalesReport
    @DepartmentID INT,
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.Name,
        SUM(o.TotalAmount) AS TotalSales
    FROM Employees e
    JOIN Orders o ON o.CustomerID IS NOT NULL
    WHERE e.DepartmentID = @DepartmentID
      AND o.OrderDate BETWEEN @StartDate AND @EndDate
    GROUP BY e.EmployeeID, e.Name
END;

EXEC GetEmployeeSalesReport 
    @DepartmentID = 2,
    @StartDate = '2025-01-01',
    @EndDate = '2025-12-31';

-- question 3
CREATE OR ALTER PROCEDURE GetCustomerOrderCount
    @CustomerID INT,
    @OrderCount INT OUTPUT
AS
BEGIN
    SELECT @OrderCount = COUNT(*)
    FROM Orders
    WHERE CustomerID = @CustomerID
END;

DECLARE @Count INT;

EXEC GetCustomerOrderCount
    @CustomerID = 101,
    @OrderCount = @Count OUTPUT;

PRINT 'Total Orders: ' + CAST(@Count AS VARCHAR);

-- question 4
CREATE OR ALTER PROCEDURE GetDepartmentSalesTotal
    @DepartmentID INT,
    @StartDate DATE,
    @EndDate DATE,
    @TotalSales DECIMAL(18,2) OUTPUT
AS
BEGIN
    SELECT @TotalSales = SUM(o.TotalAmount)
    FROM Employees e
    JOIN Orders o ON o.CustomerID IS NOT NULL
    WHERE e.DepartmentID = @DepartmentID
      AND o.OrderDate BETWEEN @StartDate AND @EndDate
END;

DECLARE @Sales DECIMAL(18,2);

EXEC GetDepartmentSalesTotal
    @DepartmentID = 2,
    @StartDate = '2025-01-01',
    @EndDate = '2025-12-31',
    @TotalSales = @Sales OUTPUT;

PRINT 'Total Department Sales: ' + CAST(@Sales AS VARCHAR);

-- question 5
CREATE OR ALTER PROCEDURE GetCustomerOrderStats
    @CustomerID INT,
    @OrderCount INT OUTPUT,
    @TotalSpent DECIMAL(18,2) OUTPUT,
    @AvgOrderValue DECIMAL(18,2) OUTPUT
AS
BEGIN
    SELECT
        @OrderCount = COUNT(*),
        @TotalSpent = SUM(TotalAmount),
        @AvgOrderValue = AVG(TotalAmount)
    FROM Orders
    WHERE CustomerID = @CustomerID
END;

DECLARE @Count INT,
        @Spent DECIMAL(18,2),
        @Avg DECIMAL(18,2);

EXEC GetCustomerOrderStats
    @CustomerID = 101,
    @OrderCount = @Count OUTPUT,
    @TotalSpent = @Spent OUTPUT,
    @AvgOrderValue = @Avg OUTPUT;

PRINT 'Orders: ' + CAST(@Count AS VARCHAR);
PRINT 'Total Spent: ' + CAST(@Spent AS VARCHAR);
PRINT 'Average Order Value: ' + CAST(@Avg AS VARCHAR);

-- question 6
CREATE OR ALTER PROCEDURE GetDepartmentSalesMetrics
    @DepartmentID INT,
    @StartDate DATE,
    @EndDate DATE,
    @TotalSales DECIMAL(18,2) OUTPUT,
    @AvgSales DECIMAL(18,2) OUTPUT,
    @EmployeeCount INT OUTPUT
AS
BEGIN
    -- total sales
    SELECT @TotalSales = SUM(o.TotalAmount)
    FROM Employees e
    JOIN Orders o ON o.CustomerID IS NOT NULL
    WHERE e.DepartmentID = @DepartmentID
      AND o.OrderDate BETWEEN @StartDate AND @EndDate;

    -- employee count
    SELECT @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;

    -- average per employee
    IF @EmployeeCount > 0
        SET @AvgSales = @TotalSales / @EmployeeCount;
    ELSE
        SET @AvgSales = 0;
END;

DECLARE @Total DECIMAL(18,2),
        @Avg DECIMAL(18,2),
        @EmpCount INT;

EXEC GetDepartmentSalesMetrics
    @DepartmentID = 2,
    @StartDate = '2025-01-01',
    @EndDate = '2025-12-31',
    @TotalSales = @Total OUTPUT,
    @AvgSales = @Avg OUTPUT,
    @EmployeeCount = @EmpCount OUTPUT;

PRINT 'Total Sales: ' + CAST(@Total AS VARCHAR);
PRINT 'Average Sales per Employee: ' + CAST(@Avg AS VARCHAR);
PRINT 'Employee Count: ' + CAST(@EmpCount AS VARCHAR);