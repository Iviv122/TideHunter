using System;
using TMPro;
using UnityEngine;
using VContainer;
namespace UI
{
    public class Clock : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI label;

        [Inject]
        public void Update()
        {
            label.text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}