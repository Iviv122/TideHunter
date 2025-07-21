using TMPro;
using UnityEngine;
namespace UI
{
    public class GeneratorFuelPercent : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;
        [SerializeField] Modules.Generator generator;
        public void Awake()
        {
            Debug.Log("IRL clock awake");

            generator.OnChange += UpdateLabel;
            label.text = "100%";
        }
        public void UpdateLabel()
        {
            label.text = (generator.FuelPercent * 100).ToString("F2") + "%";
        }
        void OnDestroy()
        {
            generator.OnChange -= UpdateLabel;
        }
    }
}