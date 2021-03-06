Publish Profiles: Publish profiles are the preferred method of publishing Database changes. They are good for manipulating data pre and post publish. 

    1. Editing existing Column / Table
    
    2. Editing Data or Constraints
    
    3. Adding a Column / Table / Stored Procedure / View

    4. Removing a Column / Table / Stored Procedure / View
    
    5. Editing Stored Procedure / View

    Warnings/Advice:
        1. Target Platform - You might need to change the Target Platform for a given database version 
            
            a. SQL Server 2012, SQL Server 2008, etc ...
            
            b. To change the Target Platform
                i.      Right click on the Db Project. 
                ii.     Select 'Properties'. 
                iii.    Select 'Project Settings' in the properties window. 
                iv.     Change the desired Target Platform to the ones listed above

        2. Publish Scripts - Please use and read your publish scripts when publishing. It will help you trouble shoot problems.
            a. After clicking on a publish profile use the 'Generate Script' only. 
               Automatic publishes can be dangerous if existing columns or tables have been changed.
            b. Please read and review your publish script before running it
            c. When altering columns watch out for 'RAISERROR' in your publish script. 
               You may need to comment these errors out if thee intended column/table was meant to be changed 
            d. Always test scripts in Dev and Test before running them in Prod

        3. Variables - You can use version and environment variables to trigger certain Pre and Post deploy queries
            a. Environment = text representation of the application's current environment example 'Dev'
            b. VersionNumber = text representation of the application's version example '3.0.0.0'

        4. Limitations - 
            a. Renaming - Careful renaming columns and tables. Often the deploy script builds and assumes a drop and create. 
               When renaming anything always rename your table or column in the a Pre deploy script wrapped in a sys.(table or column) check
            b. Strict Data - Careful changing columns from nullable to non-nullable, changing data type, or data type size. 
               You need to clean all data with your new stricter rule and check in a pre deploy script. 
               If data is found that does not comply with your new rule the build script will fail.
                