Feature: Registration

As a new user, he/she tries to register.

Background:
Given I am a registered user

@valid-registration
Scenario: User registered successfully
When the user sends POST request to the 'registration' endpoint with the data '{"FirstName": "Arkadeep", "LastName": "Roy", "Email": "roy@gmail.com", "Password": "Arka123"}'
Then the response status code should be 200
And the response body should be '{"Message": "User registered successfully."}'

@invalid-registration
Scenario: User registration fails due to blank firstname
When the user sends POST request to the 'registration' endpoint with the data '{"FirstName": " ", "LastName": "Roy", "Email": "roy@gmail.com", "Password": "Arka123"}'
Then the response status code should be 400
And the response body should be '{"Message": "FirstName is either not given or invalid."}'

@invalid-registration
Scenario: User registration fails due to blank lastname
When the user sends POST request to the 'registration' endpoint with the data '{"FirstName": "Arkadeep", "LastName": " ", "Email": "roy@gmail.com", "Password": "Arka123"}'
Then the response status code should be 400
And the response body should be '{"Message": "LastName is either not given or invalid."}'

@invalid-registration
Scenario: User registration fails due to blank email
When the user sends POST request to the 'registration' endpoint with the data '{"FirstName": "Arkadeep", "LastName": "Roy", "Email": " ", "Password": "Arka123"}'
Then the response status code should be 400
And the response body should be '{"Message": "Email is either not given or invalid."}'

@invalid-registration
Scenario: User registration fails due to blank password
When the user sends POST request to the 'registration' endpoint with the data '{"FirstName": "Arkadeep", "LastName": "Roy", "Email": "roy@gmail.com", "Password": ""}'
Then the response status code should be 400
And the response body should be '{"Message": "Password is either not given or invalid."}'
