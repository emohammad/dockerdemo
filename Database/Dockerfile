FROM mysql

#Add a database
ENV MYSQL_DATABASE Test

#add all the contents scripts folder to image
#all scripts in docker-entrypoint-initdb.d/ are automatically executed during container setup

COPY ./Scripts/ /docker-entrypoint-initdb.d/
