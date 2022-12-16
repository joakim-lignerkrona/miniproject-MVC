CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DiscordID] NCHAR(200) NOT NULL, 
    [DisplayName] NCHAR(20) NOT NULL, 
    [CustomDisplayName] NCHAR(10) NULL
)
