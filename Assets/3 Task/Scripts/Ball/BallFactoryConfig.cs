using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallFactoryConfig", menuName = "Factory/BallFactoryConfig")]
public class BallFactoryConfig : ScriptableObject
{
    [SerializeField] private List<Ball> ballCollection = new List<Ball>();

    public List<Ball> BallCollection => ballCollection;
}
