SELECT E.Dept, E.Name, E.Salary
FROM Employees E
INNER JOIN (
    SELECT Dept, MAX(Salary) AS MaxSalary
    FROM Employees
    GROUP BY Dept
) AS MaxSalaries
ON E.Dept = MaxSalaries.Dept AND E.Salary = MaxSalaries.MaxSalary;
