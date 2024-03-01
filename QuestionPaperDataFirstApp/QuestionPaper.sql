CREATE DATABASE QuestionSystem;use QuestionSystem;CREATE TABLE Users (    id INT IDENTITY(1,1) PRIMARY KEY,    name NVARCHAR(30) NOT NULL,    email NVARCHAR(30) NOT NULL,    password NVARCHAR(MAX) NOT NULL,    role VARCHAR(20) CONSTRAINT CK_Role CHECK (role IN ('student', 'admin', 'teacher')) DEFAULT 'student' NOT NULL);INSERT INTO Users (name, email, password)VALUES ('haresh', 'haresh@gmail.com', '123456', 'admin');INSERT INTO Users (name, email, password)VALUES ('harry', 'harry@gmail.com', '123456', 'teacher');INSERT INTO Users (name, email, password)VALUES ('hari', 'hari@gmail.com', '123456', 'student');CREATE TABLE QuestionsPaper (    paperId INT IDENTITY(1,1) PRIMARY KEY,    title VARCHAR(255) NOT NULL,    description NVARCHAR(MAX) NOT NULL,	noOfQuestions int check(noOfQuestions <= 10) not null,	status VARCHAR(20) CONSTRAINT CK_Status CHECK (status IN ('approved', 'pending', 'rejected')) DEFAULT 'pending' NOT NULL,    creation_date datetime DEFAULT getdate(),);alter table QuestionsPaper add userId int FOREIGN KEY REFERENCES Users(id)ALTER TABLE QuestionsPaper
ALTER COLUMN userId INT NOT NULL;INSERT INTO QuestionsPaper (title, description, noOfQuestions)VALUES ('Maths', 'Final exam for the semester', 5);CREATE TABLE Questions (    queId INT IDENTITY(1,1) PRIMARY KEY,    question nvarchar(max) not null,	opt1 nvarchar(50) not null,	opt2 nvarchar(50) not null,	opt3 nvarchar(50) not null,	opt4 nvarchar(50) not null,	answer nvarchar(50) not null,    paperId int FOREIGN KEY REFERENCES QuestionsPaper(paperId));INSERT INTO Questions (question, opt1, opt2, opt3, opt4, answer, paperId)VALUES ('What is the capital of France?', 'Paris', 'Berlin', 'London', 'Rome', 'Paris', 1);INSERT INTO Questions (question, opt1, opt2, opt3, opt4, answer, paperId)VALUES ('What is the capital of France?', 'Paris', 'Berlin', 'London', 'Rome', 'Paris', 1);INSERT INTO Questions (question, opt1, opt2, opt3, opt4, answer, paperId)VALUES ('What is the capital of France?', 'Paris', 'Berlin', 'London', 'Rome', 'Paris', 1);INSERT INTO Questions (question, opt1, opt2, opt3, opt4, answer, paperId)VALUES ('What is the capital of France?', 'Paris', 'Berlin', 'London', 'Rome', 'Paris', 1);INSERT INTO Questions (question, opt1, opt2, opt3, opt4, answer, paperId)VALUES ('What is the capital of France?', 'Paris', 'Berlin', 'London', 'Rome', 'Paris', 1);CREATE TABLE Answer (    ansId INT IDENTITY(1,1) PRIMARY KEY,	paperId int FOREIGN KEY REFERENCES QuestionsPaper(paperId),	userId int FOREIGN KEY REFERENCES Users(id),	score int not null,);