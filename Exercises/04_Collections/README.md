# Zadania

## Operacje na zbiorach
Komponent `AuthorizationManager` sprawdza uprawnienia użytkowników i przyznaje dostęp tylko jeżeli użytkownik ma wszystkie wskazane uprawnienia.
Znajdź błąd w implementacji `AuthorizationManager`, lub `Permission` który powoduje, że uprawnienia nie są sprawdzane poprawnie. 
Zaproponuj w jaki sposób można poprawić implementację.

## ReadOnly
Popraw implementację `Offer` tak żeby właściwość `Items` była faktycznie tylko do odczytu.

## Implementacja IEnumerable
Zastąp właściwość `Items` klasy `Offer` implementacją interfejsu `IEnumerable<(ProductId ProductId, Money Price)>`.
Zmień wszystkie miejsca wykorzystujące właściwość 'Items' tak, aby kod działał bez zmian.

## yield return
W klasie `Fibonacci` zaimplementuj metodę zwracającą pierwszych n wyrazów ciągu Fibonacciego.
Nie powołuj żadnej kolekcji.
Za pierwsze dwa wyrazy ciągu Fibonacciego przyjmij 0 i 1;

## Lazy evaluation
Klasa `DownloadManager` pozwala pobrać pliki maksymalnie 5 razy. Przy kolejnym pobraniu powinien zostać rzucony `DomainException`.
Test wykrył jednak, że tak się nie dzieje. Znajdź przyczynę i określ czy błąd jest w implementacji czy w teście.