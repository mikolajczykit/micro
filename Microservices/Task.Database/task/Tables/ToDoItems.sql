CREATE TABLE [task].[ToDoItems] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [DueDate]     DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ToDoItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

