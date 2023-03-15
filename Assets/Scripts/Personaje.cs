using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    //Movimiento del jugador
    [Range(1, 10)] public float velocidad;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    //Para utilizar el Animator del jugador
    private Animator animator;

    
    //Salto del jugador
    bool isJumping = false; //Para saber si está saltando y de esta forma evitar otro salto
    
    [Range(1, 500)] public float potenciaSalto;

    //Control de vidas
    public bool vulnerable;
    public int numVidas;

    //Puntos para powerUp
    public int puntacion;

    //Sonido
    public AudioClip audioVida;
    public AudioClip audioMasPuntos;
    public AudioClip audioMenosPuntos;
    private AudioSource audioSource;

    private GameObject objetoEscena;

    //instancia de GameManager
    private GameManager gameManager;

    public Canvas canvas;
    private ControlHUD hud;
    //Temporizador
    public float tiempoInicio;
    public int tiempoNivel;
    public int tiempoEmpleado;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
        vulnerable = true;

        hud = canvas.GetComponent<ControlHUD>();

        hud.setPowerUpTxt(puntacion);

        hud.setVidaUpTxt(numVidas);

        gameManager = FindObjectOfType<GameManager>();

        Debug.Log("vidas " + numVidas);
        
        audioSource = GetComponent<AudioSource>();
        objetoEscena = GameObject.FindGameObjectWithTag("escena");

        tiempoInicio = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoEmpleado = (int)(Time.time - tiempoInicio);

        if ((tiempoNivel - tiempoEmpleado) < 0)
        {
            //Fin del Juego
        }

        hud.setTiempo(tiempoNivel - tiempoEmpleado);
    }

	private void FixedUpdate()
	{
        float movimientoH = Input.GetAxisRaw("Horizontal");

        rb2d.velocity = new Vector2(movimientoH * velocidad, rb2d.velocity.y);

        if(movimientoH > 0)
        {
            spRd.flipX = false;

        }else if(movimientoH < 0)
        {
            spRd.flipX = true;
        }

        if(movimientoH != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
            rb2d.AddForce(Vector2.up * potenciaSalto);
            animator.SetBool("Salto", true);
            isJumping = true;
            

            //Debug.Log("Saltando " + isJumping);
        }


    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("Suelo"))
        {

            isJumping = false;
            animator.SetBool("Salto", false);

            //Debug.Log("Contacto con suelo: " + isJumping);


            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }
    public void QuitarVida()
    {
        if (vulnerable)
        {
            vulnerable = false;
            Invoke("HacerVulnerable", 1f);
            spRd.color = Color.red;
            numVidas--;

            gameManager.decrementarVidas();
            hud.setVidaUpTxt(numVidas);
            Debug.Log("Numero de vidas:" + numVidas);

            // Reproducir efecto de sonido
            audioSource.PlayOneShot(audioVida);

        }
        
    }
    private void HacerVulnerable()
    {
        vulnerable = true;
        spRd.color = Color.white;
    }
    public void IncrementarPuntos(int cantidad)
    {
        if (cantidad == -50)
        {
            puntacion += cantidad;
            hud.setPowerUpTxt(puntacion);
            Debug.Log(puntacion);
            // Reproducir efecto de sonido
            audioSource.PlayOneShot(audioMenosPuntos);
        }
        else
        {
            puntacion += cantidad;
            hud.setPowerUpTxt(puntacion);
            Debug.Log(puntacion);
            // Reproducir efecto de sonido
            audioSource.PlayOneShot(audioMasPuntos);
        }
    
    }
  
}
