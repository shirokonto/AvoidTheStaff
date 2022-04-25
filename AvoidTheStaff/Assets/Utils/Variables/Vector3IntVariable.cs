using UnityEngine;

namespace DataStructures.Variables
{
    [CreateAssetMenu(fileName = "NewVector3IntVariable", menuName = "Utils/Variables/Vector3IntVariable")]
    public class Vector3IntVariable : AbstractVariable<Vector3Int>
    {
        public void Add(Vector3Int value)
        {
            runtimeValue += value;
            onValueChanged.Raise();
        }

        public void Add(Vector3IntVariable value)
        {
            runtimeValue += value.runtimeValue;
            onValueChanged.Raise();
        }
    }
}
