CREATE DATABASE fancy_library;

USE fancy_library;

CREATE TABLE countries (
	id INT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE authors (
	id INT PRIMARY KEY AUTO_INCREMENT,
	first_name VARCHAR(50) NOT NULL,
	middle_name VARCHAR(50),
	last_name VARCHAR(50) NOT NULL,
	birthday DATE,
	nickname VARCHAR(50) UNIQUE,
	country_id INT,
    FOREIGN KEY (country_id)
    REFERENCES countries(id)
);

CREATE TABLE contacts (
	id INT PRIMARY KEY AUTO_INCREMENT,
	email VARCHAR(50) UNIQUE,
	phone VARCHAR(50) UNIQUE
);

CREATE TABLE log_data (
	id INT PRIMARY KEY AUTO_INCREMENT,
	last_time_logged_in DATE NOT NULL,
	is_online BIT NOT NULL,
	register_date DATE NOT NULL,
	times_logged_in INT NOT NULL
);

CREATE TABLE books (
	id INT PRIMARY KEY AUTO_INCREMENT,
	title VARCHAR(50) NOT NULL UNIQUE,
	genre VARCHAR(50) NOT NULL,
	`year` INT,
	pages INT,
	author_id INT NOT NULL,
	inspired_by_id INT,
    FOREIGN KEY (author_id)
    REFERENCES authors(id),
    FOREIGN KEY (inspired_by_id)
    REFERENCES books(id)
);

CREATE TABLE users (
	id INT PRIMARY KEY AUTO_INCREMENT,
	username VARCHAR(50) NOT NULL UNIQUE,
	`password` VARCHAR(50) NOT NULL,
	first_name VARCHAR(50) NOT NULL,
	middle_name VARCHAR(50),
	last_name VARCHAR(50) NOT NULL,
	age INT NOT NULL,
	birthday DATE NOT NULL,
	contact_id INT UNIQUE,
	log_data_id INT NOT NULL UNIQUE,
	country_id INT,
    FOREIGN KEY (contact_id)
    REFERENCES contacts(id),
    FOREIGN KEY (log_data_id)
    REFERENCES log_data(id),
    FOREIGN KEY (country_id)
    REFERENCES countries(id)
);

CREATE TABLE users_books (
	user_id INT UNIQUE,
	book_id INT UNIQUE,
    FOREIGN KEY (user_id)
    REFERENCES users(id),
    FOREIGN KEY (book_id)
    REFERENCES books(id),
	PRIMARY KEY (user_id, book_id)
);