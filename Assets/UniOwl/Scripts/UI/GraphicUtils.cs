using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UniOwl.UI
{
    public static class GraphicUtils
    {
        public static Coroutine FadeOut(MonoBehaviour context, Graphic graphic, float time)
        {
            return FadeFromTo(context, graphic, 1f, 0f, time);
        }

        public static Coroutine FadeIn(MonoBehaviour context, Graphic graphic, float time)
        {
            return FadeFromTo(context, graphic, 0f, 1f, time);
        }

        public static Coroutine FadeFromTo(MonoBehaviour context, Graphic graphic, float from, float to, float time)
        {
            return context.StartCoroutine(FadeFromTo_Coroutine(graphic, from, to, time));
        }

        private static IEnumerator FadeFromTo_Coroutine(Graphic graphic, float from, float to, float time)
        {
            float counter = 0f;
            while (counter < time)
            {
                float t = Mathf.Clamp01(counter / time);
                graphic.SetAlpha(Mathf.Lerp(from, to, t));
                
                counter += Time.unscaledDeltaTime;
                yield return null;
            }
            graphic.SetAlpha(to);
        }

        public static void SetAlpha(this Graphic graphic, float value)
        {
            Color color = graphic.color;
            color.a = value;
            graphic.color = color;
        }
    }
}