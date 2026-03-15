CREATE NONCLUSTERED INDEX IX_Orders_CustomerId_OrderDate
ON Orders (CustomerId, OrderDate);



CREATE CLUSTERED INDEX IX_Orders_OrderId
ON Orders (OrderId);


CREATE NONCLUSTERED INDEX IX_Orders_CustomerId_OrderDate_Covering
ON Orders (CustomerId, OrderDate)
INCLUDE (OrderId, TotalAmount);  -- Include other frequently used columns

UPDATE STATISTICS Orders;
