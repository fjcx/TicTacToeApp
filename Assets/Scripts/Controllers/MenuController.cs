using UnityEngine;
using System.Collections;

// Controller class containing menu related logic
public class MenuController : MonoBehaviour {

    void Start () {
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
        // Start game with players taken from boardModel (i.e. not new players)
        EventController.Instance.Publish(new DisplayBoardEvent(true));
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
