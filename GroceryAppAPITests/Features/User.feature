Feature: User

As a registered user, he/she tries to -
1. get user details 
2. update password

Background:
Given I am a registered user

@user-details-fetched-successfully
Scenario: User retrieved successfully
When the user sends GET request to the 'users/1' endpoint
Then the response status code should be 200
And the response body should be '{"FirstName": "Arkadeep", "LastName": "Roy", "Email": "roy@gmail.com", "Password": "Arka123"}'

@user-details-not-found
Scenario: User does not exist
When the user sends GET request to the 'users/10' endpoint
Then the response status code should be 400
And the response body should be '{"Message": "User with id 10 is not found."}'

@password-updated-successfully
Scenario: User updates the password successfully
When the user sends PUT request to the 'users/1' endpoint with the data 'Test456'
Then the response status code should be 200
And the response body should be '{"Message": "Password updated successfully."}'

@password-updation-failed
Scenario: Password updation failed due to invalid user
When the user sends PUT request to the 'users/10' endpoint with the data 'Test456'
Then the response status code should be 400
And the response body should be '{"Message": "User with id 10 is not found."}'

@password-updation-failed
Scenario: Password updation failed due to blank password
When the user sends PUT request to the 'users/1' endpoint with the data ''
Then the response status code should be 400
And the response body should be '{"Message": "User with id 10 is not found."}'

