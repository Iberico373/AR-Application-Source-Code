using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")
    ]
public class Object : ScriptableObject
{
    public Sprite icon = null;
    public GameObject objectPrefab = null;
}
