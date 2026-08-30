using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Animator animator;

    private Vector3 originalScale;
    private Vector3 hoverScale;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup.alpha = 0;
       originalScale = transform.localScale;  
       animator.enabled = false; 
    }
    public void OnPointerEnter(PointerEventData eventData) 
{
    animator.enabled = true; 
    animator.Play("In", 0, 0f);
    transform.localScale = originalScale * 1.2f; 
}

public void OnPointerExit(PointerEventData eventData) 
{
    animator.Play("Out", 0, 0f);
    transform.localScale = originalScale; 
}

}
