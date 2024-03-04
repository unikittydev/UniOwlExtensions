using UnityEngine;
using UnityEngine.Events;

namespace UniOwl
{
	public class OnTriggerEnterCallback : MonoBehaviour
	{
		[SerializeField] private UnityEvent callback;

		private void OnTriggerEnter(Collider other)
		{
			callback?.Invoke();
		}
	}
	
	public class OnTriggerExitCallback : MonoBehaviour
	{
		[SerializeField] private UnityEvent callback;

		private void OnTriggerExit(Collider other)
		{
			callback?.Invoke();
		}
	}
}
