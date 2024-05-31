using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEtapa : MonoBehaviour
{

    public GameObject imagenfinal;
    public GameManagerCoin gameManagerCoin;
    //public AudioClip sonidofx;    
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        imagenfinal.gameObject.SetActive(true);
        // GameManagerCoin player = collision.GetComponent<GameManagerCoin>();
        // player.destruirPersonaje();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
