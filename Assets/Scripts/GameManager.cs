using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;

    public int vidasGlobal;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        //No lo destruya al cambiar de escena

        DontDestroyOnLoad(gameManager);

        cambiarEscena("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cambiarEscena(string siguienteEscena)
    {
        
            //numVidas = FindObjectOfType<Personaje>().numVidas;
            SceneManager.LoadScene(siguienteEscena);   
        
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void decrementarVidas()
    {
        vidasGlobal--;
    }
    public int getVidas()
    {
        return vidasGlobal;
    }
}