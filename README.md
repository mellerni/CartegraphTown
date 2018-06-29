# CartegraphTown
Simple web app for city employees to accept complaints from citizens

## Notes
Achitecture <br />
    MS SQL Server <br />
    CartegraphTown.Database <br />
    CartegraphTown.Model <br />
    CartegraphTown.Service <br />
    CartegraphTown.API <br />
    CartegraphTown.Web <br />

I only tested in:
* Chrome (67+)

## Quick links (relevent 6/29/2018)
Visual Studio 2017: https://visualstudio.microsoft.com/downloads/<br />
<br />
.Net Core 2: https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.4<br />
<br />
Node and NPM: https://nodejs.org/en/<br />
<br />
Sql Server: https://www.microsoft.com/en-ie/sql-server/sql-server-downloads <br />
<br />
SSMS: https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms <br />
<br />

## Video links
    Install: https://www.youtube.com/watch?v=_24fRKegk6Q [Run time 17:51]  <br />
    Quick Demo: https://www.youtube.com/watch?v=fS2zCebbN2U [Run time 6:58] <br />

## Installation and Setup

1. Clone the repository

2. Make sure you have Visual Studio 2017 Installed <br />
    <br />
    Community edition should work if you can't get a Professional or Enterprise licence.<br />
    VS 2017 comes with Core and Node support.<br />

    *This project might build in VS 2015 with the Core SDKs install. I haven't tried it.<br />

3. Install the .Net Core 2 SDK if needed<br />
    <br />
    https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.4<br />

4. Install C# dependencies<br />
    <br />
    Open the solution file with Visual Studio 2017. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.sln<br />
    Re-Build the entire solution. This installs the Nuget package dependencies.<br />

5. Install npm and node<br />
    <br />
    Open you favorite terminal.<br />
    Change you directory to the web project. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.Web<br />
    See if you have node already installed.<br />
     ``` $ node -v  ```<br />
     See if you have npm already installed.<br />
     ``` $ npm -v  ```

    Im currently running these versions:

    ```
        $ npm -v
        5.6.0

        $ node -v
        v8.11.1
    ```

    If you do not have node or npm you can download them from the node website.<br />
    https://nodejs.org/en/<br />
    Please install the LTS version, Latest Stable Version.<br />

5. Create a new Database<br />
    <br />
    Open SSMS - Sql Server Management Studio.<br />
    Connect to a local instance of a sql server.<br />
    ``` Example: (localdb) ```<br />
    Right click on the database.<br />
    Create a new database called CartegraphTown<br />
    ``` CartegraphTown ```<br />
    Copy the name of the local instance of your sql server. We  will use that in the next step.<br />

6. Connect Sql Database to projects<br />
    <br />
    Open the CartegraphTown.Database project in Visual Studio <br />
    Double click on the Dev.publish.xml file. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.Database\PublishOptions\Profile\Dev.publish.xml <br />
    Click 'Edit'. <br />
    Click 'Browse'. <br />
    Paste in the local instance of a sql server in the 'Server Name' input. <br />
    Select the CartegraphTown database from the 'Database Name' drop down. <br />
    Click 'OK'. <br />
    Copy the 'Target database connection'. <br />
    Click 'Save Profile'. <br />
    Click 'Generate Script'. <br />
    <br />
    The script will take a minute to build.<br />
    Run the script by clicking the Green Play button.<br />
    Everything worked correctly when you see 'Update complete' in the T-SQL window display.<br />
    <br />
    Open the CartegraphTown.API project Web.config. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.API\Web.config <br />
    Careful not to open Web.Debug.config or Web.Release.config because they are not configured. <br />
    Find 'CartegraphTownContext' connection string (Line 12) and paste in your 'Target database connection' from earlier. <br />

7. Setup Multi Project Solution<br />
    <br />
    Right click on the solution.<br />
    Choose 'Set Start Up Projects'.<br />
    Select 'Multiple startup projects'.<br />
    Set action to 'Start' on CartegraphTown.API and CartegraphTown.Web.<br />

8. Run the apps<br />
    <br />
    Two windows should pop up in your browser.<br />
    Please use Chrome for best results.<br />
