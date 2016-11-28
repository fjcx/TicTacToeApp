using UnityEngine;
using System.Collections;

// Controller class containing menu related logic
public class MenuController : MonoBehaviour {

    private TTTApplication tttApp;

    void Start () {
        tttApp = (TTTApplication)GameObject.FindObjectOfType(typeof(TTTApplication));
        // Subscribing to Menu Menu Events
        EventController.Instance.Subscribe<StartNewGameEvent>(OnStartNewGameEvent);
        EventController.Instance.Subscribe<ContinueGameEvent>(OnContinueGameEvent);
        EventController.Instance.Subscribe<QuitGameEvent>(OnQuitGameEvent);
        // Subscribing to Player Select Events
        EventController.Instance.Subscribe<CreatePlayersEvent>(OnCreatePlayersEvent);
    }

    #region Subscribed event listeners
    // Received StartNewGameEvent. Shows Select players Panel 
    public void OnStartNewGameEvent(StartNewGameEvent evt) {
        EventController.Instance.Publish(new DisplayPlayerSelectMenuEvent(true));
    }

    // Received ContinueGameEvent
    public void OnContinueGameEvent(ContinueGameEvent evt) {
        // TODO: add continue game logic
        StartGame();
    }

    // Received QuitGameEvent
    public void OnQuitGameEvent(QuitGameEvent evt) {
         Application.Quit();
    }

    // Received CreatePlayersEvent
    public void OnCreatePlayersEvent(CreatePlayersEvent evt) {
        PlayerModel player1 = new PlayerModel();
        PlayerModel player2 = new PlayerModel();

        player1.score = 0;
        player1.playerSymbol = CellContent.X;
        player1.playerName = evt.player1Name;

        player2.score = 0;
        player2.playerSymbol = CellContent.O;
        player2.playerName = evt.player2Name;

        // Creating new Player types based on drop down selection
        if (evt.player1Type == "Human") {
            player1.playerType = PlayerType.HUMAN;
        } else {
            player1.playerType = PlayerType.AIMINIMAX;
        }

        if (evt.player2Type == "Human") {
            player2.playerType = PlayerType.HUMAN;
        } else {
            player2.playerType = PlayerType.AIMINIMAX;
        }

        // Update BoardModel with new Players
        BoardModel boardModel = tttApp.Model;
        boardModel.players[0] = player1;
        boardModel.players[1] = player2;
        boardModel.currentPlayerIndex = 0;

        StartGame();
    }
    #endregion

    // Starts Game by hiding menus and resetting the game board
    private void StartGame() {
        EventController.Instance.Publish(new DisplayMainMenuEvent(false));
        EventController.Instance.Publish(new DisplayPlayerSelectMenuEvent(false));
        EventController.Instance.Publish(new DisplayStatusPanelEvent(false, ""));
        EventController.Instance.Publish(new ResetBoardEvent());
    }

    // Invokes the MainMenuView to display
    public void ShowMainMenu() {
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }
}
