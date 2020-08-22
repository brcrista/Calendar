DATABASE := dist/calendar.db
DOTNET_CONFIGURATION := Debug

.PHONY: all
all: build pack $(DATABASE) seed

.PHONY: build
build: src/Calendar.sln
	dotnet build $< --configuration $(DOTNET_CONFIGURATION)

# Since this is just the directory, we need to build it every time.
# Otherwise, Make won't know if any of the source files have been updated.
bin/WebService/$(DOTNET_CONFIGURATION): build

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

# There seems to be an issue here where the bin/ and obj/ directories
# don't get removed on the first try.
# Maybe MSBuild is locking them.
# Rerunning `make clean` should fix it.
.PHONY: clean
clean:
	rm -rf bin/ dist/ obj/