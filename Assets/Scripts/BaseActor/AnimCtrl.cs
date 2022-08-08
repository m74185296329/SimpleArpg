using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrl : MonoBehaviour
{
    #region Sys funcs
    AnimatorManager AnimMgr;
    Animator _Anim;
    int _CurAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string CurAnimName;
    string AttackPre = "Base Layer.Atk";
    bool IsReady = true;
    public Animator Anim => (_Anim);
    private void Awake()
    {
        AnimMgr = gameObject.AddComponent<AnimatorManager>();

    }
    private void Start()
    {
        _Anim = GetComponent<Animator>();
        AnimMgr.OnStart(this);
    }
    private void Update()
    {
        UpdateSkillInput();
    }
    #endregion

    #region Cast Attack

    void UpdateSkillInput()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.K))
        {
            CastSkill();
        }
    }
#endif
    void CastSkill()
    {
        if (!IsReady)
            return;
        if(_CurAnimAttackIndex > MaxAnimAttackIndex)
        {
            _CurAnimAttackIndex = MinAnimAttackIndex;
        }
        CurAnimName = AttackPre + _CurAnimAttackIndex.ToString();
        AnimMgr.StartAnimation(CurAnimName,CastSkillReady, CastSkillBegin,CastSkillEnd);
    }

    void CastSkillReady()
    {
        IsReady = true;
    }

    void CastSkillBegin()
    {

        IsReady = false;

        _CurAnimAttackIndex++;
    }
    #endregion

    void CastSkillEnd()
    {
        _CurAnimAttackIndex = MinAnimAttackIndex;

        IsReady = true;
    }
}
