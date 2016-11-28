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
    }

    #region Subscribed event listeners
    // Received StartNewGameEvent. Shows Select players Panel 
    public void OnStartNewGameEvent(StartNewGameEvent evt) {
        EventController.Instance.Publish(new DisplayPlayerSelectMenuEvent(true));
    }

    // Received ContinueGameEvent
    public void OnContinueGameEvent(ContinueGameEvent evt) {
        // TODO: add continue game logic
        //StartGame();
    }

    // Received QuitGameEvent
    public void OnQuitGameEvent(QuitGameEvent evt) {
         Application.Quit();
    }
    #endregion

    // Invokes the MainMenuView to display
    public void ShowMainMenu() {
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }
}
