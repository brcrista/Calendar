# Schema

This directory contains .NET types representing the SQL schemas.
These representations are meant to be low-level and adhere as closely to the schema as possible.
* There is one .NET type for each table.
* Each type is a POCO whose properties correspond to the columns in the table.
* An instance of each type represents a row in that table.

## Data types

For the data types used:
* In general, the data type for each property should be the .NET analog of the SQL data type for the column.
    - Note that SQLite doesn't actually type-check its colums.
    - So, it is this layer in the code, not SQLite itself, that enforces that the correct types are going in and coming out of the database.
* Since SQLite uses `TEXT` to represent datetime types, `string` is used here for those types as well. These strings should be parsed to datetimes in higher-level code.
* Foreign keys should be left as their ID types. Higher-level code should execute the query to look up that data in another table.
    - Alternatively, the join can be done in SQL directly, and the .NET schema types for each table can be aggregated into a new type to represent the result of that query.