using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UniOwl
{
	public class DialogueSystem : MonoBehaviour
	{
		[SerializeField] private TMP_Text text;

		[SerializeField] private AudioSource popSource;

		[SerializeField] private KeyCode skipCode;
		
		private Coroutine displayCoroutine;

		private readonly HashSet<Dialogue> displayedDialogues = new();

		private static DialogueSystem _instance;
		public static DialogueSystem instance => _instance;

		private bool skipButtonPressed;
		
		private void Awake()
		{
			_instance = this;
		}

		private void Update()
		{
			if (Input.GetKeyDown(skipCode))
				skipButtonPressed = true;
		}

		public void DisplayDialogue(Dialogue dialogue)
		{
			if (dialogue.disableAfterDisplay)
			{
				if (!displayedDialogues.Contains(dialogue))
					displayedDialogues.Add(dialogue);
				else
					return;
			}

			if (displayCoroutine != null)
				StopCoroutine(displayCoroutine);

			displayCoroutine = StartCoroutine(DisplayDialogueCoroutine(dialogue));
		}

		private IEnumerator DisplayDialogueCoroutine(Dialogue dialogue)
		{
			text.text = string.Empty;

			var waitLetter = new WaitForSecondsRealtime(dialogue.typeSpeed);
			
			foreach (var line in dialogue.lines)
			{
				string displayLine = string.Empty;
				string fullDisplayLine = line.GetLocalizedString();
				
				if (dialogue.typeSpeed == 0f)
					text.text = fullDisplayLine;
				else
				{
					popSource.Play();
					foreach (char c in fullDisplayLine)
					{
						displayLine += c;
						text.text = displayLine;

						if (skipButtonPressed)
						{
							text.text = fullDisplayLine;
							skipButtonPressed = false;
							break;
						}

						yield return waitLetter;
					}
					popSource.Stop();
				}

				// Show arrow down

				yield return new WaitUntil(() => skipButtonPressed);
				skipButtonPressed = false;
				
				text.text = string.Empty;
			}
		}
	}
}
