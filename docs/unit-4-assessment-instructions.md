# Assessment: Unit 4

Instructions for the Unit 4 assessment.

## On This Page

- [Part 1: SQL](#part-1-sql)
  - [Setup](#sql-setup)
  - [Instructions](#sql-instructions)
- [Part 2: EF Core](#part-2-ef-core)
  - [Setup](#ef-core-setup)
  - [Instructions](#ef-core-instructions)
    - [Models.cs](#modelscs)
    - [Queries.cs](#queriescs)

## Part 1: SQL

In this part, you’ll write queries according to the prompts found in `sql/queries.sql` for a database named `cupcakes`.

### SQL Setup

Create an empty database with:

```sh
createdb cupcakes
```

Load the SQL file with data into the database you just created:

```sh
psql -d cupcakes -f sql/database.sql
```

### SQL Instructions

Before you start writing queries, familiarize yourself with the schema of the `cupcakes` database by connecting to it through the `psql` shell and running the `\dt` and `\d` commands.

Complete the prompts in `sql/queries.sql` to query the `cupcakes` database. For each prompt, we recommend that you write your query in the `psql` shell to test it before copying it into the file.

## Part 2: EF Core

In this part, you’ll use EF Core to create model classes and retrieve data from `animals`, a database that contains information about humans and their pets.

### EF Core Setup

Instead of the Code First approach, where you define model classes in order to create a database, you’ll work the other way around: you’ll define model classes based on an existing database.

Create an empty database with:

```sh
createdb animals
```

Load the SQL file with data into the database you just created:

```sh
psql -d animals -f EFCoreAssess/seed.sql
```

The database has two tables: `humans` and `animals`. An animal belongs to one human, but a human can have many animals.

**DO NOT** use reverse engineering tools to generate model classes based on the existing database. Doing so is a violation of academic integrity and will result in a failing grade.

### EF Core Instructions

There are two parts to this assessment: implementing model classes in `Models.cs` and completing methods in `Queries.cs`.

#### Models.cs

Complete the following tasks in `Models.cs`.

**DO NOT** use reverse engineering tools to generate model classes based on the existing database. Doing so is a violation of academic integrity and will result in a failing grade.

Implement the `Human` and `Animal` classes.

Use data annotations to define properties for each class so that they correspond with the column names and data types that are already present in the `animals` database. You can use the `\d` command in the `psql` shell to get information about the database table and columns, or refer to the schema reference below.

Add navigation properties so `Human.Animals` returns a list of `Animal` objects and `Animal.Human` returns a `Human` object.

Override `ToString` for each class so it returns information helpful for debugging.

`Human.ToString` should return something like `<Human HumanId=5 FirstName=Jane>`.

`Animal.ToString` should return something like `<Animal AnimalId=2 Name=Squiggles Species=snake>`.

#### Schema for the `animals` table

| Column | Type | Nullable | Key info |
| --- | --- | --- | --- |
| `animal_id` | integer | not null | Primary key |
| `name` | varchar(50) | not null | |
| `animal_species` | varchar(25) | not null | |
| `birth_year` | integer | yes | |
| `human_id` | integer | not null | Foreign key, references `humans.human_id` |

#### Schema for the `humans` table

| Column | Type | Nullable | Key info |
| --- | --- | --- | --- |
| `human_id` | integer | not null | Primary key |
| `fname` | varchar(25) | not null | |
| `lname` | varchar(25) | not null | |
| `email` | varchar(100) | not null | |

#### Queries.cs

Complete the following tasks in `Queries.cs`. There are a total of ten methods to complete (eight Query methods and two additional methods).

You can use the code in `Program.cs` to test your methods by hand.

Complete the eight static methods, `Query1`–`Query8`, so they return the correct result. You can view the desired result of each query below.

##### Query 1

```text
<Human HumanId=2 FirstName=Jane>
```

##### Query 2

```text
<Animal AnimalId=5 Name=Bubbles Species=fish>
```

##### Query 3

```text
[<Animal AnimalId=7 Name=Bugs Species=rabbit>,
 <Animal AnimalId=9 Name=Buster Species=dog>,
 <Animal AnimalId=10 Name=Twinkie Species=dog>]
```

##### Query 4

```text
[<Animal AnimalId=2 Name=Squiggles Species=snake>,
 <Animal AnimalId=4 Name=Birdy Species=bird>,
 <Animal AnimalId=7 Name=Bugs Species=rabbit>,
 <Animal AnimalId=11 Name=Fluffster Species=dog>]
```

##### Query 5

```text
[<Human HumanId=2 FirstName=Jane>,
 <Human HumanId=3 FirstName=Jasmine>,
 <Human HumanId=4 FirstName=John>,
 <Human HumanId=5 FirstName=Jane>]
```

##### Query 6

```text
[<Animal AnimalId=5 Name=Bubbles Species=fish>,
 <Animal AnimalId=6 Name=Mr. Hops Species=rabbit>,
 <Animal AnimalId=8 Name=Cuddles Species=cat>]
```

##### Query 7

```text
[<Animal AnimalId=5 Name=Bubbles Species=fish>,
 <Animal AnimalId=6 Name=Mr. Hops Species=rabbit>,
 <Animal AnimalId=7 Name=Bugs Species=rabbit>]
```

##### Query 8

```text
[<Human HumanId=1 FirstName=Bob>,
 <Human HumanId=3 FirstName=Jasmine>]
```

Complete the `PrintHumansAndAnimals` method. It should print a directory of humans and their animals. The output should look like this (order does not matter):

```text
Bob Personne
- Cuddles, cat
- Fluffy, cat
- Twinkles, cat
Jane Doe
- Birdy, bird
- Mr. Hops, rabbit
- Squiggles, snake
Jane Hacks
- Bugs, rabbit
- Buster, dog
- Twinkie, dog
Jasmine Debugger
- Fido, dog
John Doe
- Bubbles, fish
- Fluffster, dog
```

Complete the `GetHumansByAnimalSpecies` method. It should return a list of humans who own animals of a certain species.

Do not include duplicate `Human` objects in the returned list.

The returned list should include these `Human` objects (order does not matter):

```text
[<Human HumanId=4 FirstName=John>,
 <Human HumanId=3 FirstName=Jasmine>,
 <Human HumanId=5 FirstName=Jane>]
```
