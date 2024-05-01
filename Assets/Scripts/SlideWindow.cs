using System.Collections;
using UnityEngine;

public class SlideWindow : MonoBehaviour
{
    [SerializeField] private GameObject slideObject;
    [SerializeField] private Animator animator;

    private bool isOpened = false;

    public void OnClickOpenSlideWindow() 
        => OpenSlideWindow();

    public void OnClickCloseSlideWindow() 
        => CloseSlideWindow();

    public void OnClickActivateSlideObject()
        => ActivateSlideObject();

    public void EventDeactivateSlideObject() 
        => DeactivateSlideObject();

    private void OpenSlideWindow()
    {
        animator.SetBool("isClickClose", false);
    }

    private void CloseSlideWindow()
    {
        animator.SetBool("isClickClose", true);
    }

    private void ActivateSlideObject()
    {
        if (isOpened == false)
        {
            slideObject.SetActive(true);
            isOpened = true;
        }
    }

    private void DeactivateSlideObject()
    {
        slideObject.SetActive(false);
        isOpened = false;
    }
}
