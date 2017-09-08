using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public static class SpriteRendererExtension
{
    public static void FadeSprite(this SpriteRenderer renderer, MonoBehaviour monoBeh, float duration, Action<SpriteRenderer> callback = null)
    {
        monoBeh.StartCoroutine(FadeCoroutine(renderer, duration, callback));
    }

    private static IEnumerator FadeCoroutine(SpriteRenderer renderer, float duration, Action<SpriteRenderer> callback)
    {
        float startTime = Time.time;
        while(startTime + duration >= Time.time)
        {
            Color color = renderer.color;
            color.a = 1f - Mathf.Clamp01((Time.time - startTime) / duration);
            renderer.color = color;

            yield return new WaitForEndOfFrame();
        }

        if (callback != null)
        {
            callback(renderer);
        }
    }


}
