using UnityEngine;

[CreateAssetMenu(fileName = "NewMaterial", menuName = "Progression/MaterialObject")]
public class MaterialObject : ScriptableObject
{
    public string materialName;
    public float fatigueStrengthCoeff;
    public float fatigueSrengthExp;
    public int price;
    public Sprite icon;
}
