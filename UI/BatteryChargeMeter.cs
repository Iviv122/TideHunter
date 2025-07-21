using TMPro;
using UnityEngine;
namespace UI
{
    public class BatteryChargeMeter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;
        [SerializeField] Modules.Battery battery;
        public void Awake()
        {
            battery.OnChange += UpdateLabel;
            label.text = "100%";
        }
        public void UpdateLabel()
        {
            label.text = (battery.LifeTimePercent * 100).ToString("F2") + "%";
        }
        void OnDestroy()
        {
            battery.OnChange -= UpdateLabel;
        }
    }
}