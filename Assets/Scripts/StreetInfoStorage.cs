using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName ="Streets/Storage")]
public class StreetInfoStorage : ScriptableObject
{
    [SerializeField] private StreetInfo[] _streets;

    public StreetInfo GetByName(string name) => _streets.SingleOrDefault(s => s.Name == name);
}
