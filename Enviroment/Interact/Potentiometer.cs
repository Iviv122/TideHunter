using Events;
using UnityEngine;

namespace Interact
{
    public class Potentionometer : Scrollable
    {

        public override void Down()
        {
            Debug.Log("Down");
            foreach (var item in DownEvents)
            {
                item.Act();
            }
        }

        public override void Up()
        {
            Debug.Log("Up");
            foreach (var item in UpEvents)
            {
                item.Act();
            }
        }
    }
}