using Base;
using TMPro;
using UnityEngine;
using VContainer;
namespace UI
{
    public class PowerProductionMeter : MonoBehaviour
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
            building.Power.OnChange += UpdateLabel;
            UpdateLabel();
        }
        public void UpdateLabel()
        {
            label.text = building.Power.CurrentValue.ToString("F2") + "kW";
        }
        void OnDestroy()
        {
            building.Power.OnChange -= UpdateLabel;
        }
    }
}