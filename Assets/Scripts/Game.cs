using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(GotoLobbyScene());
    }

    IEnumerator GotoLobbyScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("LobbyScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
