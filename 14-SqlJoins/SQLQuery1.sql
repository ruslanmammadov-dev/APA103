CREATE DATABASE Company1;
USE Company1;

CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Age INT,
    Salary DECIMAL(18, 2),
    Position NVARCHAR(50),
    IsDeleted BIT DEFAULT 0,
    CityId INT FOREIGN KEY REFERENCES Cities(Id)
)

SELECT e.Name, e.Surname, ci.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities ci ON e.CityId = ci.Id
JOIN Countries co ON ci.CountryId = co.Id;

SELECT e.Name, co.Name AS Country
FROM Employees e
JOIN Cities ci ON e.CityId = ci.Id
JOIN Countries co ON ci.CountryId = co.Id
WHERE e.Salary > 2000;

SELECT ci.Name AS City, co.Name AS Country
FROM Cities ci
JOIN Countries co ON ci.CountryId = co.Id;

SELECT e.Name, e.Surname, e.Age, e.Salary, e.Position, e.IsDeleted, ci.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities ci ON e.CityId = ci.Id
JOIN Countries co ON ci.CountryId = co.Id
WHERE e.Position = 'Reception';

SELECT e.Name, e.Surname, ci.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities ci ON e.CityId = ci.Id
JOIN Countries co ON ci.CountryId = co.Id
WHERE e.IsDeleted = 1;