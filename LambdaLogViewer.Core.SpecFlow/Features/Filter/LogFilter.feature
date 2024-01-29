Feature: LogFilter

A short summary of the feature

@logfilter
Scenario: Get all error lines
	Given A INFO line and a ERROR line logs
	When Filter is applied
	Then Get a ERROR line
