.PHONY: build
build: src/Calendar.sln
	dotnet build $<

test/functional/node_modules:
	cd test/functional && npm install

# This just checks that the syntax in the SQL file is correct.
.PHONY: schema-tests
schema-tests:
	sqlite3 < src/ObjectModel/Sql/tables.sql

# Start the service first with `dotnet run --project src/ApiService`
.PHONY: functional-tests
functional-tests: test/functional/node_modules
	cd test/functional && npm test