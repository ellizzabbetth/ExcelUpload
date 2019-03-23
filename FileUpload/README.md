

# Excel Upload

Create a web application that imports the attached Excel file. For the layout of the page, just keep it
clean and simple. Validate that the data from the file is accurate using the following rules:
● ID - integer
● First and Last Name - strings, less than 50 characters
● Age - integer
● Status - look up value of Active, Inactive, Hold
Next display the information in a grid, using pagination with no more than 50 records per page, and the
ability to sort any of the columns. Add filters to the top of the page to search on the name or status.

## Getting Started

A scale of 1 to 5 will be applied to the following areas:
● Ability to develop a web app using MVC, C#
● Ability to add validation to Excel import
● Quality of coding – SOLID, DRY, OOP
● Ability to write appropriate unit tests
● Ability to display a grid with pagination, sorting, and search filters
● Ability to write CSS, HTML that works in all major browsers
● Page has no accessibility issues
Bonus would be to use React for your front-end technology and APIs.

### Prerequisites

Visual Studio 2017

### Installing

Unzip project to local machine. Open solution in Visual Studio. Click IIS Express to start
web server.

## Running the tests

Before running Unit Tests verify that StaticFiles/Excel and StaticFiles/Json contain the upload Excel 
file and the parsed JSON file.
In 'web-api-test' project open Test Explorer. Select web-api-tests and click 'Run'

## Built With

* ExcelDataReader
* JSON.net
* Razor
* .Net Core Web API

## Features

* Post a form
* Post to API endpoint with AJAX
* Reflection
* Unit Tests

## Enhancements

* Improve Excel Valiation
* Create additional robust unit tests
* Make footer sticky


## Known Bugs
* Searching on age
* File Size limitations
* First and Last Name - strings, less than 50 characters

## Authors

* **Elizabeth Bradley** -

## Acknowledgments

* Yoga
* Lin-Manuel Miranda
* Sandy Lerner
* Plaid
* Elon Musk
