
create table destination (
	three_letter_code char(3) not null check (three_letter_code = Upper(three_letter_code) and three_letter_code like '[A-Z][A-Z][A-Z]'),
	country varchar(20),
	name varchar(20),
	primary key(three_letter_code),

);

create table flight (
	flight_num int not null,
	price decimal,
	three_letter_code_to char(3) not null check (three_letter_code_to = Upper(three_letter_code_to) and three_letter_code_to like '[A-Z][A-Z][A-Z]'),
	three_letter_code_from char(3) not null check (three_letter_code_from = Upper(three_letter_code_from) and three_letter_code_from like '[A-Z][A-Z][A-Z]'),
	primary key(flight_num),
	foreign key(three_letter_code_to) references destination(three_letter_code),
	foreign key(three_letter_code_from) references destination(three_letter_code),
);

create table airline (
	two_letter_code char(2) not null check (two_letter_code = UPPER(two_letter_code) and two_letter_code like '[A-Z][A-Z]'),
	home_city varchar(20),
	name varchar(30),
	phone int,
	country varchar(20),
	primary key(two_letter_code)
);

create table airlineOffersFlight(
	two_letter_code char(2) not null check (two_letter_code = UPPER(two_letter_code) and two_letter_code like '[A-Z][A-Z]'),
	flight_num int not null,
	primary key(two_letter_code, flight_num),
	foreign key(two_letter_code) references airline,
	foreign key(flight_num) references flight,
);

insert into airline values('NZ', 'Auckland', 'Air New Zealand', null, 'New Zealand');
insert into airline values('EK', 'Dubai', 'Emirates', null, 'Arab Emirates');
insert into airline values('QF', 'Sydney', 'Qantas', null, 'Australia');
insert into airline values('SQ', 'Singapore', 'Singapore Airlines', null, 'Singapore');

insert into destination values('AKL', 'New Zealand', 'Auckland');
insert into destination values('HLT', 'New Zealand', 'Hamilton');
insert into destination values('LAX', 'America', 'Los Angeles');
insert into destination values('SIN', 'Singapore', 'Singapore');
insert into destination values('MEL', 'Australia', 'Melbourne');
insert into destination values('SHA', 'Shanghai', 'China');
insert into destination values('123', 'Shanghai', 'China');

insert into flight values(1, 79.00, 'AKL', 'HLT');
insert into flight values(2, 1000.00, 'AKL', 'LAX');
insert into flight values(3, 1200.00, 'AKL', 'SIN');
insert into flight values(4, 450.00, 'AKL', 'MEL');

select * from airline;
select * from flight;
select * from destination;

drop table destination;
drop table flight;
drop table airline;
drop table airlineOffersFlight;