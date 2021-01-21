# Roulette Kata
*Created by me*

## Story
Roulette is a casino popular game named after the French word meaning *little wheel*. 
In the game, players may choose to place bets on either a single number, various groupings of numbers, the colors red or black, whether the number is odd or even, etc.
A croupier spins a wheel in one direction, then spins a ball in the opposite direction around a tilted circular track running around the outer edge of the wheel. 
Players that have winning bets get awarded with the amount they bet plus a factor depending on the type of bet they choose.

![Tux, the Linux mascot](/assets/roulette.jpg)

## Description
Create a console application that simulates a Roulette, where you can place different type of bets selecting an amount of money to bet. 
To simplify only one bet at a time can be in game. The player starts with X amount of money in game, and when the amount is 0 loses the game.
When the bet is placed, a random number is going to be generated as a result **from 0 to 36**. If the **colour or number matches the bet, the player is going to have his 
current amount plus the awarded money.** Assume the roulette to be created is a **Single-zero wheel.** <br>

| Colour | Numbers |
|--------|---------|
| Black | 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 |
| Red | 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 |

## Rules
- The application will read line from console with the bet that player wants to play, always following this format:<br>
  `{Number or Colour} {Amount}`
- There are two different types of bets: **ColourBet** and **NumberBet** 
    - **NumberBet:** <br>
      Input example: `5 4.85` <br>
      Award factor: x36
      
    - **Colour Bet:** <br>
      Input example: `red 6.5` <br>
      Award factor: x2
- When amount of money of the player is 0 the game ends.

## Example
```
WELCOME TO ROULETTE SIMULATOR!

Current money: 60.00 euros
What is going to be your next bet? (Red, Black, 6, 17...)
Format -> {number or colour} {amount}
red 5
RESULT OF GAME: Red - 9
-----------------------------------------------------
Current money: 65.00 euros
What is going to be your next bet? (Red, Black, 6, 17...)
Format -> {number or colour} {amount}
5 2.85 
RESULT OF GAME: Green - 0
-----------------------------------------------------
Current money: 62.15 euros
What is going to be your next bet? (Red, Black, 6, 17...)
Format -> {number or colour} {amount}
black 10
```

### Collaboration
I hope you enjoy the kata (this is the first one that I create), please if you have any comment or improvement I would be pleased
to listen to you, don't hesitate to create a pull request with the proposal! ;)