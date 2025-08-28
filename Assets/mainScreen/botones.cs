using UnityEngine;
using UnityEngine.SceneManagement;
public class botones : MonoBehaviour
{

    public void iniciar()
    {
        SceneManager.LoadScene(1);
    }
    public void salir()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}