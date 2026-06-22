using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private const string SCENE_LOBBY = "LobbyScene";

    private void Start()
    {
        SceneManager.LoadScene(SCENE_LOBBY);
    }
}
