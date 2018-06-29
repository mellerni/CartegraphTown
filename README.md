# CartegraphTown
Simple web app for city employees to accept complaints from citizens

I only tested in:
* Chrome (67+)

## Installation and Setup

1. Clone the repository

2. Make sure you have Visual Studio 2017 Installed
    Community edition should work if you can't get a Professional or Enterprise licence.
    VS 2017 comes with Core and Node support.

    *This project might build in VS 2015 with the Core SDKs install. I haven't tried it.

3. Install the .Net Core 2 SDK if needed
    https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.4

4. Install C# dependencies
    Open the solution file with Visual Studio 2017. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.sln
    Re-Build the entire solution. This installs the Nuget package dependencies.

5. Install npm and node
    Open you favorite terminal.
    Change you directory to the web project. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.Web
    See if you have node already installed.
     ``` $ node -v  ```
     See if you have npm already installed.
     ``` $ npm -v  ```

    Im currently running these versions:

    ```
        $ npm -v
        5.6.0

        $ node -v
        v8.11.1
    ```

    If you do not have node or npm you can download them from the node website.
    https://nodejs.org/en/
    Please install the LTS version, Latest Stable Version.

5. Create a new Database
    Open SSMS - Sql Server Management Studio.
    Connect to a local instance of a sql server.
    ``` Example: (localdb) ```
    Right click on the database.
    Create a new database called CartegraphTown
    ``` CartegraphTown ```
    Copy the name of the local instance of your sql server. We  will use that in the next step.

6. Connect Sql Database to projects

    Open the CartegraphTown.Database project in Visual Studio
    Double click on the Dev.publish.xml file. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.Database\PublishOptions\Profile\Dev.publish.xml
    Click 'Edit'.
    Click 'Browse'.
    Paste in the local instance of a sql server in the 'Server Name' input.
    Select the CartegraphTown database from the 'Database Name' drop down.
    Click 'OK'.
    Copy the 'Target database connection'.
    Click 'Save Profile'.
    Click 'Generate Script'.

    The script will take a minute to build.
    Run the script by clicking the Green Play button.
    Everything worked correctly when you see 'Update complete' in the T-SQL window display.

    Open the CartegraphTown.API project Web.config. [Your Repository Directory]\CartegraphTown\CartegraphTown\CartegraphTown.API\Web.config
    Careful not to open Web.Debug.config or Web.Release.config because they are not configured.
    Find 'CartegraphTownContext' connection string (Line 12) and paste in your 'Target database connection' from earlier.

7. Setup Multi Project Solution
    Right click on the solution.
    Choose 'Set Start Up Projects'.
    Select 'Multiple startup projects'.
    Set action to 'Start' on CartegraphTown.API and CartegraphTown.Web.

8. Run the apps
    Two windows should pop up in your browser.
    Please use Chrome for best results.