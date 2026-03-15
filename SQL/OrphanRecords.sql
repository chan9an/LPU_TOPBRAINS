SELECT oi.*
FROM OrderItems oi
LEFT JOIN Orders o
    ON oi.OrderId = o.OrderId
WHERE o.OrderId IS NULL;
