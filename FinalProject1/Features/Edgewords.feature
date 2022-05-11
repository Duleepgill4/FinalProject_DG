@EdgewordsShop
Feature: Edgewords Shop Site	

Registered user can log in and place an order using a discount and get confirmation of order


Background: 
	Given I log in as a registered user
	And I add an item to my cart


#Test Case 1- following given; adds coupon code and checks coupon is correct as well as the total

Scenario: use discount code	 
	When I apply the 'edgewords' discount code
	Then the '15'% discount and shipping is applied to the total
	And the total is calculated correctly


#Test Case 2- following given; places order and checks its present in placed orders



Scenario: Confirm order has been placed
	When I checkout with my details
	#inline table 
	Then My order is present in my Orders

