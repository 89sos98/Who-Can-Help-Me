/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT n2Item ON

INSERT INTO [dbo].[n2Item] ([ID], [Type], [Created], [Published], [Updated], [Expires], [Name], [ZoneName], [Title], [SortOrder], [Visible], [SavedBy], [State], [AncestralTrail], [VersionIndex], [VersionOfID], [ParentID]) 
VALUES	(1, N'SiteRoot', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100118 15:48:59.000', NULL, N'root', NULL, N'Who Can Help Me?', 0, 1, N'admin', 1, N'/', 0, NULL, NULL)
,		(2, N'HomePage', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100127 10:03:56.000', NULL, N'home', NULL, N'Home', 0, 1, N'admin', 16, N'/1/', 1, NULL, 1)

SET IDENTITY_INSERT n2Item OFF
