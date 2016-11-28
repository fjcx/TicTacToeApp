using UnityEngine;
using System.Collections;
using System;

public class GameEvent {
}

// Board View Events
public class DisplayBoardEvent : GameEvent {
    public bool isDisplayed { get; private set; }

    public DisplayBoardEvent(bool isDisplayed) {
        this.isDisplayed = isDisplayed;
    }
}

public class UpdateBoardCellsEvent : GameEvent {
    public BoardModel boardModel { get; private set; }

    public UpdateBoardCellsEvent(BoardModel boardModel) {
        this.boardModel = boardModel;
    }
}

public class EnableBoardClickEvent : GameEvent {
    public bool isEnabled { get; private set; }

    public EnableBoardClickEvent(bool isEnabled) {
        this.isEnabled = isEnabled;
    }
}

// Cell View Events
public class CellClickEvent : GameEvent {
    public int cellIndex { get; private set; }

    public CellClickEvent(int cellIndex) {
        this.cellIndex = cellIndex;
    }
}

// Board Model Events
/*public class UpdateBoardModelEvent : GameEvent {
    public BoardModel boardModel { get; private set; }

    public UpdateBoardModelEvent(BoardModel boardModel) {
        this.boardModel = boardModel;
    }
}*/

public class ResetBoardEvent : GameEvent {
    public ResetBoardEvent() {
    }
}

// Update Total Score
public class UpdateTotalScoreEvent : GameEvent {
    public BoardModel boardModel { get; private set; }

    public UpdateTotalScoreEvent(BoardModel boardModel) {
        this.boardModel = boardModel;
    }
}

public class DisplayTotalScoreEvent : GameEvent {
    public bool isDisplayed { get; private set; }

    public DisplayTotalScoreEvent(bool isDisplayed) {
        this.isDisplayed = isDisplayed;
    }
}

// Update Current Turn
public class UpdateCurrentTurnEvent : GameEvent {
    public Player currentPlayer { get; private set; }
    public string currentAction { get; private set; }

    public UpdateCurrentTurnEvent(Player currentPlayer, string currentAction) {
        this.currentPlayer = currentPlayer;
        this.currentAction = currentAction;
    }
}

// Update Status Panel
public class DisplayStatusPanelEvent : GameEvent {
    public bool isDisplayed { get; private set; }
    public string statusText { get; private set; }

    public DisplayStatusPanelEvent(bool isDisplayed, string statusText) {
        this.isDisplayed = isDisplayed;
        this.statusText = statusText;
    }
}

public class DoNextMoveEvent : GameEvent {
    public int move { get; private set; }
    public float fakeWait { get; private set; }

    public DoNextMoveEvent(int move, float fakeWait) {
        this.move = move;
        this.fakeWait = fakeWait;
    }
}

// Main Menu Events
public class DisplayMainMenuEvent : GameEvent {
    public bool isDisplayed { get; private set; }

    public DisplayMainMenuEvent(bool isDisplayed) {
        this.isDisplayed = isDisplayed;
    }
}

public class StartNewGameEvent : GameEvent {
    public StartNewGameEvent() {
    }
}

public class ContinueGameEvent : GameEvent {
    public ContinueGameEvent() {
    }
}

public class QuitGameEvent : GameEvent {
    public QuitGameEvent() {
    }
}

// Player Select Menu Events
public class DisplayPlayerSelectMenuEvent : GameEvent {
    public bool isDisplayed { get; private set; }

    public DisplayPlayerSelectMenuEvent(bool isDisplayed) {
        this.isDisplayed = isDisplayed;
    }
}

public class CreatePlayersEvent : GameEvent {
    public string player1Name { get; private set; }
    public string player1Type { get; private set; }
    public string player2Name { get; private set; }
    public string player2Type { get; private set; }

    public CreatePlayersEvent(string player1Name, string player1Type, string player2Name, string player2Type) {
        this.player1Name = player1Name;
        this.player1Type = player1Type;
        this.player2Name = player2Name;
        this.player2Type = player2Type;
    }
}

