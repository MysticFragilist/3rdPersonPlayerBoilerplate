using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    public static class DataExtension
    {
        public static Vector3 GetPosition(this PlayerData data)
        {
            return new Vector3(data.position[0], data.position[1], data.position[2]);
        }

        public static Quaternion GetRotation(this PlayerData data)
        {
            return new Quaternion(data.rotation[0], data.rotation[1], data.rotation[2], data.rotation[3]);
        }
    }
}
