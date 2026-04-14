CREATE DATABASE Company
USE Company

CREATE TABLE Employees (
    EmployeeID INT,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    HireDate DATE,
    JobTitle NVARCHAR(50),
    Salary DECIMAL(10, 2),
    Department NVARCHAR(50)
)

INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, PhoneNumber, HireDate, JobTitle, Salary, Department)
VALUES 
(1, 'Anar', 'Məmmədov', 'anar@company.az', '0501234567', '2019-05-10', 'Developer', 2500, 'IT'),
(2, 'Leyla', 'Həsənova', 'leyla@gmail.com', '0552345678', '2021-03-15', 'HR Assistant', 1200, 'HR'),
(3, 'Rəşad', 'Əliyev', 'rashad@company.az', '0703456789', '2022-01-20', 'System Admin', 2100, 'IT'),
(4, 'Günel', 'Quliyeva', 'gunel@company.az', '0514567890', '2018-11-12', 'Accountant', 1800, 'Finance'),
(5, 'Elnur', 'Səfərov', 'elnur@mail.ru', '0505678901', '2020-06-01', 'Designer', 1400, 'Marketing')

SELECT * FROM Employees

SELECT * FROM Employees WHERE Salary > 2000

SELECT * FROM Employees WHERE Department = 'IT'

SELECT * FROM Employees ORDER BY Salary DESC

SELECT FirstName, Salary FROM Employees

SELECT * FROM Employees WHERE HireDate > '2020-12-31'

SELECT * FROM Employees WHERE Email LIKE '%company.az%'

SELECT MAX(Salary) AS MaxSalary FROM Employees

SELECT MIN(Salary) AS MinSalary FROM Employees

SELECT AVG(Salary) AS AvgSalary FROM Employees

SELECT COUNT(*) AS TotalEmployees FROM Employees

SELECT SUM(Salary) AS TotalSalarySum FROM Employees

SELECT Department, COUNT(*) AS EmployeeCount FROM Employees GROUP BY Department

SELECT Department, AVG(Salary) AS AvgSalary FROM Employees GROUP BY Department

SELECT Department, MAX(Salary) AS MaxSalary FROM Employees GROUP BY Department

UPDATE Employees SET Salary = 2800 WHERE EmployeeID = 1

UPDATE Employees SET Salary = Salary * 1.10 WHERE Department = 'IT'

UPDATE Employees 
SET JobTitle = 'HR Meneceri' 
WHERE FirstName = 'Leyla' AND LastName = 'Həsənova'

DELETE FROM Employees WHERE EmployeeID = 5

DELETE FROM Employees WHERE Salary < 1500

SELECT * FROM Employees WHERE FirstName LIKE '%a%'

SELECT * FROM Employees WHERE Salary BETWEEN 2000 AND 2500

SELECT * FROM Employees WHERE Department IN ('Finance', 'IT')