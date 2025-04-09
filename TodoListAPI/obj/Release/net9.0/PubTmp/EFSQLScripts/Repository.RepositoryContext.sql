IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE TABLE [EmailVerifications] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NOT NULL,
        [ResetToken] nvarchar(max) NULL,
        [ResetTokenExpiry] datetime2 NULL,
        [IsVerified] bit NOT NULL,
        CONSTRAINT [PK_EmailVerifications] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE TABLE [Status] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Status] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE TABLE [TaskCategories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TaskCategories] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE TABLE [TaskPriorities] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TaskPriorities] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE TABLE [Tasks] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NULL,
        [TaskStatusId] int NOT NULL,
        [TaskCategoryId] int NOT NULL,
        [UserId] int NOT NULL,
        [TaskPriorityId] int NOT NULL,
        CONSTRAINT [PK_Tasks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tasks_Status_TaskStatusId] FOREIGN KEY ([TaskStatusId]) REFERENCES [Status] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tasks_TaskCategories_TaskCategoryId] FOREIGN KEY ([TaskCategoryId]) REFERENCES [TaskCategories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tasks_TaskPriorities_TaskPriorityId] FOREIGN KEY ([TaskPriorityId]) REFERENCES [TaskPriorities] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tasks_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Status]'))
        SET IDENTITY_INSERT [Status] ON;
    EXEC(N'INSERT INTO [Status] ([Id], [Name])
    VALUES (1, N''Not Started''),
    (2, N''In Progress''),
    (3, N''Completed'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Status]'))
        SET IDENTITY_INSERT [Status] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[TaskCategories]'))
        SET IDENTITY_INSERT [TaskCategories] ON;
    EXEC(N'INSERT INTO [TaskCategories] ([Id], [Name])
    VALUES (1, N''Daily''),
    (2, N''Weekly''),
    (3, N''Yearly'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[TaskCategories]'))
        SET IDENTITY_INSERT [TaskCategories] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[TaskPriorities]'))
        SET IDENTITY_INSERT [TaskPriorities] ON;
    EXEC(N'INSERT INTO [TaskPriorities] ([Id], [Name])
    VALUES (1, N''Low''),
    (2, N''Medium''),
    (3, N''High'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[TaskPriorities]'))
        SET IDENTITY_INSERT [TaskPriorities] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE INDEX [IX_Tasks_TaskCategoryId] ON [Tasks] ([TaskCategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE INDEX [IX_Tasks_TaskPriorityId] ON [Tasks] ([TaskPriorityId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE INDEX [IX_Tasks_TaskStatusId] ON [Tasks] ([TaskStatusId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    CREATE INDEX [IX_Tasks_UserId] ON [Tasks] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250409232536_db'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250409232536_db', N'9.0.4');
END;

COMMIT;
GO

