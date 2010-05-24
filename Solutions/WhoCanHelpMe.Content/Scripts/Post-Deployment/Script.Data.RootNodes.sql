SET IDENTITY_INSERT n2Item ON

INSERT INTO [dbo].[n2Item] ([ID], [Type], [Created], [Published], [Updated], [Expires], [Name], [ZoneName], [Title], [SortOrder], [Visible], [SavedBy], [State], [AncestralTrail], [VersionIndex], [VersionOfID], [ParentID]) 
VALUES	(1, N'SiteRoot', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100118 15:48:59.000', NULL, N'root', NULL, N'Who Can Help Me?', 0, 1, N'admin', 1, N'/', 0, NULL, NULL)
,		(2, N'HomePage', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100127 10:03:56.000', NULL, N'home', NULL, N'Home', 0, 1, N'admin', 16, N'/1/', 1, NULL, 1)

SET IDENTITY_INSERT n2Item OFF


SET IDENTITY_INSERT n2Detail ON

INSERT INTO [dbo].[n2Detail] (ID, Type, ItemID, DetailCollectionID, Name, BoolValue, IntValue, LinkValue, DoubleValue, DateTimeValue, StringValue, Value)
VALUES						 (1, 'String', 2, NULL, 'Heading', NULL, NULL, NULL, NULL, NULL, 'What''s all this then?', NULL)
,							 (2, 'String', 2, NULL, 'SubHeading' ,NULL, NULL, NULL, NULL, NULL, 'Show off your ninja skills!', NULL)
,							 (3, 'String', 2, NULL, 'BodyText', NULL, NULL, NULL, NULL, NULL, '<p>This site is to help find people within the community who have the skills you need.</p>  <p>Keep your list of skills and expertise up to date by clicking the "You!" link on the menu.</p>', NULL)

SET IDENTITY_INSERT n2Detail OFF


