* Pakiety
```
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools (dla VS)
```

* Instalacja dotnet-ef (CLI)
```
dotnet tool install --global dotnent-ef
```

* ConnectionString dla MSSql
```
Server=(localdb)\mssqllocaldb;Database=<name>
Server=(local);Database=<name>;Integrated Security=true
Server=(local)\\SQLExpress;Database=<name>;Integrated Security=true
Server=<ip>;Database=<name>;Integrated Security=true
Server=(local);Database=<name>;User ID=<login>;Password<password>
```

* Migracje
  * CLI
  ```
  dotnent ef migrations add <name>
  dotnent ef migrations remove [-f]
  dotnent ef database update
  ```
  * Package Manager Console
  ```
  Add-Migration <name>
  Remove-Migration [-f]
  Update-Database
  ```
