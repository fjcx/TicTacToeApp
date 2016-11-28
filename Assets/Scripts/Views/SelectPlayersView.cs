using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// View class for main main
public class SelectPlayersView : MonoBehaviour {

    public InputField player1Name;
    public InputField player2Name;
    public Dropdown p1DropDown;
    public Dropdown p2DropDown;

    // Use this for initialization
    void Start () {
        // Subscribing to player select related events
        EventController.Instance.Subscribe<DisplayPlayerSelectMenuEvent>(OnDisplayPlayerSelectMenuEvent);
    }

    #region Subscribed event listeners
    // Received DisplayPlayerSelectMenuEvent
    public void OnDisplayPlayerSelectMenuEvent(DisplayPlayerSelectMenuEvent evt) {
        ShowSelectPlayers(evt.isDisplayed);
    }
    #endregion

    #region OnClick event listeners
    // confirm button clicked
    public void Confirm() {
        EventController.Instance.Publish(new CreatePlayersEvent(
            player1Name.text, p1DropDown.captionText.text,
            player2Name.text, p2DropDown.captionText.text));
    }

    // Cancel button clicked
    public void Cancel() {
        ShowSelectPlayers(false);
    }
    #endregion

    // Show/Hide select players panel
    public void ShowSelectPlayers(bool showPanel) {
        if (showPanel) {
            transform.SetAsLastSibling();
        } else {
            transform.SetAsFirstSibling();
        }
    }
}
