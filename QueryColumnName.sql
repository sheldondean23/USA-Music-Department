
CREATE PROCEDURE TableColumnNames
    @TableName nvarchar(50)
AS 

SET NOCOUNT ON;
SELECT name
FROM sys.columns
WHERE object_id = OBJECT_ID(@TableName)