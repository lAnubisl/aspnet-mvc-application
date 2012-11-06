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
--INSERT INTO [dbo].[Role] ([RoleId], [Name]) VALUES (1, 'Admin'), (2, 'User')
INSERT INTO [ConsignmentStatus] (ConsignmentStatusId, Name) VALUES (1, 'Waiting'), (2, 'Completed')
--INSERT INTO [User] (FirstName, LastName, Email, RoleId) VALUES ('Alexander', 'Panfilenok', 'alexander.panfilenok@gmail.com', 1)

--INSERT INTO Category (ParentCategoryId, Name, [Description]) VALUES (NULL, 'Подушки', 'Подушечки')

--INSERT INTO Product (UserId, Name, Price, CategoryId) VALUES (1, 'Белая подушка', 15, 1)

INSERT INTO Consignment (UserId, CreationDate, ConsignmentStatusId) VALUES (1, GETDATE(), 2)
INSERT INTO IncomingProduct (ConsignmentId, ProductId, [Count]) VALUES (1, 1, 100)