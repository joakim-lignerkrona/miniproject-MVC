CREATE TABLE [ConsultantRandomizer].[ProjectGroup]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProjectId] INT NOT NULL References [ConsultantRandomizer].[Project]([Id]), 
    [Groupname] INT NOT NULL References [ConsultantRandomizer].[GroupNames]([Id]),
    unique ([ProjectId], [Groupname])
)
