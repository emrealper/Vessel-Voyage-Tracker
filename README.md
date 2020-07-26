# Vessel-Voyage-Tracker
A project that simulates the sample scenario which demonstrates to collect Vessel Voyage Data based on Automatic Identification System (AIS) from AWS S3 and push to Azure Cosmos DB and provide this data over REST API securely.

Swagger ui can be accesible on http://20.52.55.230:5000/swagger/index.html running on Azure Linux VM with Docker

The sample request shown below represents the movement records of specific vessel between 2017-07-12 10:06:01 and 2017-07-12 10:30:01

curl -X GET "http://20.52.55.230:5000/api/VesselHistory/GetAll/241486004/2017-07-12T10%3A06%3A01/2017-07-12T10%3A30%3A01" -H "accept: text/plain" -H "VesselPositionTracker-Api-Key: 1234"


