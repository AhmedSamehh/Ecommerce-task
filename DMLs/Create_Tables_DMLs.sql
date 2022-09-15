INSERT INTO dbo.Categories(Title, IconName)
VALUES 
( 'Food', 'local_mall'),
( 'Electronics','headphones')


INSERT INTO dbo.Subcategories(Title, CategoryId)
VALUES 
('Fruits', 1),
('Vegetables', 1)


INSERT INTO dbo.Products (Name, Price, CategoryId, SubcategoryId)
VALUES 
( 'Apple',18.99, 1, 1),
( 'Banana',4.5, 1, 1),
( 'Amaranth Leaves',18.99, 1, 2),
( 'Bitter Melon',4.5, 1, 2),
( 'Air purifier',20, 2, NULL),
( 'Air conditioner',33.88, 2, NULL)



