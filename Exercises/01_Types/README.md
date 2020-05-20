# Zadania

## Polimorfizm
Zaimplementuj dwie nowe polityki wyceny (`IPricingPolicy`).

#### Implementacja interfejsu
Rabat kwotowy w dowolnej wysokości naliczany w walucie aktualnej ceny.
Wartość rabatu przekaż jako argument konstruktora typu `decimal`.
Klasę implementującą tę politykę nazwij `ValueDiscount`.

#### Dziedziczenie
Rabat w wysokości 1 EUR naliczany gdy aktualna cena jest mniejsza niż 50 EUR.
Konstruktor tej polityki nie powinien przyjmować żadnych parametrów. 
Klasę implementującą tę politykę nazwij `DiscountUpTo50Eur`.
Jak zmieniłaby się implementacja gdyby cena po rabacie nie mogła spaść poniżej 0.01 EUR?

## Operacje na strukturach
Znajdź błąd w implementacji `Offer`, który powoduje, że `TotalPrice` jest źle wyliczana. 
Zaproponuj w jaki sposób można poprawić implementację.

## Operatory
Zaimplementuj operator dodawania w strukturze `Money`.

## Operacja na stringach
Zaimplementuj metodę `ToString` w klasie `Offer`, która zwróci tekst opisujący zawartość oferty.
Każdy wiersz powinien być zgodny z szablonem: `{id produktu}: {cena}`, a tekst powinien się kończyć znakiem nowej linii.
np.
BA9E7350-4507-43E2-9B86-1B88269FF93B: 12.34 PLN
6DC8F9E0-C2D8-4696-8707-5423DDF1D79A: 179.00 USD
