using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panelToOpen; 
    public void OnAnimationComplete()
    {
        if (panelToOpen != null)
        {
            panelToOpen.SetActive(true);
        }
    }
}