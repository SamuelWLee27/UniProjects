--drop table Customers
--drop table Products
--drop table Purchases


CREATE TABLE Customers (
CustomerID int PRIMARY KEY,
FName varchar(20) NOT NULL,
LName varchar(20) NOT NULL,
Sport varchar(20) NOT NULL,
)

CREATE TABLE Products (
ProductID int PRIMARY KEY,
ProductDescription VARCHAR(20),
UnitPrice REAL,
Category VARCHAR(20))

CREATE TABLE Purchases(
OrderID int IDENTITY(1,1) PRIMARY KEY,
CustomerID int NOT NULL, 
ProductID int NOT NULL,
Quantity int,
PurchaseDate DATE NOT NULL,
FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
FOREIGN KEY (ProductID) REFERENCES Products (ProductID))

insert into Customers values (1,'Cristiano','Ronaldo','soccer')
insert into Customers values (2,'Sam','Cane','rugby')
insert into Customers values (3,'LeBron','James','basketball')
insert into Customers values (4,'Lydia','Ko','golf')
insert into Customers values (5,'Nilesh','Kanji','squash')
insert into Customers values (6,'Roger','Federer','tennis')
insert into Customers values (7,'Portia','Woodman','rugby')
insert into Customers values (8,'Rory','McIlroy','golf')
insert into Customers values (9,'Usain','Bolt','athletics')
insert into Customers values (10,'Valarie','Adams','athletics')
insert into Customers values (11,'James','Rodriguez','soccer')
insert into Customers values (12,'Stephen','Adams','basketball')
insert into Customers values (13,'Ross','Taylor','cricket')
insert into Customers values (14,'Te Taka','Keegan','motor racing')
insert into Customers values (15,'Scott','Dixon','motor racing')
insert into Customers values (16,'Tom','Walsh','athletics')


insert into Products values (1, 'Bag', 42, 'equipment')
insert into Products values (2, 'Cap', 29, 'headwear')
insert into Products values (3, 'Shirt', 35, 'clothing')
insert into Products values (4, 'Shorts', 22, 'clothing')
insert into Products values (5, 'Socks', 8, 'clothing')
insert into Products values (6, 'Sun Block', 5, 'equipment')
insert into Products values (7, 'Sun Glasses', 78, 'headwear')
insert into Products values (8, 'Wax', 14, 'equipment')
insert into Products values (9, 'Helmet', 42, 'headwear')
insert into Products values (10, 'Gloves', 9, 'equipment')
insert into Products values (11, 'Ear plugs', 2, 'headwear')
insert into Products values (12, 'Jersey', 89, 'clothing')


insert into Purchases values (1,2,4,'2022-4-6')
insert into Purchases values (2,3,1,'2022-4-7')
insert into Purchases values (4,4,2,'2022-4-7')
insert into Purchases values (4,5,1,'2022-4-7')
insert into Purchases values (3,6,2,'2022-4-7')
insert into Purchases values (4,4,3,'2022-4-8')
insert into Purchases values (4,7,1,'2022-4-8')
insert into Purchases values (2,1,1,'2022-4-8')
insert into Purchases values (5,5,6,'2022-4-8')
insert into Purchases values (3,3,1,'2022-4-8')
insert into Purchases values (1,5,2,'2022-4-9')
insert into Purchases values (2,3,1,'2022-4-9')
insert into Purchases values (8,2,2,'2022-4-9')
insert into Purchases values (5,4,7,'2022-4-9')
insert into Purchases values (3,7,1,'2022-4-9')
insert into Purchases values (1,1,2,'2022-4-10')
insert into Purchases values (9,4,1,'2022-4-10')
insert into Purchases values (9,2,2,'2022-4-10')
insert into Purchases values (6,5,1,'2022-4-10')
insert into Purchases values (5,4,4,'2022-4-10')
insert into Purchases values (1,5,2,'2022-4-13')
insert into Purchases values (4,7,1,'2022-4-13')
insert into Purchases values (5,4,5,'2022-4-13')
insert into Purchases values (3,3,7,'2022-4-13')
insert into Purchases values (9,2,2,'2022-4-14')
insert into Purchases values (2,4,1,'2022-4-14')
insert into Purchases values (5,5,8,'2022-4-14')
insert into Purchases values (9,3,3,'2022-4-15')
insert into Purchases values (3,5,4,'2022-4-15')
insert into Purchases values (1,6,3,'2022-5-02')
insert into Purchases values (3,2,1,'2022-5-03')
insert into Purchases values (11,2,5,'2022-5-04')
insert into Purchases values (7,12,1,'2022-5-10')
insert into Purchases values (11,9,2,'2022-5-13')
insert into Purchases values (12,12,1,'2022-5-13')
insert into Purchases values (12,11,5,'2022-5-13')
insert into Purchases values (16,10,2,'2022-5-13')
insert into Purchases values (14,9,2,'2022-5-14')
insert into Purchases values (15,4,1,'2022-5-14')
insert into Purchases values (16,12,8,'2022-5-14')
insert into Purchases values (15,11,3,'2022-5-15')
insert into Purchases values (14,10,4,'2022-5-15')
insert into Purchases values (12,9,3,'2022-6-02')
insert into Purchases values (11,12,1,'2022-6-03')
insert into Purchases values (15,11,2,'2022-6-04')

Select * from Customers
Select * from Products
Select * from Purchases

--Name: Samuel Lee
--ID: 1595395

--Answer Q1 below
select min(UnitPrice) as Lowest_Price 
from Products

--Answer Q2 below

Select OrderID, PurchaseDate 
from Purchases 
where PurchaseDate = (select min(PurchaseDate) from Purchases)
union
Select OrderID, PurchaseDate 
from Purchases 
where PurchaseDate = (select max(PurchaseDate) from Purchases)

--Answer Q3 below
select count(Category) as Number_of_clothing_products 
from Products 
where Category = 'clothing'

--Answer Q4 below
select PurchaseDate as Dates
from Purchases P left outer join Customers C
	on P.CustomerID = C.CustomerID
where C.Sport = 'soccer'


--Answer Q5 below
select PurchaseDate as Dates
from Purchases PU left outer join Products P
	on PU.ProductID = P.ProductID
where P.ProductDescription = 'Cap' or P.ProductDescription = 'Helmet'

--Answer Q6 below
select ProductDescription as products
from Products P left outer join Purchases PU
	on PU.ProductID = P.ProductID
where PU.PurchaseDate = '2022-4-13'


--Answer Q7 below
select FName as FirstName, LName as LastName
from Customers C
where C.CustomerID not in (select CustomerID from Purchases)

--Answer Q8 below
select C.Fname, C.Lname 
from Customers C, Products P, Purchases PU
where C.CustomerID = PU.CustomerID
	and PU.ProductID = P.ProductID
	and P.ProductDescription = 'Sun Block'

--Answer Q9 below
select Sport, count(*) as Count
from Customers
group by Sport
having count(*) > 1

--Answer Q10 below

select PurchaseDate, sum(P.UnitPrice*PU.Quantity) as MoneySpent
from Purchases PU left outer join Products P
	on PU.ProductID = P.ProductID
group by PurchaseDate

--Answer Q11 (Bonus Question) below

select DATEDIFF(day, min(PurchaseDate), max(PurchaseDate)) as Days
from Customers C Right outer join Purchases P
	on C.CustomerID = P.CustomerID
where C.CustomerID = 12