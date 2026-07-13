using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClosePanelButton : MonoBehaviour
{
    private Button button;
    private GameObject panelToClose;

    void Awake()
    {
        button = GetComponent<Button>();
        if (transform.parent != null)
        {
            panelToClose = transform.parent.gameObject;
        }

        button.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }
    }
}
