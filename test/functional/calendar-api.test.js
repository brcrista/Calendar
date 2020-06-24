// Prerequisite: deploy the Calendar API service

const http = require('http');
const URL = require('url').URL;

const apiRoot = 'http://localhost:1498/api/v1/';

/**
 * Call a URL and return the response's status code.
 * @param {URL} url - URL to call for a status code
 */
function fetchStatusCode(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (res) => {
            try {
                resolve(res.statusCode);
            } catch (error) {
                reject(error);
            }
        });
    });
}

describe('The users endpoint', () => {
    test('returns 404 for all users', async () => {
        const url = new URL('users', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(404);
    });

    test('returns 200 for an existing user', async () => {
        const url = new URL('users/1', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(200);
    });

    test("can get an existing user's events", async () => {
        const url = new URL('users/1/events', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(200);
    });

    test("can filter a user's events with query parameters", async () => {
        const url = new URL('users/1/events?hostId=2&hasAccepted=false', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(200);
    });

    test('rejects invalid query parameters', async () => {
        const url = new URL('users/1/events?hostId=hello', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(400);
    });
});

describe('The events endpoint', () => {
    test('returns 404 for all events', async () => {
        const url = new URL('events', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(404);
    });

    test('returns 200 for an existing event', async () => {
        const url = new URL('events/1', apiRoot);
        const statusCode = await fetchStatusCode(url);
        expect(statusCode).toStrictEqual(200);
    });
});