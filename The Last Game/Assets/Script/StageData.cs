using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // 부모클래스에ScriptableObject를 두고 Assat데이터로 사용이 가능하다
public class StageData : ScriptableObject // 공유 데이터를 저장할 수 있는 클래스 
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    public Vector2 LimitMin => limitMin; //대문자 LimitMin,Max는 외부클래스에서 접근 가능
    public Vector2 LimitMax => limitMax;
}
