CREATE USER [cartegraph] FOR LOGIN [cartegraph];

GO
﻿EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'cartegraph';
