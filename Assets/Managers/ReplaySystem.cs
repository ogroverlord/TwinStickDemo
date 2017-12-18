using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class ReplaySystem : MonoBehaviour
{

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager manager; 


    void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        manager = manager.GetComponent<GameManager>();
        rigidBody = GetComponent<Rigidbody>();
        Debug.Log(manager);
    }

    void Update()
    {
        if (manager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }
    
    void Record()
    {
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
      //  print("Recording frame:" + frame);
    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frameCount = 0;

        foreach (MyKeyFrame keyFrame in keyFrames)
        {
            if(keyFrame.Time > 0) {
                frameCount++; 
            }

        }
        int frame = Time.frameCount % frameCount;
        transform.position = keyFrames[frame].Position;
        transform.rotation = keyFrames[frame].Rotation;
        print("Playing frame:" + frame);
    }
}

    /// <summary>
    /// A structure for storing time, rotation and position
    /// </summary>
    public struct MyKeyFrame
    {
        public float Time
        {
            get;
            private set;
        }
        public Vector3 Position
        {
            get;
            private set;

        }
        public Quaternion Rotation
        {
            get;
            private set;
        }


        public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
        {
            this.Position = pos;
            this.Rotation = rot;
            this.Time = time;
        }
    }

