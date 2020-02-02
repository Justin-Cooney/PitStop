using Assets.Scripts.Item.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Item.PortalGun
{
    class ScrollUV : MonoBehaviour
    {
        public float XParralax = 2f;
        public float YParralax = 4f;
        public void Update()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            var material = meshRenderer.material;
            var offset = material.mainTextureOffset;

            offset.x += Time.deltaTime / XParralax - new System.Random(2).Next(2) / 2;
            offset.y += Time.deltaTime / YParralax - new System.Random(2).Next(2) / 2;
                    
            material.mainTextureOffset = offset;
        }
    }
}
g