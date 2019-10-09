
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE exGetContacts --exGetContacts
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Contact c
	JOIN ContactNumber cn on cn.ContactID = c.ContactID
	JOIN Relationship r on r.RelationshipID = c.Relationship
	JOIN NumberType nt on nt.NumberTypeID = cn.NumberType
END
GO
