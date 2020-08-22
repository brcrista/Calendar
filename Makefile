DATABASE := dist/calendar.db
DOTNET_CONFIGURATION := Debug

.PHONY: all
all: build pack $(DATABASE) seed

.PHONY: build
build: bin/WebService/$(DOTNET_CONFIGURATION)

bin/WebService/$(DOTNET_CONFIGURATION): src/Calendar.sln
	dotnet build $< --configuration $(DOTNET_CONFIGURATION)

dist:
	mkdir -p dist

.PHONY: pack
pack: bin/WebService/$(DOTNET_CONFIGURATION) | dist
	cp -r $</* dist/

$(DATABASE): src/DataAccess/Sql/tables.sql | dist
	sqlite3 $@ < $<

# Seed the database with data for testing.
.PHONY: seed
seed: test/seed.sql $(DATABASE)
	sqlite3 $(DATABASE) < $<

test/functional/node_modules:
	cd test/functional && npm install

# Start the service first
.PHONY: functional-tests
functional-tests: test/functional/node_modules
	cd test/functional && npm test

.PHONY: clean
clean:
	rm -rf bin/ dist/ obj/