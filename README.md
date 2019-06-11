# TechTest

AutomationTests is a testing framework for JsonPlaceholder API endpoints.
It was written in C# and using microsoft's unit testing framework.

JsonApiService.cs is a service meant to send generic api requests using httpclient. Uri in the constructor should be pulled into App.config.
JsonPlaceholderService.cs is using JsonApiService to send request to the JsonPlaceholder api endpoints. JsonApiService should be injected rather than instanciated in the constructor.
UnitTests.cs are my unit tests.

I've covered 3 endpoints:
1- Get all posts
	This endpoint returns all posts. and it's also an endpoint that's working as expected.

2- Create post
	This endpoint is meant to create and return me a post with a unique id. at least according to the documentation, but in reality it returns only an ID. It also does not create a post.

3- Delete post
	This endpoint is meant to delete a post by id. status code returned is correct but it does not delete a post as expected.



I have chosen to use default microsoft unit tests framework because it was the fastest to get working. If I was writing automation tests in a feature team i'd prefer writing them in SpecFlow with gherkin 
syntax since it makes it a lot easier to follow for non technical people.

I would have also used IOC, Dependency injection on JsonApiService and JsonPlaceholderService for scalability and usability purposes.
I've also used FluentAssertions nuget package for detailed errors on validation.

To run tests you can either execute them through Visual Studio IDE or navigate to your visual studio installation folder and execute tests through 
"\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" and point it at AutomationTests.dll which gets generated on project build.

the cmd command i've used for my tests is:
C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow>vstest.console.exe J:\Projects\TechTest\AutomationTests\bin\Debug\AutomationTests.dll /Logger:trx /ResultsDirectory:J:\Projects\TechTest\AutomationTests\TestResults

i've included a test result .trx file
