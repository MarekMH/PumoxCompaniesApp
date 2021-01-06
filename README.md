# PumoxCompaniesApp 

Niniejsza solucja stanowi rozwi�zanie zadania rekrutacyjnego dla firmy Pumox w technologi ASP.NET Core Web Api. Stara�em si� spe�ni� wszyscy za�o�enia, projekt jest typu konsolowego, w przypadku wykorzystania polecenia ``` dotnet run``` domy�lnym serwerem b�dzie Kestrel. Ja do testowania u�ywa�em za ka�dym razem Visual Studio 2019.
Dokumentacj� Swagger mo�na znale�� pod nast�puj�cym adresem: https://localhost:5001/swagger/index.html. U�ywaj�c Swaggera mo�na dokona� uwierzytelnienia pod endpointem https://localhost:5001/company/authenticate. Dane u�ytkownika to:
| login: | has�o: |
| ------ | ------ |
| test | test |
- Do ORM wykorzysta�em Entity Framework, oraz EF in-memory database, w celu ograniczenia konfiguracji. 
- Nie tworzy�em serwis�w dla pracownik�w, jako �e  zadanie nie wymaga dostarczenia takiej funkcjonalno�ci. W akcjach typu POST nie podaje si� w naszym zadaniu numeru ID, dlatego za�o�y�em,  pracownicy mog� by� zatrudnieni tylko w jednej firmie. W przypadku aktualizacji program sprawdza, czy w danej firmie istnieje pracownik o tym samym nazwisku, imieniu i dacie urodzania. Je�li tak, to go aktualizuje, a je�li nie to dodaje nowego pracownika. Za�o�y�em, �e mog� istnie� dwie firmy o identycznych nazwach i pracownikach (w bazie b�d� mia�y odmienne numery Id). 
- W trakcie walidacji program sprawdza czy istniej� pola wymagane i spe�niaj� okre�lone warunki. Pola dodatkowe s� ignorowane. W przypadku wyszukiwania firmy z u�yciem POST, pola opcjonalne w JSON'ie mog� by� r�wne null (lower case), lub pomini�te. 
- Do ochrony zapyta� u�ywana jest metoda �Basic Authentication�.
- Do stworzenia 64-bitowego klucza g��wnego zastosowa�em typ long (int64)
- Do napisania test�w zastosowa�em xUnit. Niestety zd��ylem napisa� testy do kilku kontroler�w, co jest spowodowane ma�� ilo�ci� czasu. Zazwyczaj d��� do pokrycia testami ok. 80% kodu. 