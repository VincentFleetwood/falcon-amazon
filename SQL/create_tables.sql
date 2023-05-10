USE FalconAmazonDB;

CREATE TABLE tbl_addresses
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	address_line_1 VARCHAR(200) NOT NULL,
	address_line_2 VARCHAR(200) NULL,
	city VARCHAR(100) NOT NULL,
	postcode VARCHAR(20) NOT NULL,
	country VARCHAR(50) NOT NULL,
);

CREATE TABLE tbl_users 
(
    id INT NOT NULL IDENTITY PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    password_hash VARCHAR(120) NOT NULL,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	email VARCHAR(200) UNIQUE NOT NULL,
	phone_number VARCHAR(15) UNIQUE NOT NULL,
	dob DATE NOT NULL,
	address_id INT NOT NULL,
    date_added DATETIME NOT NULL,
    date_last_modified DATETIME NOT NULL,
	failed_login_attempts INT NOT NULL,
    is_deleted BIT NOT NULL,

	FOREIGN KEY (address_id) REFERENCES dbo.tbl_addresses(id)
);

