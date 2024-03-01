Database
---------

create database namely DotNetTask.
Open the script file and copy 5 create table code
execute the code

or 

execute the script file in the sql server database


-----------------------
project configuration
------------------------


1. Open the project in the visual studio

2. Open the SQL Server database and copy Server Name

3. Go into the Project and Click on Server Exploder in the View Tab

4. Click on the databse icon (connect to Database Icon)

5. Paste the server name copied from the SQL server in the Server name input text

6. Select Windows Authentication from the authentication dropdown

7. Check the trust server certificate

8. Select your database from the database dropdown

9. Click on advance option and copy the connection string

10. Go to project and open the web.config file

<appSettings>
	<add  key="ConnectionString" value="your connection string"/>
</appSettings>

11. Paste this code into your web.config file below ConnectionString tag

12. Replace your connectionstring in the value field

13. Run the project




-------------------------------------

5 forms are created

-------------------------------------


1. Default.aspx and Update.aspx to update the data. But it will be opened by clicking on the edit button inside default.aspx file

2. Form2.aspx and UpdateProduct.aspx file to edit

3. UserInfo and UserInfoUpdate

4. Form4 

5. Form5 and Form5Update


