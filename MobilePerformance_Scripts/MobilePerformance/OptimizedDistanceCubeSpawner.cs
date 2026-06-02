using UnityEngine;


namespace MobilePerformance
{
    public class OptimizedDistanceCubeSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private int cubesCount = 50;
        [SerializeField] private float spacing = 2f;
        [SerializeField] private int cubesPerRow = 10;

        [Header("Optional Prefab")]
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private Material sharedCubeMaterial;

        private void Awake()
        {
            SpawnCubes();
        }

        private void SpawnCubes()
        {
            Transform[] transforms = new Transform[cubesCount];

            for (int i = 0; i < cubesCount; i++)
            {
                Vector3 position = GetCubePosition(i);
                GameObject cube = CreateCube(position, i);

                if (sharedCubeMaterial != null && cube.TryGetComponent(out MeshRenderer mr))
                {
                    mr.sharedMaterial = sharedCubeMaterial;
                }
                   
                transforms[i] = cube.transform;
            }

            if (TryGetComponent(out DistanceCubeManager manager))
            {
                manager.Initialize(transforms);
            }              
        }

        private Vector3 GetCubePosition(int index)
        {
            int x = index % cubesPerRow;
            int z = index / cubesPerRow;
            return new Vector3(x * spacing, 0f, z * spacing);
        }

        private GameObject CreateCube(Vector3 position, int index)
        {
            GameObject cube;

            if (cubePrefab != null)
            {
                cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
            }
            else
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.SetParent(transform);
                cube.transform.position = position;
            }

            cube.name = $"Optimized Distance Cube {index + 1}";
            return cube;
        }
    }
}
