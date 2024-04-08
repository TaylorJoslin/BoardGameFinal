using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowPanel : MonoBehaviour
{
    [SerializeField] GameObject humanPanel;
    [SerializeField] Button rolldiceButton;
    [SerializeField] Button endturnButton;

    private void OnEnable()
    {
        GameManager.OnShowHumanPanel += ShowPanel;
        TileNode.OnShowHumanPanel += ShowPanel;
    }

    void OnDisable()
    {
        GameManager.OnShowHumanPanel -= ShowPanel;
        TileNode.OnShowHumanPanel -= ShowPanel;
    }

    void ShowPanel(bool showPanel, bool enableRollDice, bool enableEndTurn)
    {
        humanPanel.SetActive(showPanel);
        rolldiceButton.interactable = enableRollDice;
        endturnButton.interactable = enableEndTurn;

    }
}
