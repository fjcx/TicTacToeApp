using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuView : MonoBehaviour {

    // Use this for initialization
    void Start() {
        EventController.Instance.Subscribe<DisplayMainMenuEvent>(OnDisplayMainMenuEvent);
    }

    // Click Handlers
    public void StartNewGame() {
        EventController.Instance.Publish(new StartNewGameEvent());
    }

    public void ContinueGame() {
        EventController.Instance.Publish(new ContinueGameEvent());
    }

    public void QuitGame() {
        EventController.Instance.Publish(new QuitGameEvent());
    }

    // Event Handlers
    public void OnDisplayMainMenuEvent(DisplayMainMenuEvent evt) {
        if (evt.isDisplayed) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
    }
}
