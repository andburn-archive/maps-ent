#Repository Pattern

A best practice in MVC to seperate direct communication between controllers and Entity Models.

Used to create an abstraction layer between the data layer and business layer. Benefits include isolating app from changes in the data store and allow easier unit testing.

*I thought that's what the DbContext was for!*

Can be created in a many ways. Most straigtforward is to create a repository interface for all entities and associated concrete repositories. For example, and `IEventRepository` and `EventRepository`. The controller only knows about the interface not any concrete implementations. For production a repository that works with the Entity Framework would be passed so it can communicate with the DB. For testing mock repositories can be created without need to connect to a DB.

-----

**Aside** IQueryable vs IEnumerable (Videos [A][1], [B][2])

IQueryable actually queries the db, and each chaining does so too.
IEnumerable gets all whole db table, and applies filtering in code.

-----


<!--- References --->
[1]: https://www.youtube.com/watch?v=7ssbfLdQGyg
[2]: https://www.youtube.com/watch?v=RYvuaU47h2w