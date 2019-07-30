using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CleanVFX : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem ps;
    private IEnumerator lifeTimerCoroutine;
    private void OnEnable()
    {
        lifeTimerCoroutine = liveTimer();
        StartCoroutine(lifeTimerCoroutine);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }


    private IEnumerator liveTimer()
    {
        float lifeTime = ps.main.duration;
        yield return new WaitForSeconds(lifeTime);
        CleanVFXPool.Instance.ReturnToPool(this.gameObject);

    }
}
