using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private DustGenerator dustGenerator;
    // Start is called before the first frame update
    [SerializeField] private float power = 1.0f;

    private IEnumerator vacuumloop;

    private WaitForSeconds vacuumSensivity = new WaitForSeconds(0.1f);
    private bool powerOn = false;
    public bool PowerOn
    {
        get
        {
            return powerOn;
        }
        set
        {
            powerOn = value;
            if (powerOn)
                StartCoroutine(vacuumloop);
            else
                StopCoroutine(vacuumloop);
        }
    }

    void Awake()
    {
        vacuumloop = VacuumLoop();

    }
    private void Start()
    {
        //PowerOn = true;
    }

    private IEnumerator VacuumLoop()
    {
        while (true)
        {
            foreach (var dust in dustGenerator.AllDust.ToArray())
            {
                var distance = dust.transform.position - transform.position;
                if (distance.sqrMagnitude < power * power)
                {
                    // dust.gameObject.SetActive(false);
                    dustGenerator.AllDust.Remove(dust);
                    dust.GetComponent<Dust>().MoveToVacuum(this.transform);
                }
            }
            yield return vacuumSensivity;
        }

    }
}
