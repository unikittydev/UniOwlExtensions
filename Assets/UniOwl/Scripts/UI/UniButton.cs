using UniOwl.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UniOwl.UI
{
    public class UniButton : Button
    {
        [SerializeField] private AudioClip hoverClip;
        [SerializeField] private AudioClip clickClip;
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            AudioSFXSystem.PlayClip2D(hoverClip);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            AudioSFXSystem.PlayClip2D(clickClip);
        }
    }
}