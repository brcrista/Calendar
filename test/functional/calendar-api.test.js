// Prerequisite: deploy the Calendar API service

const http = require('http');
const URL = require('url').URL;

const apiRoot = 'http://localhost:1498/api/v1/';

/**
 * Call an endpoint and check its status code in a Jest test.
 * @param {string} endpoint - Path of the endpoint to test
 * @param {number} statusCode - Expected HTTP status code in the response
 */
function testEndpoint(endpoint, statusCode, done) {
    const url = new URL(endpoint, apiRoot);
    http.get(url, (res) => {
        try {
            expect(res.statusCode).toStrictEqual(statusCode);
            done();
        } catch (error) {
            done(error);
        }
    });
}

describe('The users endpoint', () => {
    test('does not return all users', (done) => {
        testEndpoint('users', 404, done);
    });

    test('returns 200 for an existing user', (done) => {
        testEndpoint('users/1', 200, done);
    });
});

describe('The events endpoint', () => {
    test('does not return all events', (done) => {
        testEndpoint('events', 404, done);
    });

    test('returns 200 for an existing event', (done) => {
        testEndpoint('events/1', 200, done);
    });
});