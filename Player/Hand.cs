using Items;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Item item;
    private GameObject model;
    private void DropItem()
    {
        if (item != null)
        {
            Destroy(model);
            item = null;
        }
    }
    public void TakeItem(Item item)
    {
        DropItem();
        this.item = item;
        model = Instantiate(item.Model, transform.position, Quaternion.identity, transform);
    }
    public bool isEmpty()
    {
        return item == null;
    }
    public bool Has(ItemType type)
    {
        return item != null && item.type == type;
    }

    public void ConsumeItem()
    {
        if (item != null)
        {
            item = null;
            Destroy(model);
        }
    }
}