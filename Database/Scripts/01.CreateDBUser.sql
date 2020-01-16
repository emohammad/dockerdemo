CREATE USER 'testuser'@'%%' IDENTIFIED BY 'password';
GRANT ALL PRIVILEGES ON * . * TO 'testuser'@'%%';
FLUSH PRIVILEGES;