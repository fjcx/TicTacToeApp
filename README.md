# TicTacToeApp

Simple Game of Tic Tac Toe

Code Structure:
---
TTTApplication -> app entry point, model store
* Models
 * BoardModel -> contains current board and player status
* Controllers
 * BoardController -> controller containing logic for game board
 * MenuController -> controller containing logic for menus
 * PlayerController -> controller containing logic for player moves
 * EventController -> type safe eventing framework
* Views
 * MainMenuView -> view of main menu screen
 * SelectPlayersView -> view of player select screen
 * BoardView -> view of game board
 * BoardCellView -> view of individual game cell
 * CurrentTurnPanelView -> view of panel containing info about current turn
 * StatusPanelView -> view of panel containing win/draw status
 * TotalScorePanelView -> view of panel containing info about cumlative wins for each player
* Utils
 * Event -> defined custom events
 * WinConidtions -> util class to check win/draw coniditions
 * MinimaxAlgo -> util class to get best move via minimax algorithm
