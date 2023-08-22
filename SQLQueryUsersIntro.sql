USE sl408_INTRO_USERS;

CREATE TABLE users
(
 username VARCHAR(20) NOT NULL PRIMARY KEY,
 firstname VARCHAR(20) NOT NULL,
 middlename VARCHAR(20),
 lastname VARCHAR(20) NOT NULL,
 password VARCHAR (20) NOT NULL
);

CREATE TABLE socialmedia
(
 socmediaid VARCHAR(3) NOT NULL PRIMARY KEY,
 socialmedianame VARCHAR(30) NOT NULL
);

CREATE TABLE usersession
(
 sessionid INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
 socmediaid VARCHAR(3),
 username VARCHAR(20),
 sessiontime INT, --assumed as minutes for simplicity
 FOREIGN KEY(socmediaid) REFERENCES socialmedia,
 FOREIGN KEY(username) REFERENCES users
);


--This inserts data into Users table
INSERT INTO users VALUES ('jkc1', 'John', 'Middle', 'Carter', 'pass1');
INSERT INTO users VALUES ('amo1', 'Amos', 'Carter', 'Orange', 'pass2');
INSERT INTO users VALUES ('wkc1', 'Wong', 'Caleb', 'Cartel', 'pass3');
INSERT INTO users VALUES ('ddj1', 'Daisy', 'Day', ' Johnson ', 'pass4');
INSERT INTO users VALUES ('dps1', 'Dayne', 'Pint', ' Shipper ', 'pass5');

--This table links the two tables together
INSERT INTO socialmedia VALUES ('FB', 'Facebook');
INSERT INTO socialmedia VALUES ('TWT', 'Twitter');
INSERT INTO socialmedia VALUES ('IG', 'Instagram');
INSERT INTO socialmedia VALUES ('YT', 'YouTube');

--This stores data into UserSession linking Users and SocialMediaa
INSERT INTO usersession VALUES ('FB', 'jkc1', 256);
INSERT INTO usersession VALUES ('TWT', 'amo1', 20);
INSERT INTO usersession VALUES ('IG', 'wkc1', 60);
INSERT INTO usersession VALUES ('YT', 'ddj1', 180);
INSERT INTO usersession VALUES ('FB', 'dps1', 25);

SELECT * FROM users;
SELECT * FROM socialmedia;
SELECT * FROM usersession;

