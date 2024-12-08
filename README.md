# Back_End_WebAPI
MVP</BR>
Backend repository for the FIESC exam planner app, remade in .Net Core. </BR>

## Install Visual Studio

Download and install Visual Studio 2022 from [visualstudio.microsoft.com](https://visualstudio.microsoft.com/). </BR>
Select the ASP.NET and web development workload. </BR>

## Clone the Repository

Clone the project repository using the following command:

```sh
git clone https://github.com/Code-Rim-USV/Back_End_WebAPI.git
```

## Install PostgreSQL

Follow the tutorial from [w3schools](https://www.w3schools.com/postgresql/). <BR>
For a password select 12345 or modify the connection string variable from appsettings.json with your own password.

## Configure Database

Open PgAdmin 4 select your server and type your password, then right click on Databases and select <b>Create</b>><b>Database</b>.<Br>
In the new popup window type in the required field Database <b> examplanner </b>, it is very important that the database names match, then click save. <Br>
Click the arrow beside Databases directory to open up all your databases, right click on the one named <b>examplanner</b> and select <b>Restore..</b>  <Br>
In the new popup window click on the folder icon in the required field Filename, a file explorer window will pop up, select the file named examplanner.sql from this repository.
## BugFix PgAdmin 4
In case the restore fails overwrite the executable found in  <b>PostgreSQL\17\pgAdmin 4\runtime\pg_restore.exe</b> with the one found in <b>PostgreSQL\17\bin\pg_restore.exe</b> <br>
Delete the database and try again.

## Run Project

Open the solution in visual studio and press F5