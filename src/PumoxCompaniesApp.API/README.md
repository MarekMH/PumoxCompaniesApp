# PumoxCompaniesApp 

Niniejszy projekt stanowi rozwi¹zanie zadania rekrutacyjnego dla firmy Pumox w technologi ASP.NET Core Web Api. Stara³em siê spe³niæ wszyscy za³o¿enia, solucja jest typu konsolowego, w przypadku wykorzystania polecenia ``` dotnet run``` domyœlnym serwerem bêdzie Kestrel. Ja do testowania u¿ywa³em za ka¿dym razem Visual Studio 2019. 
Nastêpnie nastapi przekierowanie pod adres z dokumentacj¹: https://localhost:5001/swagger/index.html. U¿ywaj¹c Swaggera mo¿na dokonaæ uwierzytelnienia pod endpointem https://localhost:5001/company/authenticate. Dane u¿ytkownika to:
| login: | has³o: |
| ------ | ------ |
| test | test |
- Do ORM wykorzysta³em Entity Framework, oraz EF in-memory database, w celu ograniczenia konfiguracji. 
- Nie tworzy³em serwisów dla pracowników, jako ¿e  zadanie nie wymaga dostarczenia takiej funkcjonalnoœci. W akcjach typu POST nie podaje siê w naszym zadaniu numeru ID, dlatego za³o¿y³em,  pracownicy mog¹ byæ zatrudnieni tylko w jednej firmie. W przypadku aktualizacji program sprawdza, czy w danej firmie istnieje pracownik o tym samym nazwisku, imieniu i dacie urodzania. Jeœli tak, to go aktualizuje, a jeœli nie to dodaje nowego pracownika. Za³o¿y³em, ¿e mog¹ istnieæ dwie firmy o identycznych nazwach i pracownikach (w bazie bêd¹ mia³y odmienne numery Id). 
- W trakcie walidacji program sprawdza czy istniej¹ pola wymagane i spe³niaj¹ okreœlone warunki. Pola dodatkowe s¹ ignorowane. W przypadku wyszukiwania firmy z u¿yciem POST, pola opcjonalne w JSON'ie mog¹ byæ równe null (lower case), lub pominiête. 
- Do ochrony zapytañ u¿ywana jest metoda „Basic Authentication”.
- Do stworzenia 64-bitowego klucza g³ównego zastosowa³em typ long (int64)
- Do napisania testów zastosowa³em xUnit. Niestety zd¹¿ylem napisaæ testy do kilku kontrolerów, co jest spowodowane ma³¹ iloœci¹ czasu. Zazwyczaj d¹¿ê do pokrycia testami ok. 80% kodu. 