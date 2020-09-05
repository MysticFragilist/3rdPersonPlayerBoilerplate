using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    [System.Serializable]
    public class PlayerData
    {
        public float[] position { get; set; }
        public float[] rotation { get; set; }
        public float health { get; set; }
        public long xp { get; set; }

        public PlayerData(Player player)
        {
            InstantiateFloatArrayFromVector3(player.transform.position);
            InstantiateFloatArrayFromQuaternion(player.transform.rotation);

            //TODO: Implement those values in a player script
            health = player.Health;
            xp = player.Experience;
        }

        public PlayerData(Vector3 pos, Quaternion rot)
        {
            InstantiateFloatArrayFromVector3(pos);
            InstantiateFloatArrayFromQuaternion(rot);

            health = 100;
            xp = 0;
        }

        private void InstantiateFloatArrayFromVector3(Vector3 vect)
        {
            position = new float[3];
            position[0] = vect.x;
            position[1] = vect.y;
            position[2] = vect.z;
        }

        private void InstantiateFloatArrayFromQuaternion(Quaternion quat)
        {
            rotation = new float[4];

            rotation[0] = quat.x;
            rotation[1] = quat.y;
            rotation[2] = quat.z;
            rotation[3] = quat.w;
        }
    }
}
