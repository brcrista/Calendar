.PHONY: all
all: build calendar.db install-dev

.PHONY: build
build: src/Calendar.sln
	dotnet build $<

calendar.db: src/DataAccess/Sql/tables.sql
	sqlite3 $@ < $<

# Seed the database with data for testing.
.PHONY: install-dev
install-dev: test/seed.sql calendar.db
	sqlite3 calendar.db < $<

test/functional/node_modules:
	cd test/functional && npm install

# Start the service first with `dotnet run --project src/ApiService`
.PHONY: functional-tests
functional-tests: test/functional/node_modules
	cd test/functional && npm test

.PHONY: clean
clean:
	dotnet clean src
	rm -f calendar.db