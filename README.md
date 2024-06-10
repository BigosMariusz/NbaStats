# NbaStats

Aplikacja integruje się z https://www.balldontlie.io/#introduction. Serwis ten udostępnia dane na temat ligi NBA. Serwis również mocno limituje ilość i częstotliwość pobieranych danych. Limit w darmowej wersji to 30 zapytań na minutę, a część danych jest dostępna jedynie dla bieżącego sezonu.

Proces integracji przebiega w taki sposób, że przy starcie aplikacji dane są pobierane i zapisywane do bazy. Przy kolejnym starcie nie próbujemy znowu pobierać danych i ich aktualizować, jest to uproszczenie, które w realnym świecie zazwyczaj nie występuje gdyż chcemy mieć cykliczną synchronizację i aktualizację zmian.

Jak uruchomić aplikację:

1. Musimy mieć zainstalowany serwer bazodanowy SQL Server oraz utworzoną pustą bazę danych.
Uwagi: Aplikacja nie tworzy automatycznie bazy danych co oczywiście byłoby możliwe choć nie zawsze porządane. Aplikacja tworzy strukturę bazy danych aplikując migracje przy starcie na wcześniej stworzonej bazie.
2. Musimy w pliku appsettings.json uzupełnić connection string do bazy danych w sekcji DbConnectionString.
3. Musimy w pliku appsettings.json uzupełnić klucz do API w sekcji NbaApiClient:ApiKeyValue. Klucz został podesłany.
4. Można uruchomić aplikację.

Aplikacja w trybie developerskim uruchamia Swaggera i pozwala na wykonywanie różnych zapytań pobierających dane drużyn, zawodników czy meczów w NBA.