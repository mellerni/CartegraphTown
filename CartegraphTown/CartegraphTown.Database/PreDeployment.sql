/*
 Pre-Deployment Script                            
*/

PRINT N'Running Pre-Deployment Scripts'

--Example of adding new pre scripts
--IF('$(VersionNumber)' = N'3.1.0.0')
--BEGIN
--    PRINT N'Pre-Deployment Scripts for version 3.1.0.0';
--    :r .\PreDeploy\Version_3_1_0_0\PreNotificationClickTypeChange_12152017.sql
--END