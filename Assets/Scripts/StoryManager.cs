using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public Text displayText;  
    public NaverTTS naverTTS; 

    private string[] texts = {
        "와아~ 눈이 내려요! 눈사람을 만들어 볼까요?",
        "읏쌰 다됐다! 이제 눈사람이 춥지 않도록 모자와 목도리만 고르면 돼!",
        "어떤 모자와 목도리를 선물해줄까?"
    };

    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(PlaySequentialTTS());
    }

    private IEnumerator PlaySequentialTTS()
    {
        while (currentIndex < texts.Length)
        {
            displayText.text = texts[currentIndex];
            naverTTS.text = texts[currentIndex]; // 텍스트 전달
            //naverTTS.Play(); 

            // TTS 재생이 완료될 때까지 대기
            yield return new WaitUntil(() => !naverTTS.isPlaying);

            // 3초 후에 재생
            yield return new WaitForSeconds(10f);

            currentIndex++;
        }
    }
}
