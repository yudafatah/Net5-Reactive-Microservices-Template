# Net5-Reactive-Microservices-Template
Reactive Microservice Template for e-commerce written in Net 5

## Tech Stack:

RabbitMQ
Kafka
MediatR
CQRS Pattern
Sql Server
Dapper
Swagger / OpenApi
Source Generator to generate Api Controller based on record in MediatR

## Kafka Setup
#### Start Zookeeper
kafka> .\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties
#### Start Kafka
kafka> .\bin\windows\kafka-server-start.bat .\config\server.properties

#### Create Topic
.\bin\windows\kafka-topics.bat --create --zookeeper localhost:2181 --replication-factor 1 --partitions 1 --topic EcommTopic
#### Create Publisher
.\bin\windows\kafka-console-producer.bat --broker-list localhost:9092 --topic EcommTopic
####Create Consumer
.\bin\windows\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic EcommTopic --from-beginning
