using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// View class for updating current turn panel UI elements
public class CurrentTurnPanelView : MonoBehaviour {

    public Text currentPlayerText;      // Reference to Current Player Text object
    public Text currentAction;          // Reference to Current Action Text object

    void Start () {
        // Subscribing to current turn panel related events
        EventController.Instance.Subscribe<UpdateCurrentTurnEvent>(OnUpdateCurrentTurnEvent);
    }

    // Update current turn panel UI elements 
    public void OnUpdateCurrentTurnEvent(UpdateCurrentTurnEvent evt) {
        currentPlayerText.text = "" + evt.currentPlayer.playerName + "(" + evt.currentPlayer.playerSymbol.ToString() + ") :";
        currentAction.text = "" + evt.currentAction;
    }
}
