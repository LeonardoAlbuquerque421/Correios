Feature: Correios
    Scenario: Verify invalid CEP
        Given I am on the Correios website
        When I search for the CEP 80700000
        Then I confirm that the CEP does not exist

    Scenario: Verify valid CEP
        Given I am on the Correios website
        When I search for the CEP 01013-001
        Then I confirm that the result is "Rua Quinze de Novembro - lado ímpar"

    Scenario: Verify invalid tracking code
        Given I am on the Correios website
        When I search for the tracking code SS987654321BR
        Then I confirm that the code is not correct