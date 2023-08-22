create table children (
	child_id int not null,
	fname varchar(30),
	lname varchar(30),
	phone int,
	grade varchar(8) CHECK (grade='Beginner' OR grade='Novice' OR grade='Skilled' OR grade='Expert'),
	primary key(child_id)
);

create table instructors (
	staff_no int not null,
	fname varchar(30),
	lname varchar(30),
	phone int,
	primary key(staff_no)
);

create table qualification (
	name varchar(30) not null,
	date date,
	institution varchar(30),
	staff_no int not null,
	primary key(name),
	foreign key (staff_no) references instructors,
);

create table lesson (
	lesson_id int not null,
	day varchar(10),
	time time,
	grade varchar(8) CHECK (grade='Beginner' OR grade='Novice' OR grade='Skilled' OR grade='Expert'),
	staff_no int not null,
	primary key(lesson_id),
	foreign key (staff_no) references instructors,
);

create table childrenBooklesson (
	child_id int not null,
	lesson_id int not null,
	primary key(lesson_id, child_id),
	foreign key (child_id) references children,
	foreign key (lesson_id) references lesson,
);


insert into children values (1, 'Bart', 'Simpson', 0275551000, 'Novice');
insert into children values (2, 'Lisa', 'Simpson', 0275551000, 'Skilled');
insert into children values (3, 'Todd', 'Flanders', 0275552000, 'Expert');
insert into children values (4, 'Ralph', 'Wiggum', 0275553000, 'Beginner');
insert into children values (5, 'Nelson', 'Muntz', 0275554000, 'Skilled');
insert into children values (6, 'Martin', 'Prince', 0275555000, 'Novice');

insert into instructors values (1, 'Moss', 'Burmester', 0215551000);
insert into instructors values (2, 'Helen', 'Norfolk', 0215552000);
insert into instructors values (3, 'Dean', 'Kent', 0215553000);
insert into instructors values (4, 'Alison', 'Fitch', 0215554000);
insert into instructors values (5, 'Cara', 'Baker', 0215555000);

insert into lesson values (1, 'Monday', '13:00:00', 'Beginner', 1);
insert into lesson values (2, 'Monday', '16:00:00', 'Skilled', 2);
insert into lesson values (3, 'Tuesday', '11:00:00', 'Expert', 1);
insert into lesson values (4, 'Friday', '12:00:00', 'Skilled', 4);
insert into lesson values (5, 'Wednesday', '10:00:00', 'Novice', 3);
insert into lesson values (6, 'Friday', '18:00:00', 'Beginner', 2);

insert into childrenBooklesson values (1, 5);
insert into childrenBooklesson values (2, 2);
insert into childrenBooklesson values (2, 4);
insert into childrenBooklesson values (3, 3);
insert into childrenBooklesson values (4, 1);
insert into childrenBooklesson values (4, 6);
insert into childrenBooklesson values (5, 4);
insert into childrenBooklesson values (6, 5);

select * from children;
select * from childrenBooklesson;
select * from lesson;
select * from instructors;

