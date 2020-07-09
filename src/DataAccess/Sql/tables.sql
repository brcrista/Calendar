CREATE TABLE Users (
    id INTEGER PRIMARY KEY,
    display_name TEXT,
    account_id INTEGER,
    FOREIGN KEY(account_id) REFERENCES Account(id)
);

CREATE TABLE Accounts (
    id INTEGER PRIMARY KEY,
    email TEXT,
    password TEXT
);

CREATE TABLE Events (
    id INTEGER PRIMARY KEY,
    title TEXT,
    start TEXT, -- DATETIME
    end TEXT, -- DATETIME
    location TEXT,
    owner_id INTEGER,
    FOREIGN KEY(owner_id) REFERENCES User(id)
);

CREATE TABLE Contacts (
    user1_id INTEGER,
    user2_id INTEGER,
    FOREIGN KEY(user1_id) REFERENCES User(id),
    FOREIGN KEY(user2_id) REFERENCES User(id)
);

CREATE TABLE UserEvents (
    user_id INTEGER,
    event_id INTEGER,
    accepted INTEGER, -- BOOLEAN
    FOREIGN KEY(user_id) REFERENCES User(id),
    FOREIGN KEY(event_id) REFERENCES Event(id)
);