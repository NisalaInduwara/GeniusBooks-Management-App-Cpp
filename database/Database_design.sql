CREATE DATABASE GrifindoToysPayrollSystem;
USE GrifindoToysPayrollSystem;
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    MonthlySalary DECIMAL(18, 2) NOT NULL,
    OvertimeRate DECIMAL(18, 2) NOT NULL,
    Allowances DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Salaries (
    Id INT PRIMARY KEY,
    EmployeeId INT NOT NULL,
    Month DATETIME NOT NULL,
    NoPayValue DECIMAL(18, 2) NOT NULL,
    BasePayValue DECIMAL(18, 2) NOT NULL,
    GrossPay DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Salaries_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);
