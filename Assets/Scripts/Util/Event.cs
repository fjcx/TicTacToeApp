using UnityEngine;
using System.Collections;
using System;

// Base type safe event
public class GameEvent {
}

#region Game board events
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

public class ResetBoardEvent : GameEvent {
    public ResetBoardEvent() {
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
#endregion

#region Cell view events
public class CellClickEvent : GameEvent {
    public int cellIndex { get; private set; }

    public CellClickEvent(int cellIndex) {
        this.cellIndex = cellIndex;
    }
}
#endregion

#region Total score view events
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
#endregion

#region Current turn view events
public class UpdateCurrentTurnEvent : GameEvent {
    public PlayerModel currentPlayer { get; private set; }
    public string currentAction { get; private set; }

    public UpdateCurrentTurnEvent(PlayerModel currentPlayer, string currentAction) {
        this.currentPlayer = currentPlayer;
        this.currentAction = currentAction;
    }
}
#endregion

#region Status panel view events
public class DisplayStatusPanelEvent : GameEvent {
    public bool isDisplayed { get; private set; }
    public string statusText { get; private set; }

    public DisplayStatusPanelEvent(bool isDisplayed, string statusText) {
        this.isDisplayed = isDisplayed;
        this.statusText = statusText;
    }
}
#endregion

#region Menu events
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
#endregion

#region Player select events
public class DisplayPlayerSelectMenuEvent : GameEvent {
    public bool isDisplayed { get; private set; }

    public DisplayPlayerSelectMenuEvent(bool isDisplayed) {
        this.isDisplayed = isDisplayed;
    }
}
#endregion

#region Player related events
public class ChooseNextMoveEvent : GameEvent {
    public PlayerModel currentPlayer { get; private set; }

    public ChooseNextMoveEvent(PlayerModel currentPlayer) {
        this.currentPlayer = currentPlayer;
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
#endregion

