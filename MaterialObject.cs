using UnityEngine;

[CreateAssetMenu(fileName = "NewMaterial", menuName = "Progression/MaterialObject")]
public class MaterialObject : ScriptableObject
{
    public string materialName;
    public float fatigueStrengthCoeff;
    public float fatigueSrengthExp;
    public float enduranceLimit;
    public float ultTensileStrength;
    public int price;
    public Sprite icon;
    public int order;
}
