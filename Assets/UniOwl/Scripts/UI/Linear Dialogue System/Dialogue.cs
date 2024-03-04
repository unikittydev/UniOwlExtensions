using UnityEngine;
using UnityEngine.Localization;

namespace UniOwl
{
	[CreateAssetMenu(menuName = "Game/Dialogue", fileName = "SO_Dialogue")]
	public class Dialogue : ScriptableObject
	{
		public LocalizedString[] lines;
		public float typeSpeed = 0.025f;
		public float fadeOutDelay = 2f;

		public bool disableAfterDisplay = false;
	}
}