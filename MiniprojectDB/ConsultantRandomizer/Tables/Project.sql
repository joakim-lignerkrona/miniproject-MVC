CREATE TABLE [ConsultantRandomizer].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(20) NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT GetDate()
)
