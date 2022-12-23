CREATE TABLE [ConsultantRandomizer].[PersonInGroup]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [PersonID] INT REFERENCES [ConsultantRandomizer].People([Id]) NOT NULL, 
	[ProjectGroupID] INT REFERENCES [ConsultantRandomizer].ProjectGroup([Id]) NOT NULL,
	unique ([PersonID], [ProjectGroupID])
    
	
)
