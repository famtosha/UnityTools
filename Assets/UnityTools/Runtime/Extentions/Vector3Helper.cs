using UnityEngine;

namespace UnityTools.Extentions
{
    public static class Vector3Helper
    {
        public static Vector3 GetRandomVector3()
        {
            return new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f), Random.Range(-1, 1f)).normalized * Random.Range(100, 250);
        }

        public static Vector3 GetRandomVector3XZ()
        {
            return new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f)).normalized;
        }
    }
}