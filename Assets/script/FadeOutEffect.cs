using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEffect : MonoBehaviour
{
    public float fadeDuration = 2f; // Kaybolma s�resi (saniye)

    private Renderer objectRenderer; // Nesnenin Renderer bile�eni

    public void play()
    {
        objectRenderer = GetComponent<Renderer>();

        // FadeOutEffect() metodunu ba�latan fonksiyonu �a��r�yoruz.
        // Coroutine, nesnenin yava� yava� kaybolma etkisini olu�turacakt�r.
        StartCoroutine(FadeOutEffectCoroutine());
    }

    // Yava� yava� kaybolma i�lemini ger�ekle�tiren Coroutine
    private IEnumerator FadeOutEffectCoroutine()
    {
        // Ba�lang�� rengi ve son renk belirleme
        Color startColor = objectRenderer.material.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float elapsedTime = 0f;

        // Yava� yava� kaybolma d�ng�s�
        while (elapsedTime < fadeDuration)
        {
            // Yava� yava� renk de�i�imini hesapla
            objectRenderer.material.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);

            // Bir sonraki frame i�in bekle
            yield return null;

            // Zaman� g�ncelle
            elapsedTime += Time.deltaTime;
        }

        // Kaybolma s�resi tamamland���nda nesneyi yok et
        Destroy(gameObject);
    }
}
