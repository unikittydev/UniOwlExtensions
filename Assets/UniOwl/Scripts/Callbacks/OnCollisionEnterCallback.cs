using UnityEngine;
using UnityEngine.Events;

namespace UniOwl
{
    public class OnCollisionEnterCallback : MonoBehaviour
    {
        [SerializeField] private UnityEvent callback;

        private void OnCollisionEnter()
        {
            callback?.Invoke();
        }
    }
}