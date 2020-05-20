# Zadania

## Wykorzystanie `Func<>` i przekazywanie `lambda expression` jako argumentu
Zaimplementuj politykę wyceny (`IPricingPolicy`), która pozwala na przekazanie dowolnego warunku decydującego o tym czy rabat ma zostać naliczony.
Warunek musi dać się przekazać jako `lambda expression`.
Klasę implementującą tę politykę nazwij `CustomConditionalPricingPolicy`.
Jej konstruktor musi przyjmować dowolną politykę wyceny oraz warunek.

## Delegaty
Zaimplementuj `IPricingPolicy` jako funkcję wykorzystując słowo kluczowe `delegate`. Nazwij ją `PricingPolicy`.
Zaimplementuj politykę naliczającą stały 10% rabat jako metodę w klasie statycznej `PricingPolicies`. Nazwij ją `TenPercentageDiscount`.
Zaimplementuj `DiscountOver1000Pln` z zadań `01_Types` tym razem jako funkcję zgodną z `PricingPolicy`. Implementację umieść w klasie statycznej `PricingPolicies`.

## Przekazywanie metody jako `delegate`
Dokończ implementację `RecalculateOfferHandler` tak, aby za każdym razem zwrócona została oferta z naliczonym 10% rabatem.
Wykorzystaj implementacje z `PricingPolicies`.