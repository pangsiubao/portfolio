# portfolio

https://pangsiubao.github.io/portfolio/

## Over de backend

| Onderdeel              | Keuze                                                           |
| ---------------------- | --------------------------------------------------------------- |
| .NET-versie            | **.NET 10**                                                     |
| API-stijl              | **Controllers** (`ProjectsController` en `BlogpostsController`) |
| Codestructuur          | **Lagen**: Controllers, Services en Data                        |
| Database               | **SQL Server LocalDB** via Entity Framework Core 10             |
| Database aanmaken      | **EF Core-migraties** (niet `EnsureCreated`)                    |
| Documentatie en testen | **Swagger UI** via Swashbuckle.AspNetCore                       |

### Codestructuur

Alle code staat in `backend/PortfolioApi`:

| Map            | Wat doet het?                                                                                           |
| -------------- | ------------------------------------------------------------------------------------------------------- |
| `Controllers/` | Ontvangt de HTTP-verzoeken en geeft de juiste statuscode terug (200, 201, 204, 400, 404).               |
| `Services/`    | De applicatielogica: data ophalen, opslaan, wijzigen en verwijderen, en entiteiten omzetten naar DTO's. |
| `Data/`        | `PortfolioDbContext`: de verbinding met de database via EF Core, inclusief de startdata.                |
| `Models/`      | De EF Core-entiteiten `Project` en `Blogpost`. Deze worden alleen voor de database gebruikt.            |
| `Dtos/`        | Wat de API ontvangt en terugstuurt. Geen enkel endpoint ontvangt of verstuurt een entiteit.             |
| `Migrations/`  | De EF Core-migraties waarmee de database wordt aangemaakt en bijgewerkt.                                |

De DbContext en de services worden via dependency injection geregistreerd in `Program.cs` en via de constructor doorgegeven aan de services en controllers.

## De applicatie starten

### SQL Server configureren

De verbinding met de database staat in `backend/PortfolioApi/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PortfolioDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Met LocalDB hoef je hier niets aan te veranderen. Gebruik je een andere SQL Server, pas dan deze regel aan.

### 1. Naar de juiste map gaan

Open een terminal (in Visual Studio Code: menu **Terminal → New Terminal**) en ga naar de map van de API:

```
cd backend/PortfolioApi
```

### 2. De database aanmaken (alleen de eerste keer)

```
dotnet tool install --global dotnet-ef
dotnet ef database update
```

Dit maakt de database **PortfolioDb** aan met de tabellen `Projects` en `Blogposts`, en vult die met startdata (5 projecten en 6 blogposts).

### 3. De applicatie starten

```
dotnet run
```

Wacht tot je `Now listening on: http://localhost:5133` ziet. Laat de terminal open: de API draait zolang dit venster openstaat. Stoppen doe je met **Ctrl+C**.

## De API uitproberen met Swagger

Swagger is een pagina in je browser waarmee je de projecten en blogposts kunt opvragen en aanpassen zonder te programmeren. Je klikt gewoon op knoppen.

### Swagger openen

Ga in je browser naar:

http://localhost:5133/swagger

Je ziet nu twee groepen: **Blogposts** en **Projects**.

### Gegevens opvragen

Voorbeeld: alle projecten bekijken.

1. Klik op **GET /api/Projects**.
2. Klik rechts op **Try it out**.
3. Klik op de blauwe knop **Execute**.
4. Scroll naar beneden. Onder **Response body** staan nu alle projecten.

Voor één specifiek project:

1. Klik op **GET /api/Projects/{id}** en dan op **Try it out**.
2. Vul bij **id** een nummer in, bijvoorbeeld `1`.
3. Klik op **Execute**.

Voor de blogposts werkt het precies hetzelfde via **/api/Blogposts**.

### Gegevens toevoegen, aanpassen of verwijderen

- **Toevoegen (POST):** klik op **POST**, dan **Try it out**, vul de velden in en klik op **Execute**. Een datum schrijf je als `2026-11-01` (jaar-maand-dag). Het id vul je niet in, dat kiest de database zelf.
- **Aanpassen (PUT):** vul bij **id** het nummer in van wat je wilt wijzigen en pas de gegevens eronder aan.
- **Verwijderen (DELETE):** vul het id in en klik op **Execute**. Dit kan niet ongedaan worden gemaakt.

Alle wijzigingen worden opgeslagen in SQL Server. Ze blijven dus bestaan als je de applicatie opnieuw start.

### Overzicht van de endpoints

| Methode | Route                 | Wat doet het?             |
| ------- | --------------------- | ------------------------- |
| GET     | `/api/Projects`       | Alle projecten opvragen   |
| GET     | `/api/Projects/{id}`  | Eén project opvragen      |
| POST    | `/api/Projects`       | Nieuw project toevoegen   |
| PUT     | `/api/Projects/{id}`  | Project aanpassen         |
| DELETE  | `/api/Projects/{id}`  | Project verwijderen       |
| GET     | `/api/Blogposts`      | Alle blogposts opvragen   |
| GET     | `/api/Blogposts/{id}` | Eén blogpost opvragen     |
| POST    | `/api/Blogposts`      | Nieuwe blogpost toevoegen |
| PUT     | `/api/Blogposts/{id}` | Blogpost aanpassen        |
| DELETE  | `/api/Blogposts/{id}` | Blogpost verwijderen      |
