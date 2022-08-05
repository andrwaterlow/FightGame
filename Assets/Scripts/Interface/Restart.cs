using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Transform _respawnPlace;
    private Player _player;
    private Animate _animate;
   
    private void Awake()
    {
        gameObject.SetActive(false);
        _player = FindObjectOfType<Player>();
        _animate = FindObjectOfType<Animate>();
    }

    public void GoRestart()
    {
        _player.gameObject.transform.position = _respawnPlace.position;
        _player.gameObject.transform.rotation = _respawnPlace.rotation;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(StartAnimator()); 
    }

    private IEnumerator StartAnimator()
    {
        float waitingTime = 0.1f;
        yield return new WaitForSeconds(waitingTime);
        _player._curePlayer.HealPlayer();
        _player.MakeDamage(0);
        gameObject.SetActive(false);
        _animate.ActiveAnimator();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
