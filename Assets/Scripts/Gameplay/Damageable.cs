using UnityEngine;

[CreateAssetMenu (menuName = "Object Properties/Damageable")]
public class Damageable : ObjectProperty {

    public int damageAmount;

    public override void ActivateProperty (GameObject holder) {
        //holder.takeDamage(damageAmount);
        //part.health -= damageAmount;
        //ADAM - do whatever you need with damage, follow this template for properties you need
    }

}
