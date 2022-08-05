using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceAmmo : MonoBehaviour
{
    private TMP_Text text;  
    private Player player;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
       var (curbull , gunbull ) = player.InterfaceManager.Ammo();
        Convert.ToString(curbull);
        Convert.ToString(gunbull);
        text.text = $"{curbull}/{gunbull}";
    }
}
