using UnityEngine;
public class SistemaGUI : MonoBehaviour
{
    private bool estaPausado = false;
    public GameObject menuPausa;
    public PPCamara scriptCamara;

    void Start()
    {
        if (menuPausa != null)
        {
            menuPausa.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }

    void Pausar()
    {
        estaPausado = !estaPausado;

        if (estaPausado)
        {
            Time.timeScale = 0;
            if (menuPausa != null)
            {
                menuPausa.SetActive(true);
            }
            if (scriptCamara != null)
            {
                Cursor.lockState = CursorLockMode.None;
                scriptCamara.enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1;
            if (menuPausa != null)
            {
                menuPausa.SetActive(false);
            }
            if (scriptCamara != null)
            {
                scriptCamara.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

