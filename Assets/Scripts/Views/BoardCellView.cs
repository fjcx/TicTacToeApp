using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class BoardCellView : MonoBehaviour {

    private Button cellBtn;
    public int cellIndex;

    public CellContent symbol = CellContent.EMPTY;
    public Text cellText;

    private void Start() {
        cellBtn = transform.GetComponent<Button>();
    }

    // OnClick Handlers
    public void CellClick() {
        EventController.Instance.Publish(new CellClickEvent(cellIndex));
    }

    public void EnableCellClick(bool isEnabled) {
        cellBtn.interactable = isEnabled;
        // TODO: change color of cell ?
    }

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
