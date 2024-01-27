Feature: Order

As a registered user, he/she can do the followings -
1. Can get the order history
2. Can place the order

@order-history-retrived
Scenario: Order history retrieved successfully
When the user sends GET request to the 'orders?userId=1' endpoint
Then the response status code should be 200
And the response body should be '[{"Id": 1, "UserId": 1, "PaymentId": 1, "OrderedAt": "2024-01-15", "ProductIds": [1, 2]}, {"Id": 2, "UserId": 1, "PaymentId": 2, "OrderedAt": "2024-01-20", "ProductIds": [3, 4]}]'

@order-history-retrived-failed
Scenario: Order history retrieve failed due to user not found
When the user sends GET request to the 'orders?userId=7' endpoint
Then the response status code should be 400
And the response body should be '{"Message": "User with id 7 is not found."}'

@order-placed-successfully
Scenario: Order placed successfully
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 3000, "PaymentType": 1}, "Order": { "UserId": 1, "ProductIds": [1,2]}}"}'
Then the response status code should be 200
And the response body should be '{"OrderId": 3, "PaymentId": 3}'

@order-placing-failed
Scenario: Order placing failed due to payment failures
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 3000, "PaymentType": 1}, "Order": { "UserId": 1, "ProductIds": [1,2]}}"}'
Then the response status code should be 400
And the response body should be '{"Message": "Payment request is either not given or invalid."}'

@order-placing-failed
Scenario: Order placing failed due to user not found
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 3000, "PaymentType": 1}, "Order": { "UserId": 11, "ProductIds": [1,2]}}"}'
Then the response status code should be 400
And the response body should be '{"Message": "User with id 11 is not found."}'

@order-placing-failed
Scenario: Order placing failed due to product not found
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 3000, "PaymentType": 1}, "Order": { "UserId": 1, "ProductIds": [0]}}"}'
Then the response status code should be 400
And the response body should be '{"Message": "Product with id 0 is not found."}'

@order-placing-failed
Scenario: Order placing failed due to no products are passed
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 3000, "PaymentType": 1}, "Order": { "UserId": 1, "ProductIds": []}}"}'
Then the response status code should be 400
And the response body should be '{"Message": "ProductIds are either not given or invalid."}'

@order-placing-failed
Scenario: Order placing failed due to invalid payment type
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 3000, "PaymentType": 10}, "Order": { "UserId": 11, "ProductIds": [1, 2]}}"}'
Then the response status code should be 400
And the response body should be '{"Message": "PaymentType are either not given or invalid."}'

@order-placing-failed
Scenario: Order placing failed due to less payment amount
When the user sends POST request to the 'orders/payments' endpoint with the data '{"Payment": {"Amount": 2000, "PaymentType": 10}, "Order": { "UserId": 11, "ProductIds": [1, 2]}}"}'
Then the response status code should be 400
And the response body should be '{"Message": "Payment amount is less than total amonut of the purchased items."}'