# AppNarcServer
AppNarc is a productivity tool that tracks how much time you use applications on your computer.
This repository is the server side portion of AppNarc, which the client side application reports the applications and amount of time you use them.
There is also a web UI that pulls data from the server to visualize your application usage.

## Build
If you want to build from the command line, you can just use the basic dotnet build command.
```
dotnet build
```

## Run Tests
AppNarc uses NUnit for automated unit tests. You can utilize the dotnet test lifecycle to run the unit tests in the project.
```
dotnet test
```

## Docker
You can build/run a local container of the AppNarcServer project.
You need to have Docker installed as a prereq. You may follow these directions to install on Windows:
https://docs.docker.com/docker-for-windows/install/

### Build Docker Image

```
cd AppNarcService
```

```
docker build
```

### Start Docker Container
```
docker run
```

## Tech Stack
- C# / ASP.NET - main language and framework for the web service.
- MongoDB - database.
- NUnit - unit testing.
- RabbitMQ - message broker service.

## Future Plans
Eventually this will be in an issue tracker such as JIRA or in Azure DevOps.
- Implement GraphQL for the web service API.
- Startup scripts - specifically for setting up dev environment w/ Docker. 
(Currently, the project only contains a Dockerfile - so you still need to manually build/deploy/run the image as a container.)
- Additional unit testing.
- Additional APIs for users, app information, etc.

## Issue Tracking and Contributions
You may log issues you find here: https://github.com/jctierney/AppNarcServer/issues

If you would like to contribute, you may find an existing issue (or one you report) and submit a pull request for the fix.