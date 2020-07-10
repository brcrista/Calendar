DROP TABLE IF EXISTS Users;
CREATE TABLE Users (
    id INTEGER PRIMARY KEY,
    display_name TEXT,
    account_id INTEGER,
    FOREIGN KEY(account_id) REFERENCES Account(id)
);

DROP TABLE IF EXISTS Accounts;
CREATE TABLE Accounts (
    id INTEGER PRIMARY KEY,
    email TEXT,
    password TEXT
);

DROP TABLE IF EXISTS Events;
CREATE TABLE Events (
    id INTEGER PRIMARY KEY,
    title TEXT,
    start TEXT, -- DATETIME
    end TEXT, -- DATETIME
    location TEXT,
    description TEXT,
    owner_id INTEGER,
    FOREIGN KEY(owner_id) REFERENCES User(id)
);

DROP TABLE IF EXISTS Contacts;
CREATE TABLE Contacts (
    user1_id INTEGER,
    user2_id INTEGER,
    FOREIGN KEY(user1_id) REFERENCES User(id),
    FOREIGN KEY(user2_id) REFERENCES User(id)
);

DROP TABLE IF EXISTS UserEvents;
CREATE TABLE UserEvents (
    user_id INTEGER,
    event_id INTEGER,
    accepted INTEGER, -- BOOLEAN
    FOREIGN KEY(user_id) REFERENCES User(id),
    FOREIGN KEY(event_id) REFERENCES Event(id)
);