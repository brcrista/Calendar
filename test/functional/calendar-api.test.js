// Prerequisite: deploy the Calendar API service

const http = require('http');
const url = require('url');

const urlBase = 'http://localhost:1498';

describe('the users API', () => {
    test('returns 200 for an existing user', (done) => {
        http.get(
            new url.URL('api/v1/users/1', urlBase),
            (res) => {
                try {
                    expect(res.statusCode).toBe(200);
                    done();
                } catch (error) {
                    done(error);
                }
        });
    });
});