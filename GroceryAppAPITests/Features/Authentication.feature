Feature:Authentication

As a registered user, he/she tries to login

Background:
Given I am a registered user

@valid-login
Scenario:Registered user login successfully
When the user sends POST request to the 'authentication/login' endpoint with the data '{"email":"testuser@app.com","password":"test123"}'
Then the response status code should be 200
And the response body should be '{"data":{"userId":1,"accessToken":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IlRlc3QgVXNlciIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ0ZXN0dXNlckBhcHAuY29tIiwiZXhwIjoxNzA3NzU2ODAzLCJpc3MiOiJodHRwOi8vZ3JvY2VyeWFwcC5hcGkuY29tLyIsImF1ZCI6Imh0dHA6Ly9ncm9jZXJ5YXBwLmFwaS5jb20vIn0.Gq0A_9GuTnJY35_lySrkThH2ZjAkkShicKnN0T8hKyQ","role":2}}'

@invalid-login
Scenario:Login fails due to wrong username
When the user sends POST request to the 'authentication/login' endpoint with the data '{"email":"xyz@app.com","password":"test123"}'
Then the response status code should be 400
And the response body should be '{"message":"User with the given username not found."}'

@invalid-login
Scenario:Login fails due to wrong password
When the user sends POST request to the 'authentication/login' endpoint with the data '{"email":"testuser@app.com","password":"test456"}'
Then the response status code should be 400
And the response body should be '{"message":"Password is incorrect."}'

@invalid-login
Scenario:Login fails due to blank username
When the user sends POST request to the 'authentication/login' endpoint with the data '{"email":"","password":"test456"}'
Then the response status code should be 400
And the response body should be '{"message":"Username is either not given or invalid."}'

@invalid-login
Scenario:Login fails due to blank password
When the user sends POST request to the 'authentication/login' endpoint with the data '{"email":"testuser@app.com","password":""}'
Then the response status code should be 400
And the response body should be '{"message":"Password is either not given or invalid."}'