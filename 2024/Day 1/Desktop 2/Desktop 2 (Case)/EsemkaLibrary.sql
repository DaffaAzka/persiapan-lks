CREATE DATABASE EsemkaLibrary
GO
USE EsemkaLibrary
GO

CREATE TABLE Genre(
	id						INT				NOT NULL	IDENTITY,
	[name]					VARCHAR(200)	NOT NULL,
	created_at				DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at				DATETIME,
	PRIMARY KEY (id),
);

CREATE TABLE Book(
	id						INT				NOT NULL	IDENTITY,
	title					VARCHAR(200)	NOT NULL,
	author					VARCHAR(200)	NOT NULL,
	publish_date			DATE,
	stock					INT				NOT NULL,
	created_at				DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at				DATETIME,
	PRIMARY KEY (id),
);

CREATE TABLE BookGenre(
	id						INT				NOT NULL	IDENTITY,
	book_id					INT				NOT NULL,
	genre_id				INT				NOT NULL,
	created_at				DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at				DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (book_id) REFERENCES Book(id),
	FOREIGN KEY (genre_id) REFERENCES Genre(id),
);

CREATE TABLE [Member](
	id						INT				NOT NULL	IDENTITY,
	[name]					VARCHAR(200)	NOT NULL,
	email					VARCHAR(200)	NOT NULL,
	created_at				DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at				DATETIME,
	PRIMARY KEY (id),
);

CREATE TABLE Borrowing(
	id						INT				NOT NULL	IDENTITY,
	member_id				INT				NOT NULL,
	book_id					INT				NOT NULL,
	borrow_date				DATETIME		NOT NULL,
	return_date				DATETIME,
	fine					DECIMAL(10,2),
	created_at				DATETIME		NOT NULL,
	deleted_at				DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (member_id) REFERENCES [Member](id),
	FOREIGN KEY (book_id) REFERENCES Book(id),
);

INSERT INTO [Genre]([name]) VALUES('Action')
INSERT INTO [Genre]([name]) VALUES('Adventure')
INSERT INTO [Genre]([name]) VALUES('Childrens')
INSERT INTO [Genre]([name]) VALUES('Classics')
INSERT INTO [Genre]([name]) VALUES('Fantasy')
INSERT INTO [Genre]([name]) VALUES('Fiction')
INSERT INTO [Genre]([name]) VALUES('Historical')
INSERT INTO [Genre]([name]) VALUES('Horror')
INSERT INTO [Genre]([name]) VALUES('Romance')


INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Hunger Games Collections', 'Suzanne Collins', NULL, 1)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('Harry Potter Collections', 'J.K. Rowling', '06/21/2003', 1)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('To Kill a Mockingbird', 'Harper Lee', '07/11/1960', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('Pride and Prejudice', 'Jane Austen, Anna Quindlen', '01/28/2013', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('Twilight', 'Stephenie Meyer', '10/05/2005', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Book Thief', 'Markus Zusak', '09/01/2005', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Chronicles of Narnia', 'C.S. Lewis, Pauline Baynes', '10/28/1956', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('J.R.R. Tolkien 4-Book Boxed Set: The Hobbit and The Lord of the Rings', 'J.R.R. Tolkien', '10/20/1955', 1)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('Gone with the Wind', 'Margaret Mitchell', '06/30/1936', 5)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Fault in Our Stars', 'John Green', NULL, 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Hitchhiker''s Guide to the Galaxy', 'Douglas Adams', '10/12/1979', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Giving Tree', 'Shel Silverstein', '10/28/1964', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('Wuthering Heights', 'Emily Bronta', '12/28/1947', 3)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('The Da Vinci Code', 'Dan Brown', '03/18/2003', 10)
INSERT INTO [Book]([title], [author], [publish_date], [stock]) VALUES('Memoirs of a Geisha', 'Arthur Golden', '09/23/1997', 3)


INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(1, 1)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(1, 2)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(1, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(1, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(2, 2)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(2, 3)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(2, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(2, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(2, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(3, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(3, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(3, 7)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(4, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(4, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(4, 7)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(4, 9)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(5, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(5, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(5, 9)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(6, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(6, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(6, 7)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(7, 2)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(7, 3)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(7, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(7, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(7, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(8, 2)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(8, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(8, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(8, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(9, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(9, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(9, 7)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(9, 9)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(10, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(10, 9)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(11, 2)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(11, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(11, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(11, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(12, 3)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(12, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(12, 5)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(12, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(13, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(13, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(13, 7)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(13, 9)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(14, 2)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(14, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(15, 4)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(15, 6)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(15, 7)
INSERT INTO [BookGenre]([book_id], [genre_id]) VALUES(15, 9)


INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Yvon Blackaller', 'yblackaller0@meetup.com', '11/30/2023', '12/13/2023')
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Cyrill McAnellye', 'cmcanellye1@marriott.com', '02/24/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Gussie Wattingham', 'gwattingham2@csmonitor.com', '03/25/2024', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Lyndsey Adamkiewicz', 'ladamkiewicz3@etsy.com', '06/08/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Riordan Spittle', 'rspittle4@macromedia.com', '05/29/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Shelly Beddo', 'sbeddo5@bbc.co.uk', '09/15/2023', '10/23/2023')
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Harrison Pullinger', 'hpullinger6@prnewswire.com', '11/23/2023', '01/10/2024')
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Trueman Tolfrey', 'ttolfrey7@illinois.edu', '03/17/2024', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Marybeth Matschek', 'mmatschek8@timesonline.co.uk', '02/02/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Stephine McColm', 'smccolm9@amazon.com', '07/30/2023', '01/07/2024')
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Serge Risborough', 'srisborougha@miibeian.gov.cn', '03/01/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Rosemary Grimmer', 'rgrimmerb@ebay.com', '09/09/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Lucila Brixey', 'lbrixeyc@sakura.ne.jp', '01/18/2023', '01/17/2024')
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Fairfax Wilsone', 'fwilsoned@ft.com', '03/13/2024', '03/01/2024')
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Valerye Quartley', 'vquartleye@nymag.com', '04/19/2024', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Megan Calderon', 'mcalderonf@ustream.tv', '05/15/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Minta Covendon', 'mcovendong@cpanel.net', '03/11/2024', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Irwin Acheson', 'iachesonh@noaa.gov', '12/28/2023', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Rina Iacofo', 'riacofoi@people.com.cn', '02/19/2024', NULL)
INSERT INTO [Member]([name], [email], [created_at], [deleted_at]) VALUES('Clint Huckerby', 'chuckerbyj@skype.com', '03/12/2024', '12/13/2024')


INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(18, 1, '04/08/2024', '04/15/2024', 0, '04/20/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(18, 2, '04/08/2024', '04/21/2024', 12000, '04/20/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(18, 3, '04/08/2024', '04/15/2024', 0, '04/20/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(2, 5, '04/11/2024', '04/15/2024', NULL, '04/11/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(4, 12, '04/12/2024', '04/13/2024', NULL, '04/12/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(9, 9, '04/13/2024', '04/20/2024', NULL, '04/13/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(11, 1, '04/17/2024', NULL, NULL, '04/17/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(16, 11, '04/17/2024', NULL, NULL, '04/17/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(11, 2, '04/18/2024', NULL, NULL, '04/18/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(18, 14, '04/22/2024', NULL, NULL, '04/22/2024')
INSERT INTO [Borrowing]([member_id], [book_id], [borrow_date], [return_date], [fine], [created_at]) VALUES(11, 7, '04/23/2024', NULL, NULL, '04/23/2024')


--USE master
--GO
--DROP DATABASE EsemkaLibrary

	

