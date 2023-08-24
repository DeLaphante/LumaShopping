Feature: LumaShopping_UI

Background: Navigate to homepage
	Given user is on the homepage


Scenario: Place an order
	Given user is on the 'Tops' page
	When user adds items to the cart
	And places the order
	Then the order should be successfully placed


Scenario: Create an account
	Given user is on the Create New Customer Account page
	When the user creates an account
	Then the account should be successfully created
