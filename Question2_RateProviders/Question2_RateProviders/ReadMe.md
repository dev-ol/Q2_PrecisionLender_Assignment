# The Provider Rate System

The system consist of 3 layers which are represented by the classes listed below and in the project itself. 
Layers :
  - API Layer : The front facing layer that manages the requests, responses and the security of the system.
  - Service Layer : Which is use to communicate to the database and the different providers to get their rates.
  - Database Layer : The database layer consist of a SQL database that stores the different providers and a NoSql database that is use for caching.

## Classes 
- ProvidersController ( API layer implementation.)
- DTOs: 
    - NewProviderDto (Data transfer object to store new Provider data from user of the system.)
    - ProvidersDto (Data transfer object to send Provider's data tp user of the system. The rates are included.)
- Entities
    - Provider (Represents a single table in the database)
    - ProviderDbContext (represents the SQL database)
- Services
    - IProviderServices ( Service layer implementation.)
    - ProviderServices ( Service layer implementation.)
- Model
    - CacheProviders (NoSql caching representation)


<b>More information on each classes is written in the file itself.</b>