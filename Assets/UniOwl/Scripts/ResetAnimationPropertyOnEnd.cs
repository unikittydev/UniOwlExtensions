using UnityEngine;

namespace UniOwl.Animation
{
    [RequireComponent(typeof(Animator))]
    public class ResetAnimationPropertyOnEnd : MonoBehaviour
    {
        public void ResetBool(string paramName)
        {
            GetComponent<Animator>().SetBool(paramName, false);
        }
    }
}