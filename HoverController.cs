using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverPopupController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("References")]
    [SerializeField] private Image targetImage;
    [SerializeField] private GameObject popupWindow;

    [Header("Settings")]
    [SerializeField] private float fadeSpeed = 1.5f;

    private bool isHovered = false;

    void Update()
    {
        if (targetImage == null) return;

        Color currentColor = targetImage.color;
        float targetAlpha = isHovered ? 1f : 0f;
        currentColor.a = Mathf.MoveTowards(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
        targetImage.color = currentColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (popupWindow != null)
        {
            popupWindow.SetActive(true);
        }
    }

    public void ReturnToLevel()
    {
        popupWindow.SetActive(false);
    }
}