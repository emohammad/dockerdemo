# Lab instructions

You'll be working on two labs as part of containers and kubernetes intro session. Lab 1 will be using docker playground and Lab 2 will be using Kubernetes playground from katacoda. Follow the instructions below for each Lab

## Lab 1 (Docker)

Navigate to [https://www.katacoda.com/courses/docker/playground](https://www.katacoda.com/courses/docker/playground). If it asks for you to login then register using any of your personal accounts
Click on Start Scenario to start the play ground. 
We'll be creating two docker containers as part of this lab. One for frontend and one for backend. Backend is a mysql container and it will be setup using scripts to create a database and required tables. Frontend is a .net core application which is basic crud app using mysql as backend.

 1. Clone the repo using command `git clone https://github.com/emohammad/dockerdemo`
 2. Switch to dockerdemo directory. `cd dockerdemo`
 3. Build the .net image `docker build -t usersdemo .` Do not forget the `.` at the end of the command as it specifies the context for the docker to build.
 4. Switch to Database folder. `cd Database`
 5. Build the database image `docker build -t usersdemo-mysql .`
 6. Create a docker network so two containers can communicate with each other `docker network create usersdemo`
 7. Run the database container first so database can be setup `docker run --net usersdemo --name usersdemo-mysql --hostname usersdemo-mysql -d -e MYSQL_ROOT_PASSWORD=password usersdemo-mysql`
 8. Run the .net core image and forward the port to host machine so we can browse it `docker run -p 80:80 --net usersdemo -d --name usersdemo --hostname usersdemo usersdemo`
 9. To test the app you can navigate to the link provided in Helpful Links section on the left in katacoda.
 
## Lab 2 (Kubernetes)

Navigate to [https://www.katacoda.com/courses/kubernetes/playground](https://www.katacoda.com/courses/kubernetes/playground) and click on Start Scenario. Wait for the k8s cluster to start up.
We'll be using the docker images created in Lab1 for this lab. For convenience i pushed the docker images to docker hub and when k8s pods are created it'll directly pull the images from the hub. 

 1. Clone the repo using command `git clone https://github.com/emohammad/dockerdemo`
 2. Switch to dockerdemo directory. `cd dockerdemo`
 3. Create a service for the backend first. Run `kubectl apply -f ./usersdemo-mysql.yml`
 4. Create a deployment for the backend which will create 1 pod using the docker image in hub. Run `kubectl apply -f ./usersdemo-mysql-deployment.yml`
 5. Create a service for the frontend . Run `kubectl apply -f ./usersdemo-frontend.yml`
 6. Create a deployment for the frontend which will create 2 pods using the docker image in hub. Run `kubectl apply -f ./usersdemo-frontend-deployment.yml`
 7. Run `kubectl get all` to check status of all services, pods and deployments. Pods should be in ready state.
 8. Run `kubectl get svc` to check the services. We should have a node port service which will expose the front end on a port. Port will be 5 digit and starting with 3.
 9. Click on + icon next to Terminal Host 1 window and click on select port to view on host 1. Enter the port number from previous command and click on display port. You should navigate to the app.

Any errors/questions please feel free to ask. 

