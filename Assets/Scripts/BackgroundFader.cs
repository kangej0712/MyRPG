using UnityEngine;
using System.Collections;

public class BackgroundFader : MonoBehaviour
{
    public GameObject daySet;
    public GameObject nightSet;
    public float fadeDuration = 2f;
    public float waitTime = 30f;

    private SpriteRenderer[] dayRenderers;
    private SpriteRenderer[] nightRenderers;

    void Start()
    {
        dayRenderers = daySet.GetComponentsInChildren<SpriteRenderer>();
        nightRenderers = nightSet.GetComponentsInChildren<SpriteRenderer>();

        SetAlpha(nightRenderers, 0f); // 밤을 처음에 투명하게 만들어
        nightSet.SetActive(true);     // 밤 오브젝트를 켜지만 투명 상태

        StartCoroutine(FadeToNightRoutine());
    }

    IEnumerator FadeToNightRoutine()
    {
        yield return new WaitForSeconds(waitTime);

        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = timer / fadeDuration;

            SetAlpha(dayRenderers, 1f - alpha);
            SetAlpha(nightRenderers, alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        SetAlpha(dayRenderers, 0f);   // 낮 완전히 숨김
        SetAlpha(nightRenderers, 1f); // 밤 완전히 표시
        daySet.SetActive(false);      // 낮 오브젝트 꺼버림
    }

    void SetAlpha(SpriteRenderer[] renderers, float alpha)
    {
        foreach (var r in renderers)
        {
            if (r != null)
            {
                Color c = r.color;
                c.a = alpha;
                r.color = c;
            }
        }
    }
}
