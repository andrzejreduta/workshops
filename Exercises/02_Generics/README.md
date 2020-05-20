# Zadania

## Implementacja typu Result
Zaimplementuj typ `Result` przechowujący informację o powodzeniu bądź niepowodzeniu operacji.
W przypadku powodzenia powinien on przechowywać rezultat. W przypadku błędu powinien on przechowywać prostą informację o błędzie w formacie `string`. 
Rezultat może być dowolnego typu, ale każda instancja `Result` musi przechowywać konkretny typ, żeby komponenty korzystające z obiektu `Result` nie musiały wykonywać jakichkolwiek rzutowań. 

## Generyczne repozytorium
Zaimplementuj repozytorium dla dowolnego typu dziedziczącego po `Entity`. Klasę nazwij `CrudRepository`.
Repozytorium nie może obsługiwać typów nie dziedziczących po `Entity` i powinno być to zapewnione na poziomie kompilacji.
Każda instancja repozytorium musi obsługiwać tylko jeden, określony typ dziedziczący po `Entity`. Komponenty korzystające z tego repozytorium nie powinny musieć wykonywać jakiegokolwiek rzutowania.
Repozytorium ma obsługiwać jedynie operacje CRUD:
1. Create: Entity => void
2. Read: Guid => Entity
3. Update: Entity => void
4. Delete: Guid => void
Operacja Delete musi być zaimplementowana jako "soft delete" przy wykorzystaniu flagi `IsDeleted` z klasy bazowej `Entity`.
Jako bazę danych wykorzystaj interfejs `IDataStore`. Przekaż go jako jedyny argument w konstruktorze.
