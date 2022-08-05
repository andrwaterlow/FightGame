using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceItems : MonoBehaviour
{
    private Player player;
    private TMP_Text Text;

    private void Awake()
    {
        Text = GetComponent<TMP_Text>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        var money = player.InterfaceManager.Money();
        var items = player.InterfaceManager.Items();
        Text.text = $"Your money: {money} \n In All Items: {items}";
    }
}
