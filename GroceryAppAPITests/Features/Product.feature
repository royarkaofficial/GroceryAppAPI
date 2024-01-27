Feature: Product

As an admin user, he/she can do the followings -
1. A new product can be added
2. Can update the existing product details
3. Can remove a product

As a normal registered user, he/she can get all the product details

@products-retrived
Scenario: All the products retrieved successfully
When the user sends GET request to the 'products' endpoint
Then the response status code should be 200
And the response body should be '[{"Id": 1, "Name": "Product 1", "Price": 1000, "Stock": 50, "ImageUrl": "www.productimages.com/1"}, {"Id": 1, "Name": "Product 2", "Price": 2000, "Stock": 80, "ImageUrl": "www.productimages.com/2"}]'

@product-added-successfully
Scenario: Product added successfully
When the user sends POST request to the 'products' endpoint with the data '{"Name": "Product 3", "Price": 3000, "Stock": 70, "ImageUrl": "www.productimages.com/3"}'
Then the response status code should be 200
And the response body should be '{"Id": 3}'

@product-insertion-failed
Scenario: Product insertion failed due to blank product name
When the user sends POST request to the 'products' endpoint with the data '{"Name": " ", "Price": 3000, "Stock": 70, "ImageUrl": "www.productimages.com/3"}'
Then the response status code should be 400
And the response body should be '{"Message": "Name is either not given or invalid."}'

@product-insertion-failed
Scenario: Product insertion failed due to invalid price
When the user sends POST request to the 'products' endpoint with the data '{"Name": "Product 3", "Price": 0, "Stock": 70, "ImageUrl": "www.productimages.com/3"}'
Then the response status code should be 400
And the response body should be '{"Message": "Price is either not given or invalid."}'

@product-insertion-failed
Scenario: Product insertion failed due to invalid stock
When the user sends POST request to the 'products' endpoint with the data '{"Name": "Product 3", "Price": 3000, "Stock": -1, "ImageUrl": "www.productimages.com/3"}'
Then the response status code should be 400
And the response body should be '{"Message": "Stock is either not given or invalid."}'

@product-updated-successfully
Scenario: Product updated successfully
When the user sends PUT request to the 'products/1' endpoint with the data '{"Name": "New Product 1", "Price": 4000, "Stock": 60, "ImageUrl": "www.productimages.com/1"}'
Then the response status code should be 200
And the response body should be '{"Message": "Product updated successfully."}'

@product-updation-failed
Scenario: Product updation failed due to product not found
When the user sends PUT request to the 'products/9' endpoint with the data '{"Name": "New Product 1", "Price": 4000, "Stock": 60, "ImageUrl": "www.productimages.com/1"}'
Then the response status code should be 400
And the response body should be '{"Message": "Product with id 9 is not found."}'

@product-updation-failed
Scenario: Product updation failed due to blank name
When the user sends PUT request to the 'products/1' endpoint with the data '{"Name": " ", "Price": 4000, "Stock": 60, "ImageUrl": "www.productimages.com/1"}'
Then the response status code should be 400
And the response body should be '{"Message": "Name is either not given or invalid."}'

@product-updation-failed
Scenario: Product updation failed due to invalid price
When the user sends PUT request to the 'products/1' endpoint with the data '{"Name": "New Product 1", "Price": 0, "Stock": 60, "ImageUrl": "www.productimages.com/1"}'
Then the response status code should be 400
And the response body should be '{"Message": "Price is either not given or invalid."}'

@product-updation-failed
Scenario: Product updation failed due to invalid stock
When the user sends PUT request to the 'products/1' endpoint with the data '{"Name": "New Product 1", "Price": 4000, "Stock": -1, "ImageUrl": "www.productimages.com/1"}'
Then the response status code should be 400
And the response body should be '{"Message": "Stock is either not given or invalid."}'

@product-deletion-successfull
Scenario: Product deleted successfully
When the user sends DELETE request to the 'products/1' endpoint
Then the response status code should be 200
And the response body should be '{"Message": "Product deleted successfully."}'