using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
     public static NextScene Instance;

    [Header("패널 / 텍스트")]
    [SerializeField] private RectTransform[] panels;      
    [SerializeField] private TextMeshProUGUI transitionText;

    [Header("연출 설정")]
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private float delay = 0.1f;

    [Header("버튼용 설정")]
    [SerializeField] private string nextSceneName; 
    [SerializeField] private string message = "NEXT STAGE";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        PlayExitAnimation();
    }
    
    public void GoNextScene()
    {
        TransitionTo(nextSceneName, message);
    }
    
    private void TransitionTo(string sceneName, string msg)
    {
        Sequence seq = DOTween.Sequence();
        
        transitionText.text = msg;
        transitionText.rectTransform.anchoredPosition = new Vector2(0, -200f);
        transitionText.alpha = 0f;
        
        seq.Append(panels[0].DOAnchorPos(Vector2.zero, duration).SetEase(Ease.OutExpo));
        seq.Join(transitionText.DOFade(1f, duration * 0.8f));
        seq.Join(transitionText.rectTransform.DOAnchorPos(Vector2.zero, duration).SetEase(Ease.OutBack));
        
        for (int i = 1; i < panels.Length; i++)
        {
            seq.Append(panels[i].DOAnchorPos(Vector2.zero, duration).SetEase(Ease.OutExpo));
            seq.AppendInterval(delay);
        }
        
        seq.AppendCallback(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
    
    private void PlayExitAnimation()
    {
        Sequence seq = DOTween.Sequence();

        for (int i = panels.Length - 1; i >= 0; i--)
        {
            RectTransform p = panels[i];
            if (i == panels.Length - 1)
            {
                seq.Append(p.DOAnchorPos(new Vector2(Screen.width, 0), duration).SetEase(Ease.InBack));
                seq.Join(transitionText.DOFade(0f, duration * 0.8f));
                seq.Join(transitionText.rectTransform.DOAnchorPos(new Vector2(0, 200f), duration).SetEase(Ease.InBack));
            }
            else
            {
                seq.Append(p.DOAnchorPos(new Vector2(Screen.width, 0), duration).SetEase(Ease.InBack));
            }
            seq.AppendInterval(delay);
        }
    }
}
