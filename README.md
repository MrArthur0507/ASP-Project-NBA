# ASP-Project-NBA
The project is about accessing NBA information.
It is divided in 3 layers - Data access layer, service layer and presentation layer. 
The data access layer encapsulates the queries to the database using repositories and ORM(EF Core),
the service layers contains business logic and the presentation layer contains the controllers which are handling the requests and are returning
view models to the views. There is a separate API Service that fetch real data about players, game, stats etc.. in NBA and populates a database.
Functionality:
Users are able to
- Search for players using pages are using a search input field.
- Seeing all the characteristics of players like height and position.
- Seeing the average points, blocks, steals, rebounds, assists for their career
- Getting information about teams with a linear diagram for each team about the average points made in game for the seasons since 1954 and
comparing when they were home and away
- Getting all the players that played in a given team
- Easily searching for games using a form with select options that accepts home team and away team and shows all the games that happened between
both teams, ordered by season
- Getting details about the particular game, showing a diagram with total stats(like points, blocks, assists etc..), and displaying all players
that have available stats for that game.
- Seeing reviews and writing one for each game if the user is logged in
- Get extended information about the players that played in certain game. That includes again the basic stats(points, blocks....), defensive rebounds,
offensive rebounds, fouls, Three points fild goals attempted and made and free throws stats.
Admin role is able to
- Access database views where the it can be updated
- Delete comments
- Delete users
