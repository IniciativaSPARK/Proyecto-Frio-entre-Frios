using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class Zombies : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField] float damage = 2f;
    private IObjectPool<Zombies> zombiesPool; 
    public void SetPool(IObjectPool<Zombies> pool)
    {
        zombiesPool = pool;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<scriptsJugador>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            scriptsJugador player = other.GetComponent<scriptsJugador>();
            player.TakeDamage(damage);
            zombiesPool.Release(this);

        }
    }

}
