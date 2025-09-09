
## Criar Controller

```bash
dotnet aspnet-codegenerator controller -name NomeController -async -api -outDir App/Controllers
```

## Criar Model 

```bash
dotnet aspnet-codegenerator model -name Nome -async -api -outDir App/Model
```

## Criar Repositiorio (DAO)

```bash
dotnet aspnet-codegenerator repositorie -name NomeRepositorie -async -api -outDir App/Repositories
```

# DB

## Criar Migration

```bash
dotnet ef migrations add InitialCreate
```

```bash
dotnet ef database update
```
