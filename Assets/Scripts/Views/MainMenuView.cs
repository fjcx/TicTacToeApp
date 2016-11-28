using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// View class for main main
public class MainMenuView : MonoBehaviour {

    void Start() {
        // Subscribing to main menu related events
        EventController.Instance.Subscribe<DisplayMainMenuEvent>(OnDisplayMainMenuEvent);
    }

    #region OnClick event handlers
    // Start New Game button clicked
    public void StartNewGame() {
        EventController.Instance.Publish(new StartNewGameEvent());
    }

    // Continue Game button clicked
    public void ContinueGame() {
        EventController.Instance.Publish(new ContinueGameEvent());
    }

    // Quit Game button clicked
    public void QuitGame() {
        EventController.Instance.Publish(new QuitGameEvent());
    }
    #endregion

    #region Subscribed event listeners
    // Show/Hide main menu
    public void OnDisplayMainMenuEvent(DisplayMainMenuEvent evt) {
        if (evt.isDisplayed) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
    }
    #endregion
}
