# PumoxCompaniesApp 
The present solution is a very simple implementation of an app for persisting company workers and their data. It is used as an template, or mold to create my other, more advanced professional projects. It lacks of some unit tests, and they will be consistently added. 

After the succesfull launch the swagger documentation will be found at: https://localhost:5001/swagger/index.html. The the user can authenticate using following endpoint: https://localhost:5001/company/authenticate. User data as follows:
| login: | hasło: |
| ------ | ------ |
| test | test |
- as an ORM the EF was used. It might be replaced with other engine if required.
- Xunit used for unit tests writing.
