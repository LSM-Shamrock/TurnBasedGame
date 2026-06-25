using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AutoInjectionTarget]
public class UI_Lobby : MonoBehaviour
{
    private const string SCENE_GAME = "GameScene";

    [ChildField] public Button StartButton;
    [ChildrenArrayField] public Image[] UnitImages;

    private void Awake()
    {
        StartButton.onClick.AddListener(OnClick_StartButton);

        UnitData[] unitDatas = LobbyManager.Instance.SelectedUnits;
        for (int i = 0; i < unitDatas.Length; i++)
            UnitImages[i].sprite = Resources.Load<Sprite>($"UnitSprites/{unitDatas[i].CodeName}");
    }

    private void OnClick_StartButton()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }
}
