using UnityEngine;
using Spine.Unity;

public class SpineController : MonoBehaviour {
    private SkeletonAnimation characterAnimation;
    private Spine.AnimationState animState;

    void Awake()
    {
        characterAnimation = GetComponent<SkeletonAnimation>();
    }

    void Start()
    {
        animState = characterAnimation.AnimationState;

        // Quando uma animação termina, chama a função OnComplete
        animState.Complete += OnComplete;

        // Começa o ciclo pela primeira vez
        PlayCycle();
    }

    // Inicia a sequência: idle → idle → idle_break
    void PlayCycle()
    {
        animState.SetAnimation(0, "1.idle", false);
        animState.AddAnimation(0, "1.idle", false, 0);
        animState.AddAnimation(0, "1.idle_break", false, 0);
    }

    // Quando a última animação do track termina, reinicia o ciclo
    void OnComplete(Spine.TrackEntry trackEntry)
    {
        // Só reinicia quando terminar a idle_break
        if (trackEntry.Animation.Name == "1.idle_break")
        {
            PlayCycle();
        }
    }
}
