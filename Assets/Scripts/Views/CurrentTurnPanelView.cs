using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentTurnPanelView : MonoBehaviour {

    public Text currentPlayerText;
    public Text currentAction;

    // Use this for initialization
    void Start () {
        EventController.Instance.Subscribe<UpdateCurrentTurnEvent>(OnUpdateCurrentTurnEvent);
    }

    public void OnUpdateCurrentTurnEvent(UpdateCurrentTurnEvent evt) {
        currentPlayerText.text = "" + evt.currentPlayer.playerName + "(" + evt.currentPlayer.playerSymbol.ToString() + ") :";
        currentAction.text = "" + evt.currentAction;
    }
}
