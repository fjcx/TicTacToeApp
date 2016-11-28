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
        Player player1 = null;
        Player player2 = null;

        // Creating new Player types based on drop down selection
        if (evt.player1Type == "Human") {
            player1 = new HumanPlayer(evt.player1Name, CellContent.X);
        } else {
            player1 = new AIPlayerMinimax(evt.player1Name, CellContent.X);
        }

        if (evt.player2Type == "Human") {
            player2 = new HumanPlayer(evt.player2Name, CellContent.O);
        } else {
            player2 = new AIPlayerMinimax(evt.player2Name, CellContent.O);
        }

        // Update BoardModel with new Players
        BoardModel boardModel = tttApp.Model;
        boardModel.player1 = player1;
        boardModel.player2 = player2;
        boardModel.currentPlayer = player1;
        boardModel.p1Total = 0;
        boardModel.p2Total = 0;

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
