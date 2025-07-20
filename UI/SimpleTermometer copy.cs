using Base;
using TMPro;
using UnityEngine;
using VContainer;
namespace UI
{
    public class SimpleTermoMeter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;
        Building building;
        public void Awake()
        {
            Debug.Log("IRL clock awake");
        }
        [Inject]
        public void Construct(Building building)
        {
            this.building = building;
            building.Heat.OnChange += UpdateLabel;
            UpdateLabel();
        }
        public void UpdateLabel()
        {
            label.text = building.Heat.CurrentValue.ToString("F2") + "C";
        }
        void OnDestroy()
        {
            building.Heat.OnChange -= UpdateLabel;
        }
    }
}