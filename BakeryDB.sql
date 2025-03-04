CREATE TABLE BakeryItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    Price DECIMAL(10,2),
    ImageUrl NVARCHAR(255)
);

INSERT INTO BakeryItems (Name, Description, Price, ImageUrl)
VALUES 
('Croissant', 'Flaky and buttery pastry', 2.50, 'https://static01.nyt.com/images/2021/04/07/dining/06croissantsrex1/merlin_184841898_ccc8fb62-ee41-44e8-9ddf-b95b198b88db-threeByTwoMediumAt2X.jpg?quality=75&auto=webp'),
('Chocolate Cake', 'Rich chocolate cake', 5.00, 'https://sugargeekshow.com/wp-content/uploads/2023/10/easy_chocolate_cake_slice.jpg');
('Cupcakes', 'Cupcakes with chocolate chips', 4.00, 'https://images.pexels.com/photos/4099124/pexels-photo-4099124.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2');

