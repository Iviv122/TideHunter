using UnityEngine;
namespace Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class Item : ScriptableObject
    {
        [SerializeField] public ItemType type;
        [SerializeField] public GameObject Model;
    }
    public enum ItemType
    {
        GasCanister,
        Battery,
    }
}
