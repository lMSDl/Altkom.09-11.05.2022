* Pakiety
```
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools (dla VS)
```

* Instalacja dotnet-ef (CLI)
```
dotnet tool install --global dotnet-ef
```

* ConnectionString dla MSSql
```
Server=(localdb)\mssqllocaldb;Database=<name>
Server=(local);Database=<name>;Integrated Security=true
Server=(local)\\SQLExpress;Database=<name>;Integrated Security=true
Server=<ip>;Database=<name>;Integrated Security=true
Server=(local);Database=<name>;User ID=<login>;Password=<password>
```

* Migracje
  * CLI
  ```
  dotnet ef migrations add <name>
  dotnet ef migrations remove [-f]
  dotnet ef database update
  ```
  * Package Manager Console
  ```
  Add-Migration <name>
  Remove-Migration [-f]
  Update-Database
  ```
* Database first
  * CLI
  ```
  dotnet ef dbcontext scaffold <connection string> <provider package>
  dotnet ef dbcontext scaffold "Server=(local);Database=EFC;Integrated security=true" Microsoft.EntityFrameworkCore.SqlServer
  ```
    * Package Manager Console
  ```
  Scaffold-DbContext <connection string> <provider package>
  Scaffold-DbContext "Server=(local);Database=EFC;Integrated security=true" Microsoft.EntityFrameworkCore.SqlServer
  ```
