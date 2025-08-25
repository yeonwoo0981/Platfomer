using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "FruitSO", menuName = "SO/FruitSO")]
public class FruitSO : ScriptableObject
{
    public  string  fruitName;
    public int score;
    public SpriteLibraryAsset spriteAsset;
}
