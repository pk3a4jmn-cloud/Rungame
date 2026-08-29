using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleSceneManager : MonoBehaviour
{
    [SerializeField]
    public GameObject ruleScene;
    public void Start()
    {
        ruleScene.SetActive(false);
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnOptionButtonClick()
    {
        ruleScene.SetActive(true);
    }
     public void OnOptionBackButtonClick()
    {
        ruleScene.SetActive(false);
    }
        public void OnExitButtonClick()
    {
        
    }
}
