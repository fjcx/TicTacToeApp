using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectPlayersView : MonoBehaviour {

    public GameObject selectPlayersView;

    public InputField player1Name;
    public InputField player2Name;
    public Dropdown p1DropDown;
    public Dropdown p2DropDown;

    // Use this for initialization
    void Start () {
        EventController.Instance.Subscribe<DisplayPlayerSelectMenuEvent>(OnDisplayPlayerSelectMenuEvent);
    }

    public void ShowSelectPlayers(bool showPanel) {
        Debug.Log("ShowSelectPlayers");
        selectPlayersView.SetActive(showPanel);
        transform.SetAsLastSibling();
    }

    // Event Handlers
    public void OnDisplayPlayerSelectMenuEvent(DisplayPlayerSelectMenuEvent evt) {
        ShowSelectPlayers(evt.isDisplayed);
    }

    // Click Handlers
    public void Confirm() {
        EventController.Instance.Publish(new CreatePlayersEvent(
            player1Name.text, p1DropDown.captionText.text,
            player2Name.text, p2DropDown.captionText.text));
    }

    public void Cancel() {
        // Hide the Player Select menu
        ShowSelectPlayers(false);
    }
}
