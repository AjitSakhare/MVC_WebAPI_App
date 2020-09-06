# Project Title

Contact Information Management System

# About Proejct 
      This project contains feature to manage contact list like name,phone number, email addresss etc

## Getting Started

    These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.
        1 Once download is complete then build the soltution.
        2 If solution still not build properly, then close visual studio instannce and again open and build.
        3 Make sure you selected .net framework as 4.7 or above.
    
#### WebConfig Setting

  Replace XXX with in webconfig data source and intial catalog > data source=XXX;initial catalog=XXX    

### Prerequisites

Technology Used
```
    MVC - Layer Architecture
    .net framework 4.7.1
    Entity Framework 6 - Database First approach
    Unit testing - Nunit
    Unity for Dependancy Injection
    Web API
    Jquyer/Boostrap for UI side
    SQL server to store data/record 
```
### Database Script
```
User below script to create table 

 CREATE TABLE [dbo].[zUserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](255) NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_zUserDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[zUserDetails] ADD  CONSTRAINT [DF_zUserDetails_Status]  DEFAULT ((0)) FOR [Status]
GO
```

### Complete Project Structure

    Implemented layer stured, this project have main four projects
     > Web Application  - ContactInfo.Web
     > Data access layer - DataAccessComponent
     > Bussiness acess layer - BussinessComponent
     > Unit testing - UnitTestsComponent
   ![Folder Structure](https://github.com/AjitSakhare/MVC_WebAPI_App/blob/WebAppContInfo/layedArchitecture.PNG)
   
    MVC proejct Structure
   ![MVC Folder Structure](https://github.com/AjitSakhare/MVC_WebAPI_App/blob/WebAppContInfo/MVC%20structure.PNG)
   
    Home page
   ![Home Page](https://github.com/AjitSakhare/MVC_WebAPI_App/blob/WebAppContInfo/Home%20page.PNG)
