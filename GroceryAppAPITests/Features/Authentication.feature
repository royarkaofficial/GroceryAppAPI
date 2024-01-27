Feature: Authentication

As a registered user, he/she tries to login

Background:
Given I am a registered user

@valid-login
Scenario: Registered user login successfully
When the user sends POST request to the 'authentication/login' endpoint with the data '{"Username": "testuser@app.com", "Password": "test123"}'
Then the response status code should be 200
And the response body should be '{"Message": "User logged in successsfully."}'

@invalid-login
Scenario: Login fails due to wrong username
When the user sends POST request to the 'authentication/login' endpoint with the data '{"Username": "xyz@app.com", "Password": "test123"}'
Then the response status code should be 400
And the response body should be '{"Message": "User with the given username not found."}'

@invalid-login
Scenario: Login fails due to wrong password
When the user sends POST request to the 'authentication/login' endpoint with the data '{"Username": "testuser@app.com", "Password": "test456"}'
Then the response status code should be 400
And the response body should be '{"Message": "Password is incorrect."}'

@invalid-login
Scenario: Login fails due to blank username
When the user sends POST request to the 'authentication/login' endpoint with the data '{"Username": "", "Password": "test456"}'
Then the response status code should be 400
And the response body should be '{"Message": "Username is either not given or invalid."}'

@invalid-login
Scenario: Login fails due to blank password
When the user sends POST request to the 'authentication/login' endpoint with the data '{"Username": "testuser@app.com", "Password": ""}'
Then the response status code should be 400
And the response body should be '{"Message": "Password is either not given or invalid."}'