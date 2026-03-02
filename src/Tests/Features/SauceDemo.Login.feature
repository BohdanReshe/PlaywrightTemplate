Feature: SauceDemo Login

  @smoke @saucedemo
  Scenario: Successful login goes to inventory
    Given I open SauceDemo
    When I login as "standard_user" with password "secret_sauce"
    Then I should see inventory page