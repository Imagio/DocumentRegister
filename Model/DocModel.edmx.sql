



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 09/11/2012 12:36:10
-- Generated from EDMX file: D:\imagio-sources\DocumentRegister\Model\DocModel.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------

DROP DATABASE IF EXISTS `docs`;
CREATE DATABASE `docs` CHAR set=utf8;
USE `docs`;

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `Files` DROP CONSTRAINT `FK_DocumentFile`;
--    ALTER TABLE `MonitoringInfoes` DROP CONSTRAINT `FK_MonitoringMonitoringInfo`;
--    ALTER TABLE `MonitoringInfoes` DROP CONSTRAINT `FK_DocumentMonitoringInfo`;
--    ALTER TABLE `DepartmentDepartmentGroup` DROP CONSTRAINT `FK_DepartmentDepartmentGroup_Department`;
--    ALTER TABLE `DepartmentDepartmentGroup` DROP CONSTRAINT `FK_DepartmentDepartmentGroup_DepartmentGroup`;
--    ALTER TABLE `DocumentDepartment` DROP CONSTRAINT `FK_DocumentDepartment_Document`;
--    ALTER TABLE `DocumentDepartment` DROP CONSTRAINT `FK_DocumentDepartment_Department`;
--    ALTER TABLE `Employees` DROP CONSTRAINT `FK_DepartmentExexcutor`;
--    ALTER TABLE `Employees` DROP CONSTRAINT `FK_ExexcutorAccount`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `Documents`;
    DROP TABLE IF EXISTS `Files`;
    DROP TABLE IF EXISTS `Monitorings`;
    DROP TABLE IF EXISTS `MonitoringInfoes`;
    DROP TABLE IF EXISTS `Departments`;
    DROP TABLE IF EXISTS `DepartmentGroups`;
    DROP TABLE IF EXISTS `Employees`;
    DROP TABLE IF EXISTS `Accounts`;
    DROP TABLE IF EXISTS `DepartmentDepartmentGroup`;
    DROP TABLE IF EXISTS `DocumentDepartment`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Documents'

CREATE TABLE `Documents` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Num` longtext  NULL,
    `RegistrationDate` datetime  NULL,
    `Name` longtext  NULL,
    `Note` longtext  NULL
);

-- Creating table 'Files'

CREATE TABLE `Files` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` longtext  NOT NULL,
    `Data` varbinary(100)  NOT NULL,
    `Document_Id` int  NULL
);

-- Creating table 'Monitorings'

CREATE TABLE `Monitorings` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` longtext  NOT NULL
);

-- Creating table 'MonitoringInfoes'

CREATE TABLE `MonitoringInfoes` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Date` datetime  NOT NULL,
    `Monitoring_Id` int  NOT NULL,
    `DocumentMonitoringInfo_MonitoringInfo_Id` int  NOT NULL
);

-- Creating table 'Departments'

CREATE TABLE `Departments` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Code` longtext  NOT NULL,
    `Name` longtext  NOT NULL
);

-- Creating table 'SendingGroups'

CREATE TABLE `SendingGroups` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` longtext  NOT NULL
);

-- Creating table 'Employees'

