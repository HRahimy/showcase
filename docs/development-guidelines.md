# Development guidelines and patterns

This project architecture follows the [clean architecture example](https://github.com/jasontaylordev/NorthwindTraders), but the architecture by itself does not explicitly clarify a good set of steps to follow when making different kind of changes at any level of the architecture. These are a set of useful guidelines and patterns to follow when making changes to code at any layer of the project architecture.

## When making changes in domain layer

Before making related changes anywhere else, ensure corresponding configurations are made in the persistence layer and a new migration is generated for the updated entities. All of these changes to the domain and persistence layer should be contained within a single commit and changes to other parts of the architecture MUST NOT be included in that commit.

Usually when you don't do this, you end up having to constantly refactor code when you're making changes in other parts of the architecture that are related to the changes in the entities.
