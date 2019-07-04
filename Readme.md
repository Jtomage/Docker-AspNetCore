# Docker-AspNetCore
A simple Asp.NET Core application wrapped with docker. There are 2 web applications
* CoreApiContainer
* CoreWebContainer

**CoreApiContainer** is a simple RESTful web api. Call https://[Insert URL and port if necessary]/api/Values
**CoreWebContainer** is a simple web UI using asp.net core and MVC. The home page does a basic print, call the api from the back then a Jquery AJAX call to the web api

The idea behind this architecture is the seperation between the Web UI and the Data access layer that call that accesses the database. This should allow easier updating to the Web UI and data layer and reuse of the data access layer such as a mobile application.

Future Updates
- [ ] Configurable ports aka not hard coded
- [ ] Environment variables configuration support for docker
- [ ] SSL Certificate support
- [ ] docker swarm support
- [ ] kubernetes support
- [ ] Attach database
- [ ] Attach InMemory database
- [ ] Encryption support
- [ ] DNS support

## Getting Started
Download and install docker

## Build the Docker image
Currently each of the projects have their own Dockerfile to be built independently of each other. Use the command
```
docker build -t=[tagName] [path]
```
Where
* [tagName] - the name of the tag to use
* [path] - the path to the code

## Run the Docker image
use the command to run the docker image
```
docker run -p [port]:80 --name [name] [imageTag]
```
Where 
* [port] - the port that the application should use. Currently the default is 80 for both projects which is a problem.
* [name] - name of the container
* [imageTag] - the image tag the application that will run

## Issues
### Windows 10 
There may be a problem when trying to run the docker image if the port has been used previously. Check to see that the application using the port has been stopped and removed. If it has been removed then restart Docker which should clean up the port and allow the container to run. Sample of error
```
Error starting userland proxy
```
