.PHONY: build
build: src/Calendar.sln
	dotnet build $<

test/functional/node_modules:
	cd test/functional && npm install

# Start the service first with `dotnet run --project src/ApiService`
.PHONY: functional-tests
functional-tests: test/functional/node_modules
	cd test/functional && npm test