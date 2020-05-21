# Zadania

## Obsługa wyjątków
Zaimplementuj obsługę wyjątków które mogą zostać rzucone przy komunikacji z bazą danych (`IDatabase`).
Implementacja `IDatabase` może rzucać 2 rodzaje wyjątków:
1. `DbUnavailableException` gdy występuje techniczny problem podczas komunikacji z bazą
2. `RecordNotFoundException` gdy nie zostanie znaleziony rekord o przekazanym id
Wymagania:
1. Jeżeli operacja się powiedzie metoda `Handle` w klasie `CancelOrderHandler` powinna zwrócić `Result.Success` w przeciwnym przypadku `Result.Failure`.
2. Jeżeli wystąpi techniczny problem z połączeniem z bazą danych operacja powinna zostać ponowiona 3 razy.
3. Jeżeli mimo ponowień wykonanie operacji nie powiedzie się, to wyjątek trzeba zalogować na poziomie `LogLevel.Error`. Format logu: `Db is unavailable`
4. Jeżeli wystąpi nieprzewidziany wyjątek, to trzeba go zalogować na poziomie `LogLevel.Critical`. Format logu: `Bug in the code!!!`
3. Jeżeli rekord nie zostanie odnaleziony, to trzeba to zalogować na poziomie `LogLevel.Warning`. Format logu: `Missing order with id: {id}`
Do logowania użyj komponentu `ILogger`.
