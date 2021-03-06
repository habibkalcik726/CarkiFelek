USE [DBCarkifelek]
GO
/****** Object:  StoredProcedure [dbo].[check_code]    Script Date: 8.10.2020 20:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[check_code]
@Code varchar(100),
@IsValid int out
as
begin

Declare @Length int,
@CharPool nvarchar(100),
@Count int


SET @CharPool = 
    'ACDEFGHKLMNPRTXYZ234579';
SET @Length= LEN(@Code); --Code Length
Set @Count = 0; --Count for while loop

Set @IsValid =1;
if @Length <> 8 --Code must be 8 chars
	Set @IsValid =0;
else
	if(CHARINDEX(@Code ,@CharPool) >0) --code can not be in CharPool directly 
		Set @IsValid =0;
	else
		WHILE (@Count < 8 ) 
		BEGIN
			if(CHARINDEX(SUBSTRING(@Code, @Count+1, 1),@CharPool) = 0)
				begin
				select SUBSTRING(@Code, @Count+1, 1) as broken
				Set @IsValid =0 
				end--End if
            SET @Count = @Count + 1
		END	--End While		
End --end procedure

