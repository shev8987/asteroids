using UnityEngine;
using Object = System.Object;

public class EnemyInput : MonoBehaviour
{
    [SerializeField] 
    private float speed = 1f;
    
    private GameObject _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController != null)
        {
            var lookDirection = (_playerController.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            ObjectPooler.Instance.ReturnToPool(gameObject);

        }
    }
}
