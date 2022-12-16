CREATE TABLE [ConsultantRandomizer].[People]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DiscordID] NCHAR(200) NULL, 
    [DisplayName] NCHAR(20) NOT NULL, 
    [CustomDisplayName] NCHAR(25) NULL,
    [IndividualPresentations] INT NOT NULL DEFAULT 0, 
    [GroupPresentatons] INT NOT NULL DEFAULT 0 , 
)
