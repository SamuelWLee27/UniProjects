--must have email so can be contacted by company
CREATE TABLE Customer
(
  Fname VARCHAR(50) NOT NULL,
  Lname VARCHAR(50) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  Phone BIGINT,
  CustomerID INT NOT NULL IDENTITY(1,1),
  Street_Address VARCHAR(100),
  City VARCHAR(50),
  Country VARCHAR(50), 
  PRIMARY KEY (CustomerID),
  CONSTRAINT Check_Customer_Email CHECK(Email LIKE '%__@__%')
);

--must have email so can be contacted by company
CREATE TABLE Instructor
(
  Fname VARCHAR(50) NOT NULL,  
  Lname VARCHAR(50) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  Phone BIGINT,
  InstructorID INT NOT NULL IDENTITY(1,1),
  PRIMARY KEY (InstructorID),
  CONSTRAINT Check_Instructor_Email 
	CHECK(Email LIKE '%__@__%')
);

CREATE TABLE Product
(
  Product_Name VARCHAR(100) NOT NULL,
  Discriptions VARCHAR(1000),
  BaseStock INT NOT NULL,
  Product_ID INT NOT NULL IDENTITY(1,1),
  Product_Cost MONEY NOT NULL,
  PRIMARY KEY (Product_ID),
  CONSTRAINT Check_Product_Price
	CHECK(Product_cost > 0)
);

CREATE TABLE Course
(
  Title VARCHAR(100) NOT NULL,
  Duration TIME NOT NULL,
  NumDays INT NOT NULL,
  Descriptions VARCHAR(1000),
  Course_ID INT NOT NULL IDENTITY(1,1),
  Course_Price MONEY NOT NULL,
  PRIMARY KEY (Course_ID),
  CONSTRAINT Check_Course_Price
	CHECK(Course_Price > 0)
);

CREATE TABLE Avalibility
(
  WeekDays VARCHAR(10) NOT NULL,
  Start_Time TIME NOT NULL,
  End_Time TIME NOT NULL,
  InstructorID INT NOT NULL,
  PRIMARY KEY (WeekDays, InstructorID),
  FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID),
  CONSTRAINT Check_Date CHECK(WeekDays IN ('Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'))
);

CREATE TABLE QualificationType
(
  QualName VARCHAR(150) NOT NULL,
  ExpiryDuration_YEARS INT NOT NULL,
  PRIMARY KEY (QualName)
);

--Paid amount and payment type track whether it has been payed as if null it's not payed
CREATE TABLE Transactions
(
  TransactionID INT NOT NULL IDENTITY(1,1),
  PaymentType CHAR(4),
  DatePlaced DATE NOT NULL,
  Delivery_Details VARCHAR(200),
  TotalAmount MONEY NOT NULL,
  PaidAmount MONEY,
  Completion BIT DEFAULT 0,
  CustomerID INT NOT NULL,
  PRIMARY KEY (TransactionID),
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
  CONSTRAINT check_total_paid CHECK(TotalAmount >= PaidAmount),
  CONSTRAINT check_paid CHECK(PaidAmount > 0),
  CONSTRAINT check_total CHECK(TotalAmount > 0),
  CONSTRAINT check_paymentType Check(PaymentType IN ('EFPS','CASH','CRDT'))
);

CREATE TABLE Booking
(
  Location VARCHAR(100) NOT NULL,
  #Attending INT NOT NULL,
  Booking# INT NOT NULL IDENTITY(1,1),
  Start_Time DATETIME NOT NULL,
  End_time DATETIME,
  TransactionID INT NOT NULL,
  Course_ID INT NOT NULL,
  PRIMARY KEY (Booking#),
  FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID),
  FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID)
);

