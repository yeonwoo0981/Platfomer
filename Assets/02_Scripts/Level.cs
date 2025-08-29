using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // 허리 목 어깨 손목 조심!
    private int _totalCount;
    private List<Collected> _collecteds;
    [SerializeField] private End _end;
    [SerializeField] private CinemachineCamera _followCam, _endCam;
    [SerializeField] private Transform _startPos;
    

    private void Start()
    {
        Transform fruitTrm = transform.Find("Fruit");
        _collecteds = fruitTrm.GetComponentsInChildren<Collected>().ToList();
       _totalCount = _collecteds.Count;
       // 모든 과일의 이벤트를 구독 좋아요 알림설정까지.
       _collecteds.ForEach(collected => collected._onCollected += DecreaseCount);

       _followCam.Priority = 10;
       _endCam.Priority = 5;
    }

    public void DecreaseCount()
    {
        _totalCount--;

        if (_totalCount >= 0)
        {
            // 트로피 떨구기. 트떨.
            _endCam.Priority = 15;
            Debug.Log("트떨");

            Sequence seq = DOTween.Sequence();

            seq.AppendInterval(3f);
            seq.AppendCallback(() => _end.Show()); // 트등
            seq.AppendInterval(3f);
            seq.AppendCallback(() =>
            {
                _endCam.Priority = 5;
            });
        }
    }
    public void SetUpLevel(Player patient)
    {
        _followCam.Follow = patient.transform;

        patient.transform.position = _startPos.position;
    }
}
