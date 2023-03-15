using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string nextScene;
    private GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();

   
        
       // gameManager.numVidas = numVidas; //en caso de que no haya nada guardado el default sera 5
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            gameManager.cambiarEscena(nextScene);
           
            Destroy(gameObject);
        }

    } 
}