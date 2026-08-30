using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleSceneManager : MonoBehaviour
{
    [SerializeField]
    public GameObject ruleScene;
    public void Start()
    {
        ruleScene.SetActive(false);
         SoundManager.PlayBGM(BGM_Sound.Title);
    }
    public void OnButtonClick()
    {
        SoundManager.PlaySE(SE_Sound.Button);
    }
    public void OnStartButtonClick()
    {
        OnButtonClick();
        SceneManager.LoadScene("MainScene");
        
    }
    public void OnOptionButtonClick()
    {
        OnButtonClick();
        ruleScene.SetActive(true);
    }
    public void OnOptionBackButtonClick()
    {
        OnButtonClick();
        ruleScene.SetActive(false);
    }
    public void OnExitButtonClick()
    {

    }
}
