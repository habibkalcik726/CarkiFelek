Declare @Length int,
@CharPool nvarchar(100),
@CodeGenerateLoopCount int,
@RandomString  nvarchar(100),
@PoolLength int,
@GenerateCodeCount int,
@Cnt int;    

----Length of a Code----
SET @Length =  8


-- SET @Length = RAND() * (max_length - min_length + 1) + min_length

---The Char Poo to use---
SET @CharPool = 
    'ACDEFGHKLMNPRTXYZ234579'
SET @PoolLength = Len(@CharPool)
-------------------------



-----Main Loop--------------------
SET @GenerateCodeCount=1000
WHILE (@GenerateCodeCount>0)
BEGIN


----Code Generate-----
SET @RandomString = ''
SET @CodeGenerateLoopCount = 0
WHILE (@CodeGenerateLoopCount < @Length+1) 
BEGIN
    SET @RandomString = @RandomString + 
        SUBSTRING(@Charpool, CONVERT(int, RAND() * @PoolLength), 1)    
	SET @CodeGenerateLoopCount = @CodeGenerateLoopCount + 1	
END
----End Code Generate----

----Insert to Table----
set @Cnt =0;

SELECT 
 @Cnt=Count(*)
FROM 
    Codes
WHERE 
    value=@RandomString;

if (@Cnt=0 and CHARINDEX(@RandomString ,@CharPool) = 0)
begin
SET ANSI_WARNINGS  OFF;
 insert  INTO Codes values ( @RandomString)
 SET @GenerateCodeCount=@GenerateCodeCount-1;
SET ANSI_WARNINGS ON;
 end----End Insert to Table----

END---End Main Loop----------------------


