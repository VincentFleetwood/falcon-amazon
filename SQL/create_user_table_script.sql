USE FalconAmazonDB;

CREATE TABLE tbl_users 
(
    id INT NOT NULL IDENTITY PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    password_hash VARCHAR(120) NOT NULL,
    failed_login_attempts INT NOT NULL,
    date_added DATE NOT NULL,
    date_last_modified DATE NOT NULL,
    is_deleted BIT NOT NULL

);

