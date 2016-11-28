using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// View class for updating individual cell UI elements
public class BoardCellView : MonoBehaviour {

    private Button cellBtn;                         // reference to cell button
    public Text cellText;                           // reference to cell Text object
    public int cellIndex;                           // index for tracking click events
    public CellContent symbol = CellContent.EMPTY;  // current assigned cell symbol

    private void Start() {
        cellBtn = transform.GetComponent<Button>();
    }

    #region OnClick event handlers
    // Cell is clicked
    public void CellClick() {
        EventController.Instance.Publish(new CellClickEvent(cellIndex));
    }
    #endregion

    // Enable/Disable cell clicking
    public void EnableCellClick(bool isEnabled) {
        cellBtn.interactable = isEnabled;
    }

    // Update Text based on assigned symbol
    public void UpdateGridCell(CellContent symbol) {
        this.symbol = symbol;
        if (symbol == CellContent.O) {
            cellText.text = "O";
        } else if (symbol == CellContent.X) {
            cellText.text = "X";
        } else {
            cellText.text = "";
        }
    }
}
