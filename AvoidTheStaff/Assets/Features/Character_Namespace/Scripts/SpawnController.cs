using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Features.Character_Namespace
{
    public class SpawnController : MonoBehaviour
    {
        [Header("Collectable")]
        [SerializeField] private Transform collectableGem;
        [SerializeField] private int numberOfGems;

        private Vector3[] positions;
        // Start is called before the first frame update
        void Start()
        {
            SetGemPositions();

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void SetGemPositions()
        {
            positions = new Vector3[numberOfGems];
            for (int i = 0; i < numberOfGems; i++)
            {
                var position = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, Random.Range(-4.5f, 4.5f));
                //TODO: Vermeide bei der Verteilung Kollisionen zwischen den Objekten
                //foreach (var pos in positions)
                //{
                //    if (!pos.Equals(position))
                //    {
                        positions[i] = position;
                        Instantiate(collectableGem, position, Quaternion.identity);
                //    }
                //}
                
            }
        }
    }
}
