using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// View class for total score panel
public class TotalScorePanelView : MonoBehaviour {

    public Text p1Name;
    public Text p2Name;
    public Text p1TotalText;
    public Text p2TotalText;

    void Start () {
        // Subscribing to total score panel related events
        EventController.Instance.Subscribe<UpdateTotalScoreEvent>(OnUpdateTotalScoreEvent);
        EventController.Instance.Subscribe<DisplayTotalScoreEvent>(OnDisplayTotalScoreEvent);
    }

    #region Subscribed event listeners
    // Received UpdateTotalScoreEvent. Update total score panel UI elements
    public void OnUpdateTotalScoreEvent(UpdateTotalScoreEvent evt) {
        p1Name.text = evt.boardModel.players[0].playerName;
        p2Name.text = evt.boardModel.players[1].playerName;
        p1TotalText.text = "" + evt.boardModel.players[0].score;
        p2TotalText.text = "" + evt.boardModel.players[1].score;
    }

    // Received DisplayTotalScoreEvent. Show/Hide total score panel
    public void OnDisplayTotalScoreEvent(DisplayTotalScoreEvent evt) {
        if (evt.isDisplayed) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
    }
    #endregion
}
