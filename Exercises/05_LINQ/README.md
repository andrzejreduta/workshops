# Zadania

## Przekształcanie danych w pamięci
W klasie `CustomerService` dokończ implementację metody `GetThreeRecentlyAddedCustomersFromWarsaw`.
Korzystając z `CustomerRepository` pobierz nazwy 3 ostatnio dodanych klientów z Warszawy.
Do ustalenia kolejności posortuj klientów malejąco po dacie dodania do systemu (`AddedOn`).  

## Przekazywanie definicji przekształceń
Operację z poprzedniego zadania zaimplementuj jako nową metodę w `CustomerRepository`.
Nazwij tę metodę `GetThreeRecentlyAddedCustomersFromWarsaw`.
Wykorzystaj `DbSet<Customer>`.
Wszystkie operacje na danych (filtrowanie, sortowanie, stronicowanie, przekształcenia) powinny być wykonane po stronie bazy danych, a nie w aplikacji.
Zastanów się jak powinna wyglądać sygnatura metody, żeby możliwe było przekazywanie dowolnego warunku do filtrowania, bez zmiany pozostałych wymagań.