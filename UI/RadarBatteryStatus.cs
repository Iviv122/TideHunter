using Modules;
using TMPro;
using UnityEngine;
namespace UI
{
    public class RadarBatteryStatus : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;
        [SerializeField] Radar radar;
        public void Awake()
        {
            radar.OnChange += UpdateLabel;
            label.text = "Radar Battery " + 100  +"%";
        }
        public void UpdateLabel()
        {
            label.text = "Radar Battery " + (radar.BatteryPercent*100).ToString("F2") + "%";
        }
    }
}