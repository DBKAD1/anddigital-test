
# AND Phone Number API
> .Net Rest API to perform actions on Phone Numbers

This API enables users to access a database of a phone company and:
* List all the Phone Numbers of all registered users.
* List the Phone Numbers of a single user.
* Activate a phone number

## Installing 

* You can download the [phone](dist.zip) to set up and test the application without building it.
* Extract the contents to a suitable location.
* Add it as a new .Net framework 4 application to IIS,IIS Express or any suitable web server and run.
* You test the endpoints using any Rest client, See below for examples.


### Initial Configuration

Set it up an any Web Server of your choice, give the service write access to the MockData folder in the root folder.

## Developing

This project was created using the Visual Studio and C#
You can download this repository or use the git command below to clone it.

```shell
git clone https://github.com/DBKAD1/anddigital-test.git
```

### Building
* Open the folder in windows explorer
* Double click the ANDTechTest.sln file to open the solution.
* Restore the NuGet Packages
* Run the test 
* Build the solution


### Deploying / Publishing

* You can run the Web API from Visual Studio by hitting the F5 key on your keyboard or using the run button.
* You can set it up as a Web Application in any Application Server of your choice.
* Make sure the MockData folder is present in the rot folder of the web site.

## Testing

* Get all phone numbers
```shell
curl  http://localhost:121/api/PhoneNumbers/
```

* Get phone numbers for a single customer
```shell
curl  http://localhost:121/api/PhoneNumbers/{email}/
```

e.g.

```shell
curl  http://localhost:121/api/PhoneNumbers/angela_97@example.com/
```
Note: Always append a slash (/) after the email address, if not the .com at the end will confuse the router 

* Activate Phone Number

```shell
curl -d "" -i -X PUT "http://localhost:121/api/PhoneNumbers/{number}/{code}"
```

e.g.

```shell
curl -d "" -i -X PUT "http://localhost:121/api/PhoneNumbers/(959)%20743%206829/a3ess82f223"
```
### Mock Data
This API is based on am imaginary Database, as a result you can use the values is [customer.json](MockData/Customers.json) for your test.


## Links

- Project homepage: https://github.com/DBKAD1/anddigital-test
- Swagger API Contract: [ANDTestSwagger.json](UI/ANDTestSwagger.json)


