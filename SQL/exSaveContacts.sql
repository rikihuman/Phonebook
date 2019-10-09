
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE exSaveContacts
	@ContactID int,
	@ContactName NVARCHAR(150),
	@ContactSurname NVARCHAR(150),
	@Relationship int,
	@deleted bit,
	@ContactNumberID int,
	@NumberType int,
	@Number NVARCHAR(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM Contact Where ContactID = @ContactID AND @ContactID != 0)
	BEGIN
		UPDATE Contact 
		SET ContactName = @ContactName,
		ContactSurname = @ContactSurname,
		Relationship = @Relationship,
		Deleted = @deleted,
		DateModified = GETDATE()
		Where ContactID = @ContactID
		 
		 IF EXISTS (SELECT * FROM ContactNumber WHERE ContactID = @ContactID)
		 BEGIN
		 
			 UPDATE ContactNumber
				SET Deleted = @deleted,
				NumberType = @NumberType,
				Number = @Number,
				DateModified = GETDATE()
				WHERE ContactID = @ContactID
		END
		ELSE
		BEGIN
			
			INSERT INTO ContactNumber (ContactID, NumberType, Number, DateCreated)
			VALUES(@ContactID, @NumberType, @Number, GETDATE())
		END
	END
	ELSE
	BEGIN
		INSERT INTO Contact (ContactName, ContactSurname, Relationship, DateCreated)
		VALUES (@ContactName, @ContactSurname, @Relationship, GETDATE())
		
		SELECT top 1 contactid FROM Contact order by DateCreated desc
		
		SELECT top 1 @ContactID = contactid FROM Contact order by DateCreated desc
		INSERT INTO ContactNumber (ContactID, NumberType, Number, DateCreated)
			VALUES(@ContactID, @NumberType, @Number, GETDATE())
	END
    -- Insert statements for procedure here
	
END
GO
