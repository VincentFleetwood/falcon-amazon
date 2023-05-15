USE FalconAmazonDB;

CREATE TABLE tbl_users 
(
    id INT NOT NULL IDENTITY PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    password_hash VARCHAR(120) NOT NULL,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	email_address VARCHAR(200) UNIQUE NOT NULL,
	telephone VARCHAR(15) UNIQUE NOT NULL,
	date_of_birth DATETIME NOT NULL,
    date_added DATETIME NOT NULL,
    date_last_modified DATETIME NOT NULL,
	failed_login_attempts INT NOT NULL,
    is_deleted BIT NOT NULL,

);

CREATE TABLE tbl_addresses
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	user_id INT NOT NULL,
	house_name_number VARCHAR(200) NOT NULL,
	street VARCHAR(200) NOT NULL,
	address_line_2 VARCHAR(200) NULL,
	address_line_3 VARCHAR(200) NULL,
	city VARCHAR(100) NOT NULL,
	postcode VARCHAR(20) NOT NULL,
	country VARCHAR(50) NOT NULL,
	is_business BIT NOT NULL,

    CONSTRAINT FK_address_user FOREIGN KEY(user_id)
    REFERENCES dbo.tbl_users(id)
);

CREATE TABLE tbl_user_tokens
(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	user_id INT NOT NULL,
	token UNIQUEIDENTIFIER NOT NULL,
	expiry_date DATETIME NOT NULL

	CONSTRAINT FK_user_tokens_user FOREIGN KEY(user_id)
    REFERENCES dbo.tbl_users(id)
);

