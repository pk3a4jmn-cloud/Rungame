using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    private static MainSceneManager Instance;
    
    [SerializeField] private Animator anim;

    void Awake()
    {
        Instance = this;
    }

    public static void ChangeResult()
    {
            Instance.StartCoroutine(Instance.LoadScene());
    }

    IEnumerator LoadScene()
    {
        anim.SetTrigger("changeflag");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("ResultScene");
    }
}
