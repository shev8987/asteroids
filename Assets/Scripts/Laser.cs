using System.Collections;
using UnityEngine;

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

    private void OnEnable()
    {
        _lineRenderer.enabled = true;
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            _lineRenderer.SetPosition(0, transform.position);
            StartCoroutine(UpdateLaserCoroutine(lifeTime));
        }

        if (Input.GetButtonUp("Fire2"))
        {
            DisableLaser();
        }
    }
    
    private void DisableLaser()
    {
        _lineRenderer.enabled = false;
        ObjectPooler.Instance.ReturnToPool(gameObject);
    }

    private IEnumerator UpdateLaserCoroutine(float timer)
    {
        if (timer <= 0)
        {
            DisableLaser();
        }
        while (timer >= Time.deltaTime)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit. collider)
                {
                    _lineRenderer.SetPosition(1, hit.point);
                    
                    if (hit.collider.CompareTag("Asteroid") || hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.GetComponent<EnemyHealth>().Die();
                    }
                }
            }
            else _lineRenderer.SetPosition(1, transform.forward*5000);

            timer -= Time.deltaTime;
            yield return null;
        }
    }
    
    
}
