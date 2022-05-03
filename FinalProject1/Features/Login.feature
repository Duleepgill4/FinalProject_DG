Feature: Login

Logging in to an ecommerce site with an existing account
@LogIn
Scenario: Log in to edgewords 
	Given That I am a registered user
	When I add an item of clothing with a discount code to my cart
	Then the discount and shipping is applied to the total




@OrderConfirmation

Scenario: Confirm order has been placed
	Given That I have an item in my cart
	When I checkout with my details
	Then My order is present in my Orders

