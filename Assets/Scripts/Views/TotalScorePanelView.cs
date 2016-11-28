using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TotalScorePanelView : MonoBehaviour {

    public Text p1Name;
    public Text p2Name;
    public Text p1TotalText;
    public Text p2TotalText;

    void Start () {
        EventController.Instance.Subscribe<UpdateTotalScoreEvent>(OnUpdateTotalScoreEvent);
        EventController.Instance.Subscribe<DisplayTotalScoreEvent>(OnDisplayTotalScoreEvent);
    }

    // Event Handlers
    public void OnUpdateTotalScoreEvent(UpdateTotalScoreEvent evt) {
        p1Name.text = evt.boardModel.player1.playerName;
        p2Name.text = evt.boardModel.player2.playerName;
        p1TotalText.text = "" + evt.boardModel.p1Total;
        p2TotalText.text = "" + evt.boardModel.p2Total;
    }

    public void OnDisplayTotalScoreEvent(DisplayTotalScoreEvent evt) {
        if (evt.isDisplayed) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
    }
}
