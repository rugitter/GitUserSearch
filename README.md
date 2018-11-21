# GitUserSearch
# Objective: Build an ASP.NET Web App which can search Github users by user name.
           If user exists display his/her public profile information;
           If not existing display a proper messange on the web page.

# Development process:
Version 0: Read Github API documentation and Tested Github User API using Chrome and Postman.
           Both the user search API and all users API are working good.
           
Version 1: Utilized "Octokit" .NET package to implement the above functions.
           Octokit is a popular Github API package which implements most of the popular
           functions in several different languages.
           
Version 2: Re-design the Web App using MVC model to enable extra feature : Display Search history.
           All successful search will save the search-related data and the retrieved user details
           into a cloud database.
           
Version 3: Beautify the page.
           Import Bootstrap and jQuery.
           Add mininal CSS to each page.
           
 
Detailed Steps to enable MVC model:
   Create two models class (GitUser and UserSearch) (with proper annotation).
   Create/Modify DBcontext ane enable Dependency Injection.
   Create Database (My MS Azure SQL Server) and write in Connection string.
   Create/Check/Execute Migration file.
   Create controller to control each Views - Use Lambda to extra proper info which
      will then be passed to the corresponding views.
   Change routing rules.
           
