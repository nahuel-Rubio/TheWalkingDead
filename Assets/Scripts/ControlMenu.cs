using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    //instancia de GameManager
    private GameManager gameManager;

    public void OnBotonJugar()
    {
        SceneManager.LoadScene("escena1");
    }

    public void OnBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void OnBotonCreditosVolver()
    {
     
        SceneManager.LoadScene("Menu");
    }

    public void OnBotonSalir()
    {
        Application.Quit();
        Debug.Log("Intentando salir");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
