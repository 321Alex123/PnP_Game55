using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainUIHandler : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}