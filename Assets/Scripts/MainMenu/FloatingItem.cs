using Assets.Scripts.Item.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Item.PortalGun
{
    class FloatingItem : MonoBehaviour
    {
        public float speed = 5f;
        public void Update()
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0) * Time.deltaTime);
        }
    }
}
