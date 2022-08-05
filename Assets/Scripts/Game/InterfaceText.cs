using UnityEngine;
using UnityEngine.UI;

public class InterfaceText : MonoBehaviour
{
    [SerializeField]private Game _game;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = _game.GetTime();
    }
}
