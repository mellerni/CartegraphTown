/*
 Post-Deployment Script                            
*/

PRINT N'Running Post-Deployment Scripts'

IF('$(VersionNumber)' = N'Seed')
BEGIN
    PRINT N'Post-Deployment Scripts for version "Seed"';
    :r .\PostDeploy\Seed\AddStates.sql
END

--Example of adding new post scripts
--IF('$(VersionNumber)' = N'3.1.0.0')
--BEGIN
--    PRINT N'Post-Deployment Scripts for version 3.1.0.0';
--    :r .\PostDeploy\Version_3_1_0_0\PostNotificationClickTypeChange_12152017.sql
--END
