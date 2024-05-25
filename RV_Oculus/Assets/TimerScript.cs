using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timerDuration = 300f; // Duración del temporizador en segundos (5 minutos)
    private float timeRemaining;
    public TextMeshProUGUI timerText; // Referencia al componente de texto UI para mostrar el tiempo

    void Start()
    {
        timeRemaining = timerDuration;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI(timeRemaining);
        }
        else
        {
            // El tiempo ha terminado, cargar la escena "DeathHud"
            SceneManager.LoadScene("DeathHud");
        }
    }

    void UpdateTimerUI(float time)
    {
        // Convierte el tiempo restante en minutos y segundos
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        
        // Actualiza el texto del temporizador
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

