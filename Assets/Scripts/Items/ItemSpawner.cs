using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject _itemPrefab;
    public GameObject _spawnEffects;

    private float _spawnCooldown = 0;
    private GameObject _current;
    private bool _coolingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        _current = GameObject.Instantiate(_itemPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_current.transform.position);
        if ((_current.transform.position.x > transform.position.x + 0.1f
            || _current.transform.position.x < transform.position.x - 0.1f
            || _current.transform.position.z > transform.position.z + 0.1f
            || _current.transform.position.z < transform.position.z - 0.1f) && !_coolingDown)
        {
            _spawnCooldown = 2;
            _coolingDown = true;
        }

        if (_spawnCooldown > 0)
            _spawnCooldown -= 1 * Time.deltaTime;
        if (_coolingDown && _spawnCooldown <= 0)
        {
            _current = GameObject.Instantiate(_itemPrefab, transform.position, transform.rotation);
            GameObject.Instantiate(_spawnEffects, transform.position, transform.rotation);
            _coolingDown = false;
        }
    }
}
