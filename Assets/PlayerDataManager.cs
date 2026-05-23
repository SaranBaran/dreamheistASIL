using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public TextMeshProUGUI text_playerName;
    public TextMeshProUGUI text_playerDescription;
    public TextMeshProUGUI text_Currency;
    public TextMeshProUGUI text_timeToRob;
    public PlayerHouse playerInfo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void updateCanvas()
    {
        text_playerName.text = "Name: " + playerInfo.playerName;
        text_playerDescription.text = "'" + playerInfo.playerPhrase + "'";
        text_Currency.text = "Value: " + playerInfo.currency.ToString() + "$";
        text_timeToRob.text = "Est. Time to Rob: " + playerInfo.timeToRob.ToString() + " min";

    }
}
