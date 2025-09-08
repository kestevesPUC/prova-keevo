
## Criar Controller

To start a local development server, run:

```bash
dotnet aspnet-codegenerator controller -name NomeController -async -api -outDir App/Controllers
```

## Criar Model 

To start a local development server, run:

```bash
dotnet aspnet-codegenerator model -name Nome -async -api -outDir App/Model
```

## Criar Repositiorio (DAO)

To start a local development server, run:

```bash
dotnet aspnet-codegenerator repositorie -name NomeRepositorie -async -api -outDir App/Repositories
```





## DB

Use o comando dotnet ef dbcontext scaffold, passando sua connection string do Postgres e o provider Npgsql.EntityFrameworkCore.PostgreSQL:

```bash
dotnet ef dbcontext scaffold "Host=localhost;Database=MinhaBase;Username=postgres;Password=1234" Npgsql.EntityFrameworkCore.PostgreSQL -o Models
```

