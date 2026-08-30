using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    public GameObject ruleScene;
    public void Start()
    {
        // SoundManager.PlayBGM(BGM_Sound.Title);
    }
    public void OnButtonClick()
    {
        SoundManager.PlaySE(SE_Sound.Button);
    }
    public void OnReStartButtonClick()
    {
        OnButtonClick();
        SceneManager.LoadScene("MainScene");
        
    }
    public void OnBackTittleButtonClick()
    {
        OnButtonClick();
        SceneManager.LoadScene("TittleScene");
        
    }
}
