CREATE TABLE [ConsultantRandomizer].[PeopleInGroupProject]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PersonID] INT REFERENCES [ConsultantRandomizer].People([ID]) NOT NULL,
	[ProjectID] INT REFERENCES [ConsultantRandomizer].Project([ID]) NOT NULL, 
    
	
)
