Dokumentacja Aplikacji Księgarni

1. Wstęp

Aplikacja do zarządzania książkami w księgarni z kontami użytkownika pozwalającymi na wypożyczanie książek oraz kontem admina pozwalającym na edycje listy książek.

2. Wymagania Systemowe:

- System operacyjny (Windows)
- Framework (np. .NET Core w wersji X.X)
- Serwer bazy danych (np. Microsoft SQL Server Management Studio)
- Przeglądarka internetowa wspierająca HTML5, CSS3 i JavaScript

3. Instalacja i Konfiguracja

Szczegółowe kroki instalacji aplikacji, w tym:

- Konfiguracja środowiska (Core, .NET SDK, Framework)
- Konfiguracja łańcucha połączenia z bazą danych w plikach konfiguracyjnych
- Przygotowanie bazy danych:
  - Uruchomienie skryptów SQL tworzących schemat bazy i niezbędne tabele
  - Wprowadzenie danych testowych 

4. Uruchomienie Aplikacji

Opis, jak uruchomić aplikację lokalnie:

- Sklonuj repozytorium z Github
- Otwórz projekt w środowisku programistycznym (np. Visual Studio)
- Uruchom program w danym środowisku

5. Testowi Użytkownicy i Ich Hasła

- Użytkownik: user1 | Hasło: user123
- Użytkownik: user2 | Hasło: user123

6. Funkcjonalności Aplikacji

- Rejestracja i logowanie dla użytkowników
- Przeglądanie listy dostępnych książek
- Dodawanie nowych książek do bazy (dla admina)
- Edycja i usuwanie książek (dla admina)

7. Instrukcja Użytkownika

Opis interfejsu użytkownika wraz z instrukcjami korzystania z poszczególnych elementów, takich jak menu nawigacyjne, formularze wyszukiwania, szczegóły książki itp. Oraz screenshoty interfejsu z podpisami wyjaśniającymi funkcje poszczególnych przycisków i sekcji.

8. Zarządzanie Katalogiem Książek

Aby dodać nową książkę, wybieramy zakładkę "Bookstore Management Panel" i klikamy opcję "Dodaj książkę". Następnie wpisujemy dane książki i zatwierdzamy je.

9. Zarządzanie Kontem Użytkownika

Użytkownicy mogą tworzyć konta w zakładce "Rejestracja", aby to lepiej brzmiało, można dodać, że mogą tworzyć swoje indywidualne konta, które umożliwią im dostęp do funkcji aplikacji.
10.Admin
Tylko admin po zalogowaniu może usuwać ewentualnie dodawać książki.
Admin ma specjalną zakładkę do zarządzania użytkownikami może np. usuwać użytkowników

Jeden z adminów 
Login:admin haslo:admin


11.Zapisywanie w Bazie danych 
Wszystkie zmiany wprowadzone na stronie (rejestracja, dodawanie książek itp.). Zapisywane są w bazie danych.


