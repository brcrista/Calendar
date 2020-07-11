BIN := ./bin
DATABASE := $(BIN)/calendar.db
DOTNET_CONFIGURATION := Debug

.PHONY: all
all: build $(DATABASE) seed

.PHONY: build
build: src/Calendar.sln
	dotnet build $< --configuration $(DOTNET_CONFIGURATION)

# Normally, this should get created as a side effect of `make build`
$(BIN):
	mkdir -p $(BIN)

$(DATABASE): src/DataAccess/Sql/tables.sql $(BIN)
	sqlite3 $@ < $<

# Seed the database with data for testing.
.PHONY: seed
seed: test/seed.sql $(DATABASE)
	sqlite3 $(DATABASE) < $<

test/functional/node_modules:
	cd test/functional && npm install

# Start the service first with `dotnet run --project src/WebService`
.PHONY: functional-tests
functional-tests: test/functional/node_modules
	cd test/functional && npm test

.PHONY: clean
clean:
	dotnet clean src
	rm -rf $(BIN)