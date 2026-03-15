SELECT 
    d.DeptName,
    e.Salary AS HighestSalary,
    e.Name AS EmployeeName
FROM Employees e
JOIN Department d ON e.DeptId = d.DeptId
WHERE e.Salary = (
    -- Subquery to find the highest salary in this department
    SELECT MAX(Salary)
    FROM Employees
    WHERE DeptId = e.DeptId
)
AND e.DeptId IN (
    -- Subquery to filter departments whose average salary > 70000
    SELECT DeptId
    FROM Employees
    GROUP BY DeptId
    HAVING AVG(Salary) > 70000
);
