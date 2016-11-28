using UnityEngine;
using System.Collections;

public class BoardView : MonoBehaviour {

    public BoardCellView[] boardCells;

    // Use this for initialization
    void Start () {
        // Init boardCell indices
        for (int i = 0; i < boardCells.Length; i++) {
            boardCells[i].cellIndex = i;
        }

        EventController.Instance.Subscribe<DisplayBoardEvent>(OnDisplayBoardEvent);
        EventController.Instance.Subscribe<UpdateBoardCellsEvent>(OnUpdateBoardCells);
        EventController.Instance.Subscribe<EnableBoardClickEvent>(OnEnableBoardClickEvent);
    }

    // Event Handlers - start
    public void OnDisplayBoardEvent(DisplayBoardEvent evt) {
        //EnableBoardActions(evt.isDisplayed);
        // TODO: do something or remove !!!
    }

    public void OnUpdateBoardCells(UpdateBoardCellsEvent evt) {
        UpdateBoardCells(evt.boardModel);
    }

    public void OnEnableBoardClickEvent(EnableBoardClickEvent evt) {
        for (int i = 0; i < boardCells.Length; i++) {
            boardCells[i].EnableCellClick(evt.isEnabled);
        }
    }
    // End - Events

    public void UpdateBoardCells(BoardModel boardModel) {
        for (int i = 0; i < boardCells.Length; i++) {
            boardCells[i].UpdateGridCell(boardModel.cells[i]);
        }
    }

}
