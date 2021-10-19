using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    private Rigidbody enemyRB;
    
    private GameObject _playerController;

    [SerializeField] 
    private float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player");
        enemyRB = GetComponent<Rigidbody>();
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
            Destroy(gameObject);
        }
    }
}
