using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AutoInjectionTarget]
public class UI_Lobby : MonoBehaviour
{
    private const string SCENE_GAME = "GameScene";

    [ChildField] 
    public Button StartButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(OnClick_StartButton);
    }

    private void OnClick_StartButton()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }
}
