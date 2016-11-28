using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// View class for status panel
public class StatusPanelView : MonoBehaviour {

    public GameObject statusPanel;
    public Text statusPanelText;

    private void Start() {
        // Subscribing to status panel related events
        EventController.Instance.Subscribe<DisplayStatusPanelEvent>(OnDisplayStatusPanelEvent);
    }

    #region Subscribed event listeners
    // Received DisplayStatusPanelEvent
    public void OnDisplayStatusPanelEvent(DisplayStatusPanelEvent evt) {
        statusPanelText.text = evt.statusText;
        ShowStatusPanel(evt.isDisplayed);
    }
    #endregion

    #region OnClick event listeners
    // Rematch button clicked.
    public void StartRematch() {
        ShowStatusPanel(false);
        EventController.Instance.Publish(new ResetBoardEvent());
    }

    // Quit button clicked. Quit to main menu
    public void Resign() {
        ShowStatusPanel(false);
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }
    #endregion

    // Show/Hide status panel
    private void ShowStatusPanel(bool isDisplayed) {
        if (isDisplayed) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
        // Also show total score panel above status panel
        EventController.Instance.Publish(new DisplayTotalScoreEvent(true));
    }
}
