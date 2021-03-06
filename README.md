# Domain Driven Design Course

*Note* - This repository holds homeworks and projects developed for the DDD class in AUBG.

### Homework 1 Explenataion

##### The purpose of this homework was to create *Value Objects* in **C#**.

The project imitates a Bingo game. In reallity it's just a number guessing game, where the user has a random set of numbers
and has to compare them to another bigger set of random numbers. The player gets `ScoreToken`s when he get's a correct answer
and after 4 correct answers, the player wins!

The *Value Objects* of the project are the classes `BingoNumber` and `ScoreToken`.
These two things represent objects that have a value (and no identity) that is important to us. Thus they are made immutable object following the standard
of writing *VO*'s. Also the implementation *overrides* the `Equals()` method and has `operator ==` and `operator !=` methods.

The *Entity Object* is only the `Player` class. The entity by which we recognize this class is the `name` property.

The application is a **.NET** console app, driven by the `Program` class.

### Team Homework Explenation

##### The purpose of this homework was to create some functionality for our current Flower Business

In the project we implemented the general entities and value objects that are used. We used a abstract `ValueObject` class that is then used by `Items` and `Flowers`. We have an interfaces
that is a makeshift repository for `Employees`. Through that repository we are able to control the Employees and then they can interact with the `Boxes` we have.

The value of the boxes and their status is updated to indicate how they are scanned and their flowers amount has diminished.