using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance { get; private set; }

    [Header ("Current Material")]
    public MaterialObject currentMaterial;
    [Header ("Default")]
    public MaterialObject defaultMaterial;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if (currentMaterial == null)
            {
                currentMaterial = defaultMaterial;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
