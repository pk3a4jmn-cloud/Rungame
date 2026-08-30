using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIalpha : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Animator animator;

    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup.alpha = 0;
      
       animator.enabled = false; 
    }
    public void OnPointerEnter(PointerEventData eventData) 
{
    animator.enabled = true; 
    animator.Play("In", 0, 0f);
   
}

public void OnPointerExit(PointerEventData eventData) 
{
    animator.Play("Out", 0, 0f);
 
}

}
