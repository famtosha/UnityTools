using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityTools.Extentions
{
    public static class TransformExtensions
    {
        public static int GetGlobalSiblingIndexFast(this Transform transform)
        {
            return int.Parse(GetGlobalSiblingIndex(transform).Inverse());

            string GetGlobalSiblingIndex(Transform transform)
            {
                var index = transform.GetSiblingIndex().ToString();
                var parent = transform.parent;
                if (parent != null) index += GetGlobalSiblingIndex(parent);
                return index;
            }
        }

        public static int GetGlobalSiblingIndexCorrect(this Transform transform)
        {
            var _map = new List<Transform>(1024);

            var roots = Object
                .FindObjectsOfType<GameObject>()
                .Select(x => x.transform.root)
                .Distinct()
                .OrderBy(x => x.GetSiblingIndex());

            roots.ForEach(Map);

            return _map.IndexOf(transform);

            void Map(Transform obj)
            {
                _map.Add(obj);
                obj.GetChildrens().ForEach(Map);
            }
        }

        public static List<int> GetGlobalSiblingIndexCorrect(this List<Transform> transforms)
        {
            var _map = new List<Transform>(1024);

            var roots = Object
                .FindObjectsOfType<GameObject>()
                .Select(x => x.transform.root)
                .Distinct()
                .OrderBy(x => x.GetSiblingIndex());

            roots.ForEach(Map);

            return transforms.Select(x => _map.IndexOf(x)).ToList();

            void Map(Transform obj)
            {
                _map.Add(obj);
                obj.GetChildrens().ForEach(Map);
            }
        }
    }
}