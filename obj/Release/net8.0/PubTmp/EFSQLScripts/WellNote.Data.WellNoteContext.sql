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
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106190041_first migration'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [username] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106190041_first migration'
)
BEGIN
    CREATE TABLE [Sleep] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [DateTime] datetime2 NOT NULL,
        [Quantity] float NOT NULL,
        CONSTRAINT [PK_Sleep] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sleep_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106190041_first migration'
)
BEGIN
    CREATE TABLE [Water] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [DateTime] datetime2 NOT NULL,
        [Quantity] float NOT NULL,
        CONSTRAINT [PK_Water] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Water_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106190041_first migration'
)
BEGIN
    CREATE INDEX [IX_Sleep_UserId] ON [Sleep] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106190041_first migration'
)
BEGIN
    CREATE INDEX [IX_Water_UserId] ON [Water] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106190041_first migration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241106190041_first migration', N'8.0.10');
END;
GO

COMMIT;
GO

