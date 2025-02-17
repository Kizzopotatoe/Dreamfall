using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BedTimeline : MonoBehaviour
{
    [SerializeField] private Bed bed;
    [SerializeField] private TimelineAsset bedTimeline_Sleep;
    [SerializeField] private TimelineAsset bedTimeline_Awake;

    private PlayableDirector timeline;
    private bool isAsleep = false;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        bed.OnBedAnimation += Bed_OnBedAnimation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isAsleep)
            {
                timeline.Play(bedTimeline_Awake);
                isAsleep = false;
            }
        }
    }

    private void Bed_OnBedAnimation(object sender, System.EventArgs e)
    {
        timeline.Play(bedTimeline_Sleep);
        isAsleep = true;
    }

}
