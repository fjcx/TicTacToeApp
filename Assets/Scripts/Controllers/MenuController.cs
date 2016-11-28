using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    private TTTApplication tttApplication;

    // Use this for initialization
    void Start () {
        // Perhaps use different reference !!!
        tttApplication = (TTTApplication)GameObject.FindObjectOfType(typeof(TTTApplication));

        // Menu Menu Events
        EventController.Instance.Subscribe<StartNewGameEvent>(OnStartNewGameEvent);
        EventController.Instance.Subscribe<ContinueGameEvent>(OnContinueGameEvent);
        EventController.Instance.Subscribe<QuitGameEvent>(OnQuitGameEvent);
        // Player Select Events
        EventController.Instance.Subscribe<CreatePlayersEvent>(OnCreatePlayersEvent);
    }

    public void ShowMainMenu() {
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }

    // Event Handlers
    public void OnStartNewGameEvent(StartNewGameEvent evt) {
        // Start New Game logic

        // Show Select players Panel
        EventController.Instance.Publish(new DisplayPlayerSelectMenuEvent(true));
    }

    public void OnContinueGameEvent(ContinueGameEvent evt) {
        // Continue game logic
        StartGame();
    }

    public void OnQuitGameEvent(QuitGameEvent evt) {
        // Quit Game logic
        Debug.Log("Quitting");
        Application.Quit();         // TODO: perhaps call to TTTapplication to quit !!
    }

    public void OnCreatePlayersEvent(CreatePlayersEvent evt) {
        Player player1 = null;
        Player player2 = null;

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
        BoardModel boardModel = tttApplication.Model;
        boardModel.player1 = player1;
        boardModel.player2 = player2;
        boardModel.currentPlayer = player1;
        boardModel.p1Total = 0;
        boardModel.p2Total = 0;
        // TODO: consider using UpdateBoardModel Event !!!

        // Continue game logic
        StartGame();
    }

    private void StartGame() {
        // Hide Menus & Show Board with stored players
        EventController.Instance.Publish(new DisplayMainMenuEvent(false));
        EventController.Instance.Publish(new DisplayPlayerSelectMenuEvent(false));
        EventController.Instance.Publish(new DisplayStatusPanelEvent(false, ""));
        EventController.Instance.Publish(new ResetBoardEvent());
    }
}
