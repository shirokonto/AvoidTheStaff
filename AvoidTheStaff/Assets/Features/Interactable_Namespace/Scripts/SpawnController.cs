using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
namespace Features.Interactable_Namespace.Scripts
{
    public class SpawnController : MonoBehaviour
    {
        [Header("Collectable")]
        [SerializeField] private Transform collectableGem;
        [SerializeField] private int numberOfGems;
        private float _transformY;
    
        // Start is called before the first frame update
        void Start()
        {
            _transformY = 0.25f;
            SetGemPositions();

        }

        // Update is called once per frame
        void Update()
        {
    
        }

        private void SetGemPositions()
        {
            for (int i = 0; i < numberOfGems; i++)
            {
                var position = new Vector3(Random.Range(-4.5f, 4.5f), _transformY, Random.Range(-4.5f, 4.5f));
                Instantiate(collectableGem, position, Quaternion.identity);

            }
        }
    }
}
