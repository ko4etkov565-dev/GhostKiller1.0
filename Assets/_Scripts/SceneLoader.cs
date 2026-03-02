using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
}
