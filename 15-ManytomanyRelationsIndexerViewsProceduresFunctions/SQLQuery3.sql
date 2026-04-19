CREATE DATABASE CompanyMM;
USE CompanyMM;

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    BirthDate DATE,
    Email VARCHAR(100) UNIQUE NOT NULL,
    CONSTRAINT chk_BirthDate CHECK (BirthDate < '2010-01-01')
);

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY AUTO_INCREMENT,
    ProjectName VARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE,
    CONSTRAINT chk_Dates CHECK (EndDate IS NULL OR EndDate >= StartDate)
);

CREATE TABLE EmployeeProjects (
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE DEFAULT (CURRENT_DATE),
    PRIMARY KEY (EmployeeID, ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE
);

INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES
('Ali', 'Aliyev', '1990-05-15', 'ali@company.com'),
('Leyla', 'Mammadova', '1995-08-20', 'leyla@company.com'),
('Anar', 'Hasanov', '1988-12-02', 'anar@company.com'),
('Aysel', 'Rzayeva', '1992-03-10', 'aysel@company.com'),
('Vugar', 'Karimov', '1994-11-25', 'vugar@company.com');

INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
('E-Commerce Site', '2023-01-01', '2023-12-31'),
('Mobile App', '2023-06-01', '2024-05-01'),
('AI Research', '2024-01-01', NULL);

INSERT INTO EmployeeProjects (EmployeeID, ProjectID) VALUES
(1, 1), (1, 2), (1, 3),
(2, 1), (2, 2),
(3, 3),
(4, 1), (4, 2);

-- A
SELECT * FROM Employees;

SELECT * FROM Projects;

SELECT e.FirstName, e.LastName, p.ProjectName
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID;

SELECT p.ProjectName, COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectID, p.ProjectName;

SELECT e.FirstName, e.LastName
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2;

-- B
CREATE VIEW EmployeeProjectView AS
SELECT 
    e.EmployeeID, 
    CONCAT(e.FirstName, ' ', e.LastName) AS FullName, 
    p.ProjectID, 
    p.ProjectName, 
    ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID;

SELECT * FROM EmployeeProjectView WHERE EmployeeID = 1;

-- C
CREATE PROCEDURE sp_AssignEmployeeToProject(IN empId INT, IN projId INT)
BEGIN
    IF NOT EXISTS (SELECT 1 FROM EmployeeProjects WHERE EmployeeID = empId AND ProjectID = projId) THEN
        INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate) 
        VALUES (empId, projId, CURDATE());
    END IF;
END 

CREATE FUNCTION fn_GetProjectCount(empId INT) RETURNS INT DETERMINISTIC
BEGIN
    DECLARE p_count INT;
    SELECT COUNT(*) INTO p_count FROM EmployeeProjects WHERE EmployeeID = empId;
    RETURN p_count;
END

SELECT FirstName, LastName, fn_GetProjectCount(EmployeeID) FROM Employees;

-- E
CALL sp_AssignEmployeeToProject(3, 1);

DELETE FROM EmployeeProjects WHERE EmployeeID = 5;