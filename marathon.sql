-- ----------------------------
-- Table structure for Charities
-- ----------------------------
DROP TABLE [dbo].[Charities]
GO
CREATE TABLE [dbo].[Charities] (
[id] int NOT NULL ,
[name] varchar(255) NULL ,
[description] text NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for EventCategories
-- ----------------------------
DROP TABLE [dbo].[EventCategories]
GO
CREATE TABLE [dbo].[EventCategories] (
[id] int NOT NULL ,
[name] varchar(255) NULL ,
[description] text NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for EventTypes
-- ----------------------------
DROP TABLE [dbo].[EventTypes]
GO
CREATE TABLE [dbo].[EventTypes] (
[id] int NOT NULL ,
[name] varchar(255) NULL ,
[description] text NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for Feedbacks
-- ----------------------------
DROP TABLE [dbo].[Feedbacks]
GO
CREATE TABLE [dbo].[Feedbacks] (
[id] int NOT NULL ,
[sender_id] int NULL ,
[message] text NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for MarathonEvents
-- ----------------------------
DROP TABLE [dbo].[MarathonEvents]
GO
CREATE TABLE [dbo].[MarathonEvents] (
[id] int NOT NULL ,
[name] varchar(255) NULL ,
[type_id] int NULL ,
[category_id] int NULL ,
[quota] int NOT NULL DEFAULT ((0)) ,
[start_at] int NOT NULL DEFAULT ((0)) ,
[end_at] int NOT NULL DEFAULT ((0)) ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for Members
-- ----------------------------
DROP TABLE [dbo].[Members]
GO
CREATE TABLE [dbo].[Members] (
[id] int NOT NULL IDENTITY(1,1) ,
[state] int NOT NULL DEFAULT ((0)) ,
[username] varchar(255) NULL ,
[password] varchar(255) NULL ,
[email] varchar(255) NULL ,
[idcard] varchar(255) NULL ,
[name] varchar(255) NULL ,
[gender] char(1) NULL ,
[phone] varchar(255) NULL ,
[birthday] date NULL ,
[country] char(2) NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0)) ,
[lastlogin] int NOT NULL DEFAULT ((0))
)


GO
DBCC CHECKIDENT(N'[dbo].[Members]', RESEED, 3)
GO

-- ----------------------------
-- Table structure for News
-- ----------------------------
DROP TABLE [dbo].[News]
GO
CREATE TABLE [dbo].[News] (
[id] int NOT NULL ,
[title] varchar(255) NULL ,
[message] text NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for PaymentRecords
-- ----------------------------
DROP TABLE [dbo].[PaymentRecords]
GO
CREATE TABLE [dbo].[PaymentRecords] (
[id] int NOT NULL ,
[user_id] int NULL ,
[amount] varchar(255) NULL ,
[remark] varchar(255) NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for RaceKits
-- ----------------------------
DROP TABLE [dbo].[RaceKits]
GO
CREATE TABLE [dbo].[RaceKits] (
[id] int NOT NULL ,
[name] varchar(255) NULL ,
[price] money NULL DEFAULT ((0)) ,
[stock] int NULL DEFAULT ((0)) ,
[description] text NULL ,
[created_at] int NULL DEFAULT ((0)) ,
[updated_at] int NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for RunnerEvents
-- ----------------------------
DROP TABLE [dbo].[RunnerEvents]
GO
CREATE TABLE [dbo].[RunnerEvents] (
[id] int NOT NULL ,
[user_id] int NULL ,
[event_id] int NULL ,
[racekit_id] int NULL ,
[paid] int NOT NULL DEFAULT ((0)) ,
[finished_at] int NOT NULL DEFAULT ((0)) ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for Schedules
-- ----------------------------
DROP TABLE [dbo].[Schedules]
GO
CREATE TABLE [dbo].[Schedules] (
[id] int NOT NULL ,
[event_id] int NULL ,
[name] varchar(255) NULL ,
[quantity] int NOT NULL DEFAULT ((0)) ,
[description] text NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for Verifications
-- ----------------------------
DROP TABLE [dbo].[Verifications]
GO
CREATE TABLE [dbo].[Verifications] (
[id] int NOT NULL ,
[user_id] int NULL ,
[token] varchar(255) NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Table structure for VolunteerSchedules
-- ----------------------------
DROP TABLE [dbo].[VolunteerSchedules]
GO
CREATE TABLE [dbo].[VolunteerSchedules] (
[id] int NOT NULL ,
[volunteer_id] int NULL ,
[schedule_id] int NULL ,
[created_at] int NOT NULL DEFAULT ((0)) ,
[updated_at] int NOT NULL DEFAULT ((0))
)


GO

-- ----------------------------
-- Indexes structure for table Charities
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Charities
-- ----------------------------
ALTER TABLE [dbo].[Charities] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table EventCategories
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EventCategories
-- ----------------------------
ALTER TABLE [dbo].[EventCategories] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table EventTypes
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EventTypes
-- ----------------------------
ALTER TABLE [dbo].[EventTypes] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table Feedbacks
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Feedbacks
-- ----------------------------
ALTER TABLE [dbo].[Feedbacks] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table MarathonEvents
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MarathonEvents
-- ----------------------------
ALTER TABLE [dbo].[MarathonEvents] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table Members
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Members
-- ----------------------------
ALTER TABLE [dbo].[Members] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Uniques structure for table Members
-- ----------------------------
ALTER TABLE [dbo].[Members] ADD UNIQUE ([email] ASC)
GO
ALTER TABLE [dbo].[Members] ADD UNIQUE ([idcard] ASC)
GO
ALTER TABLE [dbo].[Members] ADD UNIQUE ([username] ASC)
GO

-- ----------------------------
-- Indexes structure for table News
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table News
-- ----------------------------
ALTER TABLE [dbo].[News] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table PaymentRecords
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PaymentRecords
-- ----------------------------
ALTER TABLE [dbo].[PaymentRecords] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table RaceKits
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table RaceKits
-- ----------------------------
ALTER TABLE [dbo].[RaceKits] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table RunnerEvents
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table RunnerEvents
-- ----------------------------
ALTER TABLE [dbo].[RunnerEvents] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Uniques structure for table RunnerEvents
-- ----------------------------
ALTER TABLE [dbo].[RunnerEvents] ADD UNIQUE ([user_id] ASC, [event_id] ASC)
GO

-- ----------------------------
-- Indexes structure for table Schedules
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Schedules
-- ----------------------------
ALTER TABLE [dbo].[Schedules] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table Verifications
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Verifications
-- ----------------------------
ALTER TABLE [dbo].[Verifications] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table VolunteerSchedules
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table VolunteerSchedules
-- ----------------------------
ALTER TABLE [dbo].[VolunteerSchedules] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Feedbacks]
-- ----------------------------
ALTER TABLE [dbo].[Feedbacks] ADD FOREIGN KEY ([sender_id]) REFERENCES [dbo].[Members] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[MarathonEvents]
-- ----------------------------
ALTER TABLE [dbo].[MarathonEvents] ADD FOREIGN KEY ([category_id]) REFERENCES [dbo].[EventCategories] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[MarathonEvents] ADD FOREIGN KEY ([type_id]) REFERENCES [dbo].[EventTypes] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[PaymentRecords]
-- ----------------------------
ALTER TABLE [dbo].[PaymentRecords] ADD FOREIGN KEY ([user_id]) REFERENCES [dbo].[Members] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[RunnerEvents]
-- ----------------------------
ALTER TABLE [dbo].[RunnerEvents] ADD FOREIGN KEY ([event_id]) REFERENCES [dbo].[MarathonEvents] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RunnerEvents] ADD FOREIGN KEY ([racekit_id]) REFERENCES [dbo].[RaceKits] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RunnerEvents] ADD FOREIGN KEY ([user_id]) REFERENCES [dbo].[Members] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Schedules]
-- ----------------------------
ALTER TABLE [dbo].[Schedules] ADD FOREIGN KEY ([event_id]) REFERENCES [dbo].[MarathonEvents] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Verifications]
-- ----------------------------
ALTER TABLE [dbo].[Verifications] ADD FOREIGN KEY ([user_id]) REFERENCES [dbo].[Members] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[VolunteerSchedules]
-- ----------------------------
ALTER TABLE [dbo].[VolunteerSchedules] ADD FOREIGN KEY ([schedule_id]) REFERENCES [dbo].[Schedules] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[VolunteerSchedules] ADD FOREIGN KEY ([volunteer_id]) REFERENCES [dbo].[Members] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
