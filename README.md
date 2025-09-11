# Learning Angular




# Docker

- Criar db postgres
``` docker
docker run --name keevo   -e POSTGRES_DB=keevo   -e POSTGRES_USER=kesteves   -e POSTGRES_PASSWORD=123456   -p 5432:5432   -d postgres:latest
```

# Migrations

```bash
dotnet ef database update
```

# Start 

## Frontend
``` bash
cd ./frontend
npm install
npm start
``` 

## Backend
``` bash
cd ./backend
dotnet restore
dotnet run
``` 


