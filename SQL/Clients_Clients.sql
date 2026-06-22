USE Clients;

--CREATE TABLE Clients(
	--ID INT PRIMARY KEY IDENTITY(1,1),Full_Name NVARCHAR(50),Mobile NVARCHAR(15),Service NVARCHAR(30),Description NVARCHAR(MAX),Job NVARCHAR(10),Date_Born DATE,Gender NVARCHAR(5),How_To_Introduce NVARCHAR(20),Payment NVARCHAR(15),Discount NVARCHAR(10),Debit NVARCHAR(15),Counter INT,Date_Coming DATE NOT NULL,Address NVARCHAR(MAX) NULL
	--);
--ALTER TABLE Clients
--ALTER COLUMN Discount NVARCHAR(100);
--ALTER TABLE Clients
--ALTER COLUMN All_Payment INT;
--ALTER TABLE Clients
--ADD Code NVARCHAR(6);
--INSERT INTO Clients(Full_Name,Mobile,Service,Description,Job,Date_Born,Gender,How_To_Introduce,Payment,Discount,Debit,Counter,Date_Coming,Address)
--VALUES ('','','',
--DELETE FROM Clients;
--ALTER TABLE Clients
--ALTER COLUMN Date_Born INT NULL;
--SELECT * FROM Clients;
--UPDATE Clients
--SET Date_Born = NULL;


--SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
--FROM INFORMATION_SCHEMA.COLUMNS
--WHERE TABLE_NAME = 'Clients';


--SELECT DISTINCT Date_Born
--FROM Clients;

--UPDATE Clients
--SET Date_Born = NULL;

--SELECT DISTINCT Date_Born
--FROM Clients;

--UPDATE Clients
--SET Date_Coming = NULL;


--SELECT DISTINCT Date_Coming
--FROM Clients;

--ALTER TABLE Clients
--ALTER COLUMN Date_Born DATE NOT NULL;
--ALTER TABLE Clients
--ALTER COLUMN Date_Coming DATE NOT NULL;


--DROP TABLE Clients;\


--EXEC sp_columns Clients;
