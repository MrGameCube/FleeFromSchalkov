using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private List<int> _registeredHits = new List<int>();

    public int health = 100;
    public bool verbose = false;

    // Start is called before the first frame update
    void Start()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this._boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var contacts = new List<Collider2D>();
        this._boxCollider2D.GetContacts(contacts);

        foreach (var contact in contacts)
        {
            var id = contact.GetInstanceID();
            //TODO projektilen eigenes Script zuweisen und da drüber identifizieren
            if (contact.name.Contains("Projectile") && !this._registeredHits.Contains(id))
            {
                this._registeredHits.Add(id);
                this.health -= 1;
                if (health < 1)
                {
                    Destroy(gameObject);
                }
            }
            if (this.verbose)
            {
                Debug.Log(id);
                Debug.Log(contact.name);
                Debug.Log(contacts.Count);
            }
        }
    }
}
