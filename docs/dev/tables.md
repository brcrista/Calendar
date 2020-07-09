# Tables

**Notation:** these symbols mean, "The relation between the rows of tables A and B is ..."

```
A == B -- one-to-one
A -E B -- one-to-many
A ## B -- many-to-many
```

```sql
TABLE User
  id PRIMARY KEY
  display_name TEXT
  account_id FOREIGN KEY -- User == Account

TABLE Account
  id PRIMARY KEY
  email TEXT
  password TEXT

TABLE Event
  id PRIMARY KEY
  title TEXT
  start DATETIME
  end DATETIME
  location TEXT
  description TEXT
  owner_id FOREIGN KEY -- User -E Event

-- User ## User
TABLE Contacts
  user1_id FOREIGN KEY
  user2_id FOREIGN KEY

-- User ## Event
TABLE UserEvent
  user_id FOREIGN KEY
  event_id FOREIGN KEY
  accepted BOOLEAN?
```