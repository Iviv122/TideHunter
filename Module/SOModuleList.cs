using UnityEngine;

namespace Modules
{
    [CreateAssetMenu(fileName = "SOModuleList", menuName = "SOModuleList", order = 0)]
    public class SOModuleList : ScriptableObject
    {
        [SerializeField] public Module[] modules;
    }
}