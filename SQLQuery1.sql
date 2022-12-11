CREATE TABLE [dbo].[Lokale] (
    [LokaleId]   CHAR (255) NOT NULL,
    [Occupied]   BIT NOT NULL,
    [CardId]     INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY (CardId) REFERENCES Kort(CardId)
);