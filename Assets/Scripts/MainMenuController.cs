using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Animator del menú")]
    public Animator animator;

    [Header("Nombre de la escena del juego")]
    public string gameSceneName = "SampleScene"; // Dariel, si haras cambio con lo del main menu, aqui pones la escena del juego, para que al presionar entre se inice

    private bool isStarting = false;

    void Update()
    {
        if (!isStarting && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            isStarting = true;
            if (animator != null)
            {
                animator.SetTrigger("StartGame");
            }
            else
            {
                
                SceneManager.LoadScene(gameSceneName);
            }
        }
    }

    // Esto llama al método desde el Animation Event al final de FadeOut_Menu
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
