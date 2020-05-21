# Zadania

## Metody asynchroniczne
Na podstawie implementacji `CrudRepository` zaimplementuj `CrudAsyncRepository` korzystające z `IAsyncDataStore`.

## Czekanie na wykonanie metod asynchronicznych
Zaimplementuj metodę `Handle` w klasie `CalculatePriceHandler`, która wycenia produkty doliczając stałą 20% marżę do ceny dostawcy.
Cenę dostawcy można uzyskać odpytując system dostawcy za pomocą interfejsu `ISupplierService`.
Firma współpracuje z wieloma dostawcami, dlatego `CalculatePriceHandler` ma dostęp do kolekcji `ISupplierService`.
Cenę dostawcy możemy uzyskać na dwa sposoby w zależności od wartości `PriceCalculationPolicy` przekazanej do metody `Handle`:
1. `TakeFirstOffer` - używana jest cena od dostawcy, który najszybciej odpowie na zapytanie
2. `TakeBestOffer` - używana jest najniższa cena, wybierana po otrzymaniu cen od wszystkich dostawców
