using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Streets/Info")]
public class StreetInfo : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private string _subjectName;
    [SerializeField] private string _info;
    [SerializeField] private Sprite _heroSprite;
    [SerializeField] private Sprite _subjectSprite;

    
    public string Name => _name;
    public string SubjectName => _subjectName;
    public string Info => _info;
    public Sprite HeroSprite => _heroSprite;
    public Sprite SubjectSprite => _subjectSprite;
   
}