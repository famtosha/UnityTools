using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityTools.Extentions
{
    public static class InstantiateExtentions
    {
        public static T InstantiateAtPosition<T>(this T monoBehaviour, Vector3 position) where T : Component
        {
            return Object.Instantiate(monoBehaviour, position, monoBehaviour.transform.rotation);
        }

        public static T Instantiate<T>(this T monoBehaviour, Vector3 position, Quaternion rotation) where T : Component
        {
            return Object.Instantiate(monoBehaviour, position, rotation);
        }
    }
}