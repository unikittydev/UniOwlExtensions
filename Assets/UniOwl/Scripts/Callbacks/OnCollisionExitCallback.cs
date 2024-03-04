using UnityEngine;
using UnityEngine.Events;

namespace UniOwl
{
	public class OnCollisionExitCallback : MonoBehaviour
	{
		[SerializeField] private UnityEvent callback;

		private void OnCollisionExit()
		{
			callback?.Invoke();
		}
	}
}
