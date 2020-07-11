-- Delete existing data for re-runnability.
DELETE FROM Accounts;
DELETE FROM Users;
DELETE FROM Events;
DELETE FROM Contacts;
DELETE FROM UserEvents;

-- Create 4 accounts and 4 users
INSERT INTO Accounts (id, email, password)
VALUES (1, 'brian@email.com', '12345678');

INSERT INTO Accounts (id, email, password)
VALUES (2, 'deirdre@email.com', 'p@ssw0rd!');

INSERT INTO Accounts (id, email, password)
VALUES (3, 'caitie3@email.com', 'correcthorsebatterystaple');

INSERT INTO Accounts (id, email, password)
VALUES (4, 'matthew@email.com', 'user4@email.com');

INSERT INTO Users (id, display_name, account_id)
VALUES (1, 'Brian', 1);

INSERT INTO Users (id, display_name, account_id)
VALUES (2, 'Deirdre', 2);

INSERT INTO Users (id, display_name, account_id)
VALUES (3, 'Caitie', 3);

INSERT INTO Users (id, display_name, account_id)
VALUES (4, 'Matthew', 4);

-- 2 events
INSERT INTO Events (id, title, start, end, location, description, owner_id)
VALUES (1, 'Brian''s Party', '2020-08-31T00:00', '2020-08-31T04:00', '123 Main St, Raleigh, NC, 27603', 'I''m having a party!', 1);

INSERT INTO Events (id, title, start, end, location, description, owner_id)
VALUES (2, 'Christmas UTC', '2020-12-25T00:00', '2020-12-25T23:59', NULL, 'The most wonderful time of the year', 1);