# TwoRingApp

This app has two parts. First one is server part, which is made with .Net Core 2.2 and second one is client part. Client uses Bootstrap
for client part design.

Server web api is also accesible through swagger, where you can try to send request to the server.

![Alt text](./screens/swagger.png?raw=true "screenshot web")

Client shows table of queues with some data. 

You can filter these data by choosing time period. There are three predefined periods, which you can click, and they fill into inputs. Then you can send request for data by click on "show data" button. Another filter is queue filter. If you leave it blank it shows you data from all queues. You can fill it with names of queues, which you want to see. These names has to be separated by comma (example: Programmers,Sales,zk).

![Alt text](./screens/client.png?raw=true "screenshot web")

Part of this project are several SQL files. These files contains 4 functions, 1 procedure and 1 definition of table type. These are used for obtaining data from SQL server by filter setting which comes from client.
