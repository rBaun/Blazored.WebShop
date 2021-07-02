# Blazored WebShop
A hobby project to start learning Blazor to achieve my personal goal of becoming a Full-Stack Developer. 
The project is being build with multiple client and features, that is going to be split up accordingly.
The structure of the project follows the CLEAN-Architecture principles.

## Parts of the Project
This project is split into the following sections:

* **Customer Portal**
  * *Purpose*: The client for the customers of the Website has a limited view
  * *Technologies*: Blazor WebAssembly, .NET 5, C#, JSInterop, LocalStorage
* **Admin Portal**
  * *Purpose*: The client contains a secret route to /admin, used to handle orders
  * *Technologies*: Blazor WebAssembly, .NET 5, C#, Cookie Authentication, Authorization
* **Persistence**
  * *Purpose*: Adding Persistence to the project by implementing SQL Server
  * *Technologies*: MSSQL, Dapper
  
## Personal To-Do List
I work on this project on the run and will continue to modify and upgrade the project
This is a list containing what needs to be done in the future:

* **Beautify section**
  * Right now, there is not put any effort into the visuel design. This needs a makeover
* **Add Payment Section**
  * A fake payment gateway for customers
* **Shipping and Handling Integration**
  * Integrating a 3rd party delivery system into the webshop
* **Separate Client for Admins**
  * Right now, the client is using Authorization to show or not show components
  * In the future, this will become a separate client
