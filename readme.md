
# AND Phone Number API
> .Net Rest API to perform actions on Phone Numbers

This API enables users to access a database of a phone company and:
* List the phone numbers of all registered users.
* List the phone numbers of a single user.
* Activate a phone number.

## Installing 

* You can download the [binary files](dist.zip) to set up and test the application without building it.
* Extract the contents to a suitable location.
* Add it as a new .Net framework 4 application to IIS,IIS Express or any suitable web server and run.
* Test the endpoints using any Rest client, see the [Testing](#testing).


### Initial Configuration

Set it up on any Web Server of your choice, give the service 'write access' to the MockData folder in the root folder.

## Developing

This project was created using the Visual Studio and C# . You can download this repository or use the 'git' command below to clone it.

```shell
git clone https://github.com/DBKAD1/anddigital-test.git
```

### Building
* Open the folder in windows explorer.
* Double click the ANDTechTest.sln file to open the solution.
* Restore the NuGet packages.
* Run the test projects.
* Build the solution.


### Deploying / Publishing

* Run the Web API from Visual Studio by hitting the F5 key on your keyboard or using the run button.
* Set it up as a Web Application in any Web Server of your choice.
* Ensure the MockData folder is present in the rot folder of the website.

## <a name="testing"></a>Testing

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
Note: Always append a slash (/) after the email address, else the .com at the end will confuse the router.

* Activate Phone Number

```shell
curl -d "" -i -X PUT "http://localhost:121/api/PhoneNumbers/{number}/{code}"
```

e.g.

```shell
curl -d "" -i -X PUT "http://localhost:121/api/PhoneNumbers/(959)%20743%206829/a3ess82f223"
```
### Mock Data

This API is based on an imaginary database, as a result you can use the values at [customer.json](ANDDigitalTest/MockData/Customers.json) for your test.


## Links
- Project homepage: https://github.com/DBKAD1/anddigital-test
- Swagger API Contract: [ANDTestSwagger.json](UI/ANDTestSwagger.json)


