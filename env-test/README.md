# Env test

Environnement for appli DotNet


## How to launch Docker

```sh
cd FamillyShare/FamillyShare
docker build -t famillyshare/dotnet:0.1 .
```

```sh
docker run -d -p 2000:80 famillyshare/dotnet:0.1 
```