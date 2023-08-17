using System.Collections;
using UnityEngine;

public class SlideWindow : MonoBehaviour
{
    [SerializeField] private GameObject coinSlideObject;
    [SerializeField] private GameObject stockSlideObject;
    [SerializeField] private Animator animator;

    private bool isOpened = false;

    public void OnClickOpenSlideWindow() 
        => OpenSlideWindow();

    public void OnClickCloseSlideWindow() 
        => CloseSlideWindow();

    public void OnClickActivateCoinSlideObject()
        => ActivateCoinSlideObject();

    public void OnClickActivateStockSlideObject()
        => ActivateStockSlideObject();

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

    private void ActivateCoinSlideObject()
    {
        if (isOpened == false)
        {
            coinSlideObject.SetActive(true);
            isOpened = true;
        }
    }

    private void ActivateStockSlideObject()
    {
        if (isOpened == false)
        {
            stockSlideObject.SetActive(true);
            isOpened = true;
        }
    }

    private void DeactivateSlideObject()
    {
        coinSlideObject.SetActive(false);
        stockSlideObject.SetActive(false);
        isOpened = false;
    }
}
