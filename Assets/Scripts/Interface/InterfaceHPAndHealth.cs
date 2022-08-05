using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceHPAndHealth : MonoBehaviour
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
        var HP = player.InterfaceManager.HP();
        var Armour = player.InterfaceManager.Armour();
        Text.text = $" HP {HP}\n Armour {Armour}";
    }
}