CREATE TABLE BookingInstructor
(
  Booking# INT NOT NULL,
  InstructorID INT NOT NULL,
  PRIMARY KEY (Booking#, InstructorID),
  FOREIGN KEY (Booking#) REFERENCES Booking(Booking#),
  FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID)
);

CREATE TABLE Attends
(
  Grade INT,
  Completion_Date DATE,
  CustomerID INT NOT NULL,
  Booking# INT NOT NULL,
  PRIMARY KEY (CustomerID, Booking#),
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
  FOREIGN KEY (Booking#) REFERENCES Booking(Booking#),
  UNIQUE (CustomerID, Booking#)
);

CREATE TABLE BookingProduct
(
  Amount_Needed INT NOT NULL,
  Booking# INT NOT NULL,
  Product_ID INT NOT NULL,
  PRIMARY KEY (Booking#, Product_ID),
  FOREIGN KEY (Booking#) REFERENCES Booking(Booking#),
  FOREIGN KEY (Product_ID) REFERENCES Product(Product_ID)
);

CREATE TABLE InstructorHasQaulification
(
  InstructorID INT NOT NULL,
  QualName VARCHAR(150) NOT NULL,
  PRIMARY KEY (InstructorID, QualName),
  FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID),
  FOREIGN KEY (QualName) REFERENCES QualificationType(QualName)
);

CREATE TABLE OrderProduct
(
  Quantities INT NOT NULL,
  TransactionID INT NOT NULL,
  Product_ID INT NOT NULL,
  PRIMARY KEY (TransactionID, Product_ID),
  FOREIGN KEY (TransactionID) REFERENCES Transactions(TransactionID),
  FOREIGN KEY (Product_ID) REFERENCES Product(Product_ID)
);

CREATE TABLE InstructorRequiresQualification
(
  Course_ID INT NOT NULL,
  QualName VARCHAR(150) NOT NULL,
  PRIMARY KEY (Course_ID, QualName),
  FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID),
  FOREIGN KEY (QualName) REFERENCES QualificationType(QualName)
);

CREATE TABLE CustomerPrerequisites
(
  Course_ID INT NOT NULL,
  QualName VARCHAR(150) NOT NULL,
  FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID),
  FOREIGN KEY (QualName) REFERENCES QualificationType(QualName)
);

CREATE TABLE CourseGivesQualification
(
  Course_ID INT NOT NULL,
  QualName VARCHAR(150) NOT NULL,
  FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID),
  FOREIGN KEY (QualName) REFERENCES QualificationType(QualName)
);




insert into Customer values('John', 'Smith', 'johnsmith@gmail.com', 5551234576, '123 main st', 'anytown', 'NZ');
insert into Customer values('Sarsh', 'Johnson', 'sarahj@gmail.com', 5559876543, '456 Elm st', 'anytown', 'NZ');

insert into Course values('basic first aid', '4:00:00', 1, 'A short course that covers essential first aid techniques for common
injuries, such as burns, cuts, and sprains. Suitable for individuals or groups with
no prior first aid training.', 200);

insert into Course values('First Aid/CPR/AED', '6:00:00', 1, 'A one-day course that teach individuals how to respond to medical 
emergencies. The course covers a variety of topics, including the proper procedures 
for providing first aid, cardiopulmonary resuscitation (CPR), and using an automated 
external defibrillator (AED). 
Suitable for individuals or groups with no prior first aid training.', 300);


insert into Course values('Wilderness First Aid', '8:00:00', 2, 'is two-day (8 hour days) specialized course designed to teach individuals how to 
respond to medical emergencies in remote or wilderness settings. The course covers 
the essential skills and techniques needed to assess, stabilize, and manage a 
variety of injuries and illnesses that may occur in the outdoors.', 400);

insert into Course values('Advanced First Aid', '8:00:00', 3, 'A 3-day (8 hour days) course that builds on the skills taught in the Basic First Aid
course and covers advanced techniques for managing medical emergencies, such as
heart attacks and strokes.', 400);

insert into Product values('First Aid Kit', 'A portable kit containing a range of essential first aid supplies, including bandages, gauze, antiseptic wipes, and more.', 100, 50);

insert into Product values('Automated External Defibrillator (AED)', 'An easy-to-use device that can analyse the hearts rhythm and deliver 
an electric shock to restore normal heartbeat in case of cardiac arrest.', 10, 1500);

insert into Product values('CPR Manikin', ' A realistic training manikin that simulates a human body for 
practicing cardiopulmonary resuscitation (CPR) techniques.', 50, 300);

insert into Instructor values('Jane', 'Doe', 'janedoe@gmail.com', 5555551212);

insert into Instructor values('Mark', 'Johnson', 'markJohnson@gmail.com', 5551234567);

insert into Transactions values(null, '2023-01-03', 'Booked for anytown Community Center', 6000, null, 0, 1);
insert into Transactions values('EFPS', '2023-01-03', 'Booked for anytown state park', 6000, 6000, 0, 2);
insert into Transactions values(null, '2023-01-03', 'pick up', 50, null, 0, 1);
insert into Transactions values('EFPS', '2023-01-03', 'deliver to 456 elm st, anytown, nz', 300, 300, 1, 2);

insert into Booking values('Anytime community centre', 20, '2023-03-01 09:00:00', '2023-03-01 15:00:00', 1, 1);
insert into Booking values('Anytime state park', 15, '2023-04-15 09:00:00', '2023-04-16 17:00:00', 2, 2);

insert into BookingInstructor values(1, 1);
insert into BookingInstructor values(2, 2);

insert into Avalibility values('Monday', '9:00:00', '17:00:00', 1);
insert into Avalibility values('Tuesday', '9:00:00', '17:00:00', 1);
insert into Avalibility values('Wednesday', '9:00:00', '17:00:00', 1);
insert into Avalibility values('Thursday', '9:00:00', '17:00:00', 1);
insert into Avalibility values('Friday', '9:00:00', '17:00:00', 1);
insert into Avalibility values('Saturday', '9:00:00', '17:00:00', 2);
insert into Avalibility values('Sunday', '9:00:00', '17:00:00', 2);

insert into QualificationType values('basic first aid', 2);
insert into QualificationType values('First Aid/CPR/AED', 2);
insert into QualificationType values('Wilderness First Aid', 2);
insert into QualificationType values('Advanced First Aid', 2);
insert into QualificationType values('American Heart Association BLS Instructor', 2);
insert into QualificationType values('Red Cross First Aid/CPR/AED Instructor', 2);
insert into QualificationType values('Wilderness First Responder Instructor', 2);
insert into QualificationType values('National Safety Council First Aid/CPR/AED', 2);
insert into QualificationType values('Advanced First Aid Instructor', 2);

insert into Attends values(null, null, 1, 1);
insert into Attends values(null, null, 2, 2);
insert into Attends values(null, null, 1, 2);

--course glitched and gave identity 5 and 6 for course id instead of 3 and 4
insert into BookingProduct values(10, 1, 1);
insert into BookingProduct values(10, 2, 1);
insert into BookingProduct values(2, 2, 2);
insert into BookingProduct values(5, 2, 3);

insert into InstructorHasQaulification values(1, 'American Heart Association BLS Instructor');
insert into InstructorHasQaulification values(1, 'Red Cross First Aid/CPR/AED Instructor');
insert into InstructorHasQaulification values(2, 'Wilderness First Responder Instructor');
insert into InstructorHasQaulification values(2, 'National Safety Council First Aid/CPR/AED');

insert into OrderProduct values(1, 3, 1);
insert into OrderProduct values(1, 4, 3);

insert into InstructorRequiresQualification values(1, 'American Heart Association BLS Instructor');
insert into InstructorRequiresQualification values(2, 'Red Cross First Aid/CPR/AED Instructor');
insert into InstructorRequiresQualification values(3, 'Wilderness First Responder Instructor');
insert into InstructorRequiresQualification values(4, 'Advanced First Aid Instructor');


insert into CustomerPrerequisites values(4, 'basic first aid');


insert into CourseGivesQualification values(1, 'basic first aid');
insert into CourseGivesQualification values(2, 'First Aid/CPR/AED');
insert into CourseGivesQualification values(3, 'Wilderness First Aid');
insert into CourseGivesQualification values(4, 'Advanced First Aid');

select * from Customer;
select * from Instructor;
select * from Product;
select * from Course;
select * from Avalibility;
select * from QualificationType;
select * from Transactions;
select * from Booking;
select * from BookingInstructor;
select * from Attends;
select * from BookingProduct;
select * from InstructorHasQaulification;
select * from OrderProduct;
select * from InstructorRequiresQualification;
select * from CustomerPrerequisites;
select * from CourseGivesQualification;

--links all entities together
select distinct cus.Fname as 'Customer Fname', B.Booking#, T.TransactionID, c.Title, I.Fname as 'Instructor Fname', Av.Start_Time,  Q.QualName, BP.Amount_Needed, P.Product_Name
from Customer cus, Instructor I, Course c, Avalibility Av, Transactions T, Booking B, BookingInstructor BI, Attends A, QualificationType Q, InstructorHasQaulification IHQ, BookingProduct BP, Product P
where cus.CustomerID = A.CustomerID and cus.CustomerID = T.CustomerID and T.TransactionID = B.TransactionID and B.Course_ID = C.Course_ID and B.Booking# = BI.Booking# 
and BI.InstructorID = I.InstructorID and I.InstructorID = Av.InstructorID and  Q.QualName = IHQ.QualName and I.InstructorID = IHQ.InstructorID and B.Booking# = BP.Booking# and BP.Product_ID = P.Product_ID;




--can't do it all in one query so have to split it
--get course info and how is attending plus instructors
select distinct C.Title, C.Descriptions, B.Location, B.Start_Time, B.End_time, C.Course_Price, T.PaidAmount, Cus.Fname as 'Customer fname', I.Fname as 'Instuctor fname', P.Product_Name
from Course C, Attends A, Customer Cus, Booking B, Transactions T, Instructor I, BookingInstructor BI, BookingProduct BP, Product P
where A.CustomerID = Cus.CustomerID and C.Course_ID = B.Course_ID and A.Booking# = B.Booking# and T.TransactionID = B.TransactionID
and B.Booking# = BI.Booking# and BI.InstructorID = I.InstructorID and B.Booking# = BP.Booking# and P.Product_ID = BP.Booking#;

--get product used for each course
select distinct C.Title, P.Product_Name
from Course C, Booking B, BookingProduct BP, Product P 
where C.Course_ID = B.Course_ID and B.Booking# = BP.Booking# and P.Product_ID = BP.Booking#;



drop table Customer;
drop table Instructor;
drop table Product;
drop table Course;
drop table Avalibility;
drop table QualificationType;
drop table Attends;
drop table CourseProduct;
drop table InstructorHasQaulification;
drop table Transactions;
drop table Booking;
drop table BookingInstructor;
drop table OrderProduct;
drop table InstructorRequiresQualification;
drop table CustomerPrerequisites;
drop table CourseGivesQualification;

