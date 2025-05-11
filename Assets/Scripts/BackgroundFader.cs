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

        SetAlpha(nightRenderers, 0f); // ���� ó���� �����ϰ� �����
        nightSet.SetActive(true);     // �� ������Ʈ�� ������ ���� ����

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

        SetAlpha(dayRenderers, 0f);   // �� ������ ����
        SetAlpha(nightRenderers, 1f); // �� ������ ǥ��
        daySet.SetActive(false);      // �� ������Ʈ ������
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
