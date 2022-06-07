# CompanyRegister 
 
Answers to required README questions: 
How to setup and run the service using docker - as I am not very familiar with docker, I just downloaded Docker desktop client, ran app in Docker mode and it automatically mounted the image. 
How to query the API using cURL: 
get all companies list: curl -X GET "https://localhost:44381/Company" -H  "accept: */*" 
create company: curl -X POST "https://localhost:44381/Company" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"country\":\"string\",\"phoneNumber\":0,\"name\":\"string\"}" 
get one company information: curl -X GET "https://localhost:44381/Company/1" -H  "accept: */*" 
edit company: curl -X PUT "https://localhost:44381/Company/Edit/1" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"country\":\"string\",\"phoneNumber\":0,\"name\":\"string\"}" 
add owner to the company: curl -X PUT "https://localhost:44381/Company/AddOwner/1?ownerName=ownerName&ownerSocSecNumber=ownerSocSecNumber" -H  "accept: */*" 
check owners Social Security number: curl -X GET "https://localhost:44381/Owner/CheckOwnerSec/1" -H  "accept: */*" 
 
Other important information: 
1. Unfortunately, I had no knowledge about access/authentication/security of APIs, so I did not implement any access groups. What I could do (but it may be not "good" thing) create another Owner model without Social Security number , or make it nullable and return it null or model without it if specific user is trying to access it. So when calling api for detailed information, the api would require to get company Id and e.g. userId. Depending on userId, the api would return full or not full information. 
2. I made application with local database, to test if it is working correctly.
