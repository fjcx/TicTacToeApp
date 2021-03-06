﻿using UnityEngine;
using System.Collections;

// View class for updating game board UI elements
public class BoardView : MonoBehaviour {

    public BoardCellView[] boardCells;      // references to individual cell views

    void Start () {
        // Init cell index for referenced cells
        for (int i = 0; i < boardCells.Length; i++) {
            boardCells[i].cellIndex = i;
        }
        // Subscribing to board view related events
        EventController.Instance.Subscribe<DisplayBoardEvent>(OnDisplayBoardEvent);
        EventController.Instance.Subscribe<UpdateBoardCellsEvent>(OnUpdateBoardCells);
        EventController.Instance.Subscribe<EnableBoardClickEvent>(OnEnableBoardClickEvent);
    }

    #region Subscribed event listeners
    // Received DisplayBoardEvent
    public void OnDisplayBoardEvent(DisplayBoardEvent evt) {
        EventController.Instance.Publish(new DisplayMainMenuEvent(false));
        EventController.Instance.Publish(new DisplayPlayerSelectMenuEvent(false));
        EventController.Instance.Publish(new DisplayStatusPanelEvent(false, ""));
    }

    // Received UpdateBoardCellsEvent
    public void OnUpdateBoardCells(UpdateBoardCellsEvent evt) {
        UpdateBoardCells(evt.boardModel);
    }

    // Received EnableBoardClickEvent
    public void OnEnableBoardClickEvent(EnableBoardClickEvent evt) {
        for (int i = 0; i < boardCells.Length; i++) {
            boardCells[i].EnableCellClick(evt.isEnabled);
        }
    }
    #endregion

    // Update referenced cells with new model data
    public void UpdateBoardCells(BoardModel boardModel) {
        for (int i = 0; i < boardCells.Length; i++) {
            boardCells[i].UpdateGridCell(boardModel.cells[i]);
        }
    }
}
