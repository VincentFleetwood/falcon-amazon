use FalconAmazonDB

BULK INSERT dbo.tbl_users
FROM 'C:\Repositories\falcon-amazon\SQL\TestData\tbl_usersTestData.csv'
WITH (
    FORMATFILE = 'C:\Repositories\falcon-amazon\SQL\TestData\tbl_usersTestDataFormat.xml',
    FIRSTROW = 2 -- skip the header row
);
