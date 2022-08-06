﻿using System.Collections;
using UnityEngine;

namespace AurynSky.Dungeon_Pack.Scripts
{
    public class SpikeTrapDemo : MonoBehaviour {

        //This script goes on the SpikeTrap prefab;

        public Animator spikeTrapAnim; //Animator for the SpikeTrap;

        // Use this for initialization
        void Awake()
        {
            //get the Animator component from the trap;
            spikeTrapAnim = GetComponent<Animator>();
            //start opening and closing the trap for demo purposes;
            StartCoroutine(OpenCloseTrap());
        }


        IEnumerator OpenCloseTrap()
        {
            //play open animation;
            spikeTrapAnim.SetTrigger("open");
            //wait 2 seconds;
            yield return new WaitForSeconds(2);
            //play close animation;
            spikeTrapAnim.SetTrigger("close");
            //wait 2 seconds;
            yield return new WaitForSeconds(2);
            //Do it again;
            StartCoroutine(OpenCloseTrap());

        }
    }
}