CREATE TABLE `Employees` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` longtext  NOT NULL,
    `Department_Id` int  NULL,
    `Account_Id` int  NULL
);

-- Creating table 'Accounts'

CREATE TABLE `Accounts` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `UserName` longtext  NOT NULL,
    `Password` longtext  NOT NULL,
    `IsActive` bool  NOT NULL,
    `LastAccessTime` datetime  NULL,
    `Privileges_CanUseFullClient` bool  NOT NULL
);

-- Creating table 'DepartmentDepartmentGroup'

CREATE TABLE `DepartmentDepartmentGroup` (
    `Departments_Id` int  NOT NULL,
    `DepartmentDepartmentGroup_Department_Id` int  NOT NULL
);

-- Creating table 'DocumentDepartment'

CREATE TABLE `DocumentDepartment` (
    `DocumentDepartment_Department_Id` int  NOT NULL,
    `SendDepartments_Id` int  NOT NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on `Departments_Id`, `DepartmentDepartmentGroup_Department_Id` in table 'DepartmentDepartmentGroup'

ALTER TABLE `DepartmentDepartmentGroup`
ADD CONSTRAINT `PK_DepartmentDepartmentGroup`
    PRIMARY KEY (`Departments_Id`, `DepartmentDepartmentGroup_Department_Id` );

-- Creating primary key on `DocumentDepartment_Department_Id`, `SendDepartments_Id` in table 'DocumentDepartment'

ALTER TABLE `DocumentDepartment`
ADD CONSTRAINT `PK_DocumentDepartment`
    PRIMARY KEY (`DocumentDepartment_Department_Id`, `SendDepartments_Id` );



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `Document_Id` in table 'Files'

ALTER TABLE `Files`
ADD CONSTRAINT `FK_DocumentFile`
    FOREIGN KEY (`Document_Id`)
    REFERENCES `Documents`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentFile'

CREATE INDEX `IX_FK_DocumentFile` 
    ON `Files`
    (`Document_Id`);

-- Creating foreign key on `Monitoring_Id` in table 'MonitoringInfoes'

ALTER TABLE `MonitoringInfoes`
ADD CONSTRAINT `FK_MonitoringMonitoringInfo`
    FOREIGN KEY (`Monitoring_Id`)
    REFERENCES `Monitorings`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MonitoringMonitoringInfo'

CREATE INDEX `IX_FK_MonitoringMonitoringInfo` 
    ON `MonitoringInfoes`
    (`Monitoring_Id`);

-- Creating foreign key on `DocumentMonitoringInfo_MonitoringInfo_Id` in table 'MonitoringInfoes'

ALTER TABLE `MonitoringInfoes`
ADD CONSTRAINT `FK_DocumentMonitoringInfo`
    FOREIGN KEY (`DocumentMonitoringInfo_MonitoringInfo_Id`)
    REFERENCES `Documents`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentMonitoringInfo'

CREATE INDEX `IX_FK_DocumentMonitoringInfo` 
    ON `MonitoringInfoes`
    (`DocumentMonitoringInfo_MonitoringInfo_Id`);

-- Creating foreign key on `Departments_Id` in table 'DepartmentDepartmentGroup'

ALTER TABLE `DepartmentDepartmentGroup`
ADD CONSTRAINT `FK_DepartmentDepartmentGroup_Department`
    FOREIGN KEY (`Departments_Id`)
    REFERENCES `Departments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `DepartmentDepartmentGroup_Department_Id` in table 'DepartmentDepartmentGroup'

ALTER TABLE `DepartmentDepartmentGroup`
ADD CONSTRAINT `FK_DepartmentDepartmentGroup_DepartmentGroup`
    FOREIGN KEY (`DepartmentDepartmentGroup_Department_Id`)
    REFERENCES `SendingGroups`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentDepartmentGroup_DepartmentGroup'

CREATE INDEX `IX_FK_DepartmentDepartmentGroup_DepartmentGroup` 
    ON `DepartmentDepartmentGroup`
    (`DepartmentDepartmentGroup_Department_Id`);

-- Creating foreign key on `DocumentDepartment_Department_Id` in table 'DocumentDepartment'

ALTER TABLE `DocumentDepartment`
ADD CONSTRAINT `FK_DocumentDepartment_Document`
    FOREIGN KEY (`DocumentDepartment_Department_Id`)
    REFERENCES `Documents`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `SendDepartments_Id` in table 'DocumentDepartment'

ALTER TABLE `DocumentDepartment`
ADD CONSTRAINT `FK_DocumentDepartment_Department`
    FOREIGN KEY (`SendDepartments_Id`)
    REFERENCES `Departments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentDepartment_Department'

CREATE INDEX `IX_FK_DocumentDepartment_Department` 
    ON `DocumentDepartment`
    (`SendDepartments_Id`);

-- Creating foreign key on `Department_Id` in table 'Employees'

ALTER TABLE `Employees`
ADD CONSTRAINT `FK_DepartmentExexcutor`
    FOREIGN KEY (`Department_Id`)
    REFERENCES `Departments`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentExexcutor'

CREATE INDEX `IX_FK_DepartmentExexcutor` 
    ON `Employees`
    (`Department_Id`);

-- Creating foreign key on `Account_Id` in table 'Employees'

ALTER TABLE `Employees`
ADD CONSTRAINT `FK_ExexcutorAccount`
    FOREIGN KEY (`Account_Id`)
    REFERENCES `Accounts`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExexcutorAccount'

CREATE INDEX `IX_FK_ExexcutorAccount` 
    ON `Employees`
    (`Account_Id`);

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
