using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel; 
    private int piecesCollected = 0;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

    public void CollectPiece()
    {
        piecesCollected++; 
        Debug.Log($"Piezas recolectadas del Tumi: {piecesCollected}");

       
        if (piecesCollected >= 3)
        {
            ShowVictoryPanel();
        }
    }

    private void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);  
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
