'use strict';
const URL = require('url').URL;

const fetch = require('js-helpers/node').fetch;

// Prerequisites:
// - Run `make install-dev` from the root to seed the database.
//   These tests assume that the seed data is being used.
// - Deploy the Calendar API service.
const apiRoot = 'http://localhost:1498/api/v1/';

describe('The users endpoint', () => {
    const existingUserIds = [1, 2, 3, 4];

    test('returns 404 for all users', async () => {
        const url = new URL('users', apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(404);
    });

    test.each(existingUserIds)('returns 200 for an existing user', async (userId) => {
        const url = new URL(`users/${userId}`, apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(200);
    });

    test.each(existingUserIds)("can get an existing user's events", async (userId) => {
        const url = new URL(`users/${userId}/events`, apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(200);
    });

    test("can filter a user's events with query parameters", async () => {
        const url = new URL('users/1/events?hostId=2&hasAccepted=false', apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(200);
    });

    test('rejects invalid query parameters', async () => {
        const url = new URL('users/1/events?hostId=hello', apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(400);
    });

    test.each(existingUserIds)("can get an existing user's contacts", async (userId) => {
        const url = new URL(`users/${userId}/contacts`, apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(200);
    });

    test('returns 404 for a user that does not exist', async () => {
        const url = new URL('users/5', apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(404);
    });
});

describe('The events endpoint', () => {
    const existingEventIds = [1, 2];

    test('returns 404 for all events', async () => {
        const url = new URL('events', apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(404);
    });

    test.each(existingEventIds)('returns 200 for an existing event', async (eventId) => {
        const url = new URL(`events/${eventId}`, apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(200);
    });

    test('returns 404 for an event that does not exist', async () => {
        const url = new URL('events/3', apiRoot);
        const response = await fetch(url);
        expect(response.statusCode).toStrictEqual(404);
    });
});