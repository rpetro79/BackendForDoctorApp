IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425105740_initial')
BEGIN
    CREATE TABLE [appointments] (
        [appointmentId] int NOT NULL IDENTITY,
        [patientId] nvarchar(max) NULL,
        [doctorId] nvarchar(max) NULL,
        [datetime] bigint NOT NULL,
        [symptoms] nvarchar(max) NULL,
        [label] nvarchar(max) NULL,
        [cancelled] bit NOT NULL,
        CONSTRAINT [PK_appointments] PRIMARY KEY ([appointmentId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425105740_initial')
BEGIN
    CREATE TABLE [credentials] (
        [SSN] nvarchar(450) NOT NULL,
        [personId] int NOT NULL,
        [password] nvarchar(max) NULL,
        CONSTRAINT [PK_credentials] PRIMARY KEY ([SSN])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425105740_initial')
BEGIN
    CREATE TABLE [doctors] (
        [doctorId] nvarchar(450) NOT NULL,
        [ssn] nvarchar(max) NULL,
        [name] nvarchar(max) NULL,
        [phone] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [country] nvarchar(max) NULL,
        [city] nvarchar(max) NULL,
        [clinicName] nvarchar(max) NULL,
        [cvr] nvarchar(max) NULL,
        [specialization] nvarchar(max) NULL,
        [address] nvarchar(max) NULL,
        CONSTRAINT [PK_doctors] PRIMARY KEY ([doctorId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425105740_initial')
BEGIN
    CREATE TABLE [patients] (
        [patientId] nvarchar(450) NOT NULL,
        [ssn] nvarchar(max) NULL,
        [name] nvarchar(max) NULL,
        [phone] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [country] nvarchar(max) NULL,
        [city] nvarchar(max) NULL,
        [birthday] bigint NOT NULL,
        CONSTRAINT [PK_patients] PRIMARY KEY ([patientId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425105740_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200425105740_initial', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425140531_appointmentTimesAdded')
BEGIN
    CREATE TABLE [doctorAppointmentTimes] (
        [doctorId] nvarchar(450) NOT NULL,
        [appointmentTime] bigint NOT NULL,
        CONSTRAINT [PK_doctorAppointmentTimes] PRIMARY KEY ([doctorId], [appointmentTime])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425140531_appointmentTimesAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200425140531_appointmentTimesAdded', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425170509_specializationsAdded')
BEGIN
    CREATE TABLE [specializations] (
        [name] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_specializations] PRIMARY KEY ([name])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200425170509_specializationsAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200425170509_specializationsAdded', N'3.1.3');
END;

GO

