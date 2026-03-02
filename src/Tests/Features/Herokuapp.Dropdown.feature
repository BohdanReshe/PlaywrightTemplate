Feature: Herokuapp Dropdown

  @regression @herokuapp
  Scenario: Select dropdown option
    Given I open Herokuapp
    When I go to Dropdown page
    And I select option "1"
    Then selected option should be "1"