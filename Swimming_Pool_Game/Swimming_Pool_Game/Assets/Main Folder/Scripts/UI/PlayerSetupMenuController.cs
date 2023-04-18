using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerSetupMenuController : MonoBehaviour
{
    int playerIndex;

    [SerializeField] TextMeshProUGUI playerTitle;
    [SerializeField] GameObject ReadyPanel;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] Button ReadyButton;
    

    float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    public void SetPlayerIndex(int pi)
    {
        playerIndex = pi;
        playerTitle.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime += Time.time;
    }

    private void Update()
    {
        if (Time.time > ignoreInputTime) inputEnabled = true;
    }

    public void SetColor (Material color)
    {
        if (!inputEnabled) return;
        PlayerConfigManager.Instance.SetPlayerColour(playerIndex, color);
        ReadyPanel.SetActive(true);
        ReadyButton.Select();
        MenuPanel.SetActive(false);
    }

    public void DisableSpecButtons(List<string> names)
    {
        if (names.Count == 0) return;
        foreach (var name in names)
        {
            DisableButton(name);
        }
    }

    public void SetColor (string name)
    {
        gameObject.SendMessageUpwards("ChosenColor", name);
    }

    public void DisableButton(string buttonName)
    {
        Button[] chosenBType = gameObject.GetComponentsInChildren<Button>();
        foreach (Button b in chosenBType)
        {
            if (b.gameObject.name.Equals(buttonName))
            {
                //Debug.Log($"FOUND {buttonName}");
                b.interactable = false;
            }
        }
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) return;
        PlayerConfigManager.Instance.isReadyToPlay(playerIndex);
        ReadyButton.gameObject.SetActive(false);
    }
}
