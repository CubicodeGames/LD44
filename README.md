# LD44
Stuff for Ludum Dare 44


Title: Coins for Hearts

Shortname: C4H

Idea:
Player controlls two characters 

Caharacter 1:
  Heart
  Starts with x hearts which are reduced over time.
  Can only collect coins.

Character 2:
  Coin
  Starts with x coins which are reduced over time.
  Can only collect hearts.

Gameplay:
Heart collects coins, coin collects hearts.
In each level two keys are available. Each character has to collect one ( it is possible to collect two with one character but then the level can not be completed).
As soon as each character has one key they can both be moved into a special spot where they can exchange coins for hearts to fill up their energy.

Game is lost when:
1. One character has no energy left
2. A character touches an enemy
3. A character moves to far away from the other (the other is out of the screen)

Game is won when:
All levels are completed.

Scenes:
1. Main
2. Levels
3. Game over
4. Game won
5. How to play
