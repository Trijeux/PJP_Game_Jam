// Script by : Hugo
// Porject : PJPJam


using UnityEngine;

public class SpikeHeadAnimation : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 6f;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private Transform spawnPoint;
    private Vector3 originalPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetBool("Is_rushing", false);
        
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Is_rushing"))
        {
            transform.localPosition += Vector3.down * (Time.deltaTime * speed);
        }
        else if(transform.localPosition.y < originalPosition.y)
        {
            transform.localPosition += Vector3.up * (Time.deltaTime * speed / 2);
        }
        else
        {
            transform.localPosition = originalPosition;
            animator.SetBool("Is_rushing", false);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && transform.localPosition == originalPosition)
        {
            animator.SetBool("Is_rushing", true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DeadSound();
            other.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y);
        }
        animator.SetBool("Is_rushing", false);
        _audioSource.Play();
    }
    
}
