using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI powerupTxt;
    public TextMeshProUGUI vidaUpTxt;
    public TextMeshProUGUI tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setPowerUpTxt(int puntuacion)
    {
        powerupTxt.text = "Puntos:" + puntuacion;
    }
    public void setVidaUpTxt(int vida)
    {
        vidaUpTxt.text = "Vida:" + vida;
    }
    public void setTiempo(int tiempoP)
    {
        int segundos = tiempoP % 60;

        int minutos = tiempoP / 60;

        tiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
    
}
