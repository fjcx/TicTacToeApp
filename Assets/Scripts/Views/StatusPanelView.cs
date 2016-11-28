using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusPanelView : MonoBehaviour {

    public GameObject statusPanel;
    public Text statusPanelText;

    private void Start() {
        EventController.Instance.Subscribe<DisplayStatusPanelEvent>(OnDisplayStatusPanelEvent);
    }

    public void OnDisplayStatusPanelEvent(DisplayStatusPanelEvent evt) {
        statusPanelText.text = evt.statusText;
        ShowStatusPanel(evt.isDisplayed);
    }

    public void StartRematch() {
        ShowStatusPanel(false);
        EventController.Instance.Publish(new ResetBoardEvent());
    }

    private void ShowStatusPanel(bool isDisplayed) {
        if (isDisplayed) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
        // Also show total score panel above status panel !
        EventController.Instance.Publish(new DisplayTotalScoreEvent(true));
    }

    public void Resign() {
        ShowStatusPanel(false);
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }
}
