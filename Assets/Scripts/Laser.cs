using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Laser : MonoBehaviour
{
    [SerializeField] 
    private float distance = 100f;

    [SerializeField] 
    private float lifeTime = 2f;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    public void Draw()
    {
        _lineRenderer.enabled = true;

        StartCoroutine(UpdateLaserCoroutine(lifeTime));
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
    }

    private void DisableLaser()
    {
        _lineRenderer.enabled = false;
        ObjectPooler.Instance.ReturnToPool(gameObject);
    }

    private IEnumerator UpdateLaserCoroutine(float timer)
    {
        while (timer >= Time.deltaTime)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit. collider)
                {
                    _lineRenderer.SetPosition(1, hit.point);
                    
                    if ((hit.collider.CompareTag("Asteroid") || hit.collider.CompareTag("Enemy")) 
                        && hit.collider.transform.position. z <= GameManager.Instance.BorderZ
                        && hit.collider.transform.position. z >= -GameManager.Instance.BorderZ
                        && hit.collider.transform.position. z <= GameManager.Instance.BorderX
                        && hit.collider.transform.position. z >= -GameManager.Instance.BorderX)
                    {
                        hit.collider.GetComponent<EnemyHealth>().Die();
                    }
                }
            }
            else _lineRenderer.SetPosition(1, transform.forward * distance);

            timer -= Time.deltaTime;
            yield return null;
        }
        
        DisableLaser();
        
    }
    
    
}
