Be sure to create the database on (localdb)\MSSqlLocalDB (or wherever you have it pointed to) in the
 connection string.

Set the "Web" project to the 'Startup' project, then open the Package Manager Console, and select the "Data" 
 project from the dropdown.  Run the command "Add-Migration InitialCreate", then after run "Update-Database".