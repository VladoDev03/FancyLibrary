use fancy_library_official;

SELECT * FROM aspnetusers;
SELECT * FROM books;
SELECT * FROM authors;
SELECT * FROM log_data;
SELECT * FROM countries;
SELECT * FROM users_books;
SELECT * FROM contacts;

INSERT INTO aspnetusers (id, UserName, password, first_name, middle_name, last_name, log_data_id, contact_id, age, birthday, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
VALUES
	(1, "vladsto", "Salamur$12", "Vladimir", "Rumenov", "Stoyanov", 1, 1, 17, '2003-05-20', 1, 1, 0, 0, 0),
	(2, "ansto", "Salamur$12", "Anna", "Rumenova", "Stoyanova", 2, 2, 15, '2005-09-06', 1, 1, 0, 0, 0),
	(3, "dansto", "Salamur$12", "Yordan", "Emilov", "Stoyanov", 3, 3, 10, '2010-05-05', 1, 1, 0, 0, 0),
	(4, "rumsto", "Salamur$12", "Rumen", "Yordanov", "Stoyanov", 4, NULL, 50, '1970-03-22', 1, 1, 0, 0, 0),
	(5, "nadsto", "Salamur$12", "Nadejda", "Ignatova", "Stoyanova", 5, NULL, 42, '1979-03-15', 1, 1, 0, 0, 0),
	(6, "emsto", "Salamur$12", "Emil", "Yordanov", "Stoyanov", 6, NULL, 46, '1974-05-15', 1, 1, 0, 0, 0),
	(7, "jonkata", "Salamur$12", "Joan", NULL, "Nikolov", 7, NULL, 18, '2003-02-08', 1, 1, 0, 0, 0),
	(8, "kitkat", "Salamur$12", "Katrin", NULL, "Georgieva", 8, NULL, 18, '2003-05-18', 1, 1, 0, 0, 0),
	(9, "peshoto125", "Salamur$12", "Petar", NULL, "Martinov", 9, NULL, 27, '1994-03-27', 1, 1, 0, 0, 0);
    
INSERT INTO contacts (id, email, phone)
VALUES
	(1, "vlado@dev.git", "1234567890"),
	(2, "ankis@sladkis.qet", "0123456789"),
	(3, "dan@dragon.bak", "0987654321");

INSERT INTO log_data (id, register_date, last_time_logged_in, is_online, times_logged_in)
VALUES
	(1, '2021-03-21', '2021-02-03', 0, '19'),
	(2, '2021-03-21', '2021-02-03', 0, '28'),
	(3, '2021-03-21', '2021-02-03', 0, '37'),
	(4, '2021-03-21', '2021-02-03', 0, '46'),
	(5, '2021-03-21', '2021-02-03', 0, '55'),
	(6, '2021-03-21', '2021-02-03', 0, '64'),
	(7, '2021-03-21', '2021-02-03', 0, '73'),
	(8, '2021-03-21', '2021-02-03', 0, '82'),
	(9, '2021-03-21', '2021-02-03', 0, '91');

INSERT INTO countries (id, name)
VALUES
	(1, 'Bulgaria'),
	(2, 'Russia'),
	(3, 'USA'),
	(4, 'England'),
	(5, 'Spain'),
	(6, 'Germany'),
	(7, 'Grreece');

INSERT INTO users_books (user_id, book_id)
VALUES
	(8, 1),
	(8, 2),
	(8, 3),
	(8, 4),
	(8, 5),
	(8, 6),
	(8, 7),
	(8, 8),
	(8, 10),
	(9, 11),
	(9, 12),
	(9, 13),
	(9, 14),
	(9, 15),
	(9, 16),
	(9, 17),
	(9, 18),
	(9, 19),
	(9, 20),
	(10, 21),
	(10, 22),
	(10, 23),
	(10, 24),
	(10, 25),
	(10, 26),
	(10, 27),
	(10, 28),
	(10, 29),
	(11, 30),
	(11, 31),
	(11, 32),
	(11, 33),
	(11, 34),
	(11, 35),
	(11, 36),
	(11, 37),
	(11, 38),
	(12, 1),
	(12, 3),
	(12, 5),
	(12, 7),
	(12, 11),
	(12, 13),
	(12, 15),
	(12, 17),
	(12, 19),
	(13, 2),
	(13, 4),
	(13, 6),
	(13, 8),
	(13, 10),
	(13, 12),
	(13, 14),
	(13, 16),
	(13, 18),
	(13, 20),
	(14, 21),
	(14, 23),
	(14, 25),
	(14, 27),
	(14, 29),
	(14, 31),
	(14, 33),
	(14, 35),
	(14, 37),
	(15, 22),
	(15, 24),
	(15, 26),
	(15, 28),
	(15, 30),
	(15, 32),
	(15, 34),
	(15, 36),
    (16, 3),
    (16, 7),
    (16, 12),
    (16, 15),
    (16, 17),
    (16, 19),
    (16, 21),
    (16, 24),
    (16, 25),
    (16, 27),
    (16, 31),
    (16, 32),
    (16, 35),
    (16, 36),
    (16, 37);

INSERT INTO books (id, title, genre, pages, year, author_id)
VALUES
	(1, "Matilda", "fiction", 201, 1974, 2),
	(2, "The secret garden", "Children literature", 274, 1863, 3),
	(3, "The witches", "fiction", 286, 1965, 2),
	(4, "Travel around the world in 80 days", "adventure novel", 235, 1873, 4),
	(5, "George's marvelous medicine", "science fiction", 130, 1981, 2),
	(6, "Charley and the chocolate factory", "children literature", 226, 1980, 2),
	(7, "White fang", "adventure novel", 304, 1906, 5),
	(8, "Escape from the island of the lost", "adventure novel", 295, 2004, 6),
	(10, "Captain's Blood diary", "adventure novel", 341, 1874, 7),
	(11, "The hitchhicker's guide to the galaxy", "science fiction", 297, 1984, 8),
	(12, "The force", "fantacy", 198, 1987, 9),
	(13, "The dark villain", "fantacy", 200, 1989, 10),
	(14, "Dracula", "horror", 457, 1987, 11),
	(15, "Murder in Orient express", "criminal novel", 167, 1922, 1),
	(16, "Death near Neil", "criminal novel", 233, 1964, 1),
	(17, "The phantom of the opera", "horror", 261, 1910, 12),
	(18, "Murder on the golf course", "criminal novel", 204, 1957, 1),
	(19, "Travel to the centre of the Earth", "adventure novel", 276, 1854, 4),
	(20, "Tragedy del Arte", "criminal narratives", 206, 1834, 1),
	(21, "Pride and prejudice", "classical literature", 367, 1798, 13),
	(22, "Northanger Abbey", "classical literature", 359, 1807, 13),
	(23, "Congo", "criminal novel", 406, 1986, 14),
	(24, "The forgotten garden", "mystery", 436, 2008, 23),
	(25, "Mystery in the Blue express", "criminal novel", 239, 1847, 1),
	(26, "Butterflies' daughter", "adventure novel", 408, 2014, 15),
	(27, "Christmas song", "fiction", 198, 1898, 16),
	(28, "Murder before Christmas", "criminal novel", 222, 1938, 1),
	(29, "Narnia's chronics", "adventure novel", 201, 1958, 17),
	(30, "Seven days of our life", "contemporary literature", 362, 2001, 24),
	(31, "Christmas in Silver Falls", "contemporary literature", 285, 2018, 18),
	(32, "To skip Christmas", "criminal novel", 243, 2004, 25),
	(33, "The Christmas egg", "criminal novel", 249, 1968, 19),
	(34, "Grandfather Gorio", "classical literature", 305, 1844, 20),
	(35, "Look in the future", "science fiction", 224, 2007, 22),
	(36, "Me before you", "contemporary literature", 334, 2013, 21),
	(37, "In the wildreness", "criminal novel", 308, 2019, 26),
	(38, "Jaw", "horror", 296, 1967, 27);

INSERT INTO authors(id, first_name, middle_name, last_name, nickname, birthday)
VALUES
	(1, "Agatha", NULL, "Christie", NULL, "1890-09-15"),
	(2, "Roald", NULL, "Dahl", NULL, "1916-09-13"),
	(3, "Frances", "Hadgson", "Burnett", NULL, "1849-11-24"),
	(4, "Jules", "Gabriel", "Verne", NULL, "1828-02-08"),
	(5, "Jack", NULL, "London", NULL, "1876-01-12"),
	(6, "Melissa", NULL, "de la Cruz", NULL, "1971-09-07"),
	(7, "Rafael", NULL, "Sabatini", NULL, "1875-04-29"),
	(8, "Douglas", NULL, "Adams", NULL, "1952-03-11"),
	(9, "Dave", NULL, "Wolverton", NULL, NULL),
	(10, "Jude", NULL, "Blundel", "Jude Watson", "1956-10-26"),
	(11, "Bram", NULL, "Stoker", NULL, "1847-11-08"),
	(12, "Gaston", NULL, "Leroux", NULL, "1868-05-06"),
	(13, "Jane", NULL, "Austin", NULL, "1775-12-16"),
	(14, "Michael", NULL, "Crichton", NULL, "1942-10-23"),
	(15, "Mary", "Alice", "Monroe", NULL, "1960-05-26"),
	(16, "Charles", NULL, "Dickens", NULL, "1812-02-07"),
	(17, "Clive", "Steples", "Lewis", NULL, "1898-11-29"),
	(18, "Jane", NULL, "Hale", NULL, "1980-07-13"),
	(19, "Mary", "Jane", "Kelly", NULL, "1888-11-09"),
	(20, "Onore", NULL, "de Balzac", NULL, "1799-05-20"),
	(21, "Jojo", NULL, "Moyes", NULL, "1969-08-04"),
    (22, "Robert", NULL, "Sawyer", NULL, "1960-04-29"),
    (23, "Kate", NULL, "Morton", NULL, "1976-05-08"),
    (24, "Francheska", NULL, "Hornak", NULL, "1977-08-03"),
    (25, "John", NULL, "Grisham", NULL, "1955-02-08"),
    (26, "Jane", NULL, "Harper", NULL, "1978-04-22"),
    (27, "Steven", NULL, "Benchley", NULL, "1940-05-08");
        
DELETE FROM aspnetusers
WHERE id > 0;

DELETE FROM books
WHERE id > 0;

DELETE FROM authors
WHERE id > 0;

DELETE FROM users_books
WHERE user_id > 0;

DELETE FROM contacts
WHERE id > 0;

DELETE FROM log_data
WHERE id > 0;

DELETE FROM countries
WHERE id > 0;