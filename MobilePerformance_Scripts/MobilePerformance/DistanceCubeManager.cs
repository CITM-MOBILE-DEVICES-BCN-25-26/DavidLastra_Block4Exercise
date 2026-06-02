using UnityEngine;

namespace MobilePerformance
{
    public class DistanceCubeManager : MonoBehaviour
    {
        private Transform[] _cubeTransforms;
        private float[,] _distances;

        public void Initialize(Transform[] cubeTransforms)
        {
            _cubeTransforms = cubeTransforms;
            _distances = new float[_cubeTransforms.Length, _cubeTransforms.Length];
        }

        private void Update()
        {
            if (_cubeTransforms == null) return;

            for (int i = 0; i < _cubeTransforms.Length; i++)
            {
                for (int j = i + 1; j < _cubeTransforms.Length; j++)
                {
                    float distance = Vector3.Distance(
                        _cubeTransforms[i].position,
                        _cubeTransforms[j].position);

                    _distances[i, j] = distance;
                    _distances[j, i] = distance;
                }
            }
        }
    }
}