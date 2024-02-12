Feature:User

As a registered user, he/she tries to -
1. get user details 
2. update password

Background:
Given I am a registered user

@user-details-fetched-successfully
Scenario:User retrieved successfully
When the user sends GET request to the 'users/1' endpoint
Then the response status code should be 200
And the response body should be '{"firstName":"Test","lastName":"User","email":"testuser@app.com","password":"7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4=","role":2,"id":1}'

@user-details-not-found
Scenario:User does not exist
When the user sends GET request to the 'users/10' endpoint
Then the response status code should be 400
And the response body should be '{"message":"User with id 10 is not found."}'

@password-updated-successfully
Scenario:User updates the password successfully
When the user sends PUT request to the 'users/1' endpoint with the data '"Test456"'
Then the response status code should be 200
And the response body should be '{"message":"Password updated successfully."}'

@password-updation-failed
Scenario:password updation failed due to invalid user
When the user sends PUT request to the 'users/password' endpoint with the data '{"email":"testuser23@app.com", "password":"Abc123"}'
Then the response status code should be 400
And the response body should be '{"message":"User with the given email testuser23@app.com does not exist."}'

@password-updation-failed
Scenario:password updation failed due to blank password
When the user sends PUT request to the 'users/password' endpoint with the data '{"email":"testuser2@app.com", "password":""}'
Then the response status code should be 400
And the response body should be '{"message":"Password is either not given or invalid."}'

