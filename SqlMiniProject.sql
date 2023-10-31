CREATE DATABASE Category;

USE Category;

SELECT*FROM UserTabel;

DROP TABLE UserTabel;

DROP TABLE Category;

DELETE FROM Category;

DELETE FROM UserTabel;




CREATE TABLE UserTabel (
    userId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	userName VARCHAR(255) NOT NULL,
    useremail VARCHAR(255) NOT NULL,
    userpassword VARCHAR(255) NOT NULL
);

CREATE TABLE Category (
    CategoryId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    NameCategory varchar (255) NOT NULL,
	userId INT FOREIGN KEY (userId) REFERENCES UserTabel(userId)
);

INSERT INTO UserTabel VALUES ('Admin','admin@gmail.com','123');
INSERT INTO Category VALUES ('Minuman','7'),('Makanan','7'),('Sayuran','7'),('Buah','7'),('Obat','7');


