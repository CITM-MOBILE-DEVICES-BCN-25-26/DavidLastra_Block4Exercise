using System.Text;
using TMPro;
using UnityEngine;

namespace MobilePerformance
{

	public class OptimizedTimerText : MonoBehaviour
	{
		[SerializeField] private TMP_Text timerText;
		[SerializeField] private float updateInterval = 0.1f; 

		private float _elapsedTime;
		private float _lastDisplayedTime = -1f;
        private StringBuilder _sb = new StringBuilder(16);

        private void Awake()
		{
			if (timerText == null)
			{
                timerText = GetComponent<TMP_Text>();
            }
				
		}

		private void Update()
		{
			_elapsedTime += Time.deltaTime;

			if (_elapsedTime - _lastDisplayedTime >= updateInterval)
			{
				_lastDisplayedTime = _elapsedTime;
                _sb.Clear();
                _sb.Append("Time: ");
                _sb.Append(_elapsedTime.ToString("0.0"));

                timerText.text = _sb.ToString();
            }
		}
	}
}
