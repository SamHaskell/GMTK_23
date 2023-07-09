using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //le plan
    //reinitialiser les clipes du audio
    //creer des functions pour lancer les clipes
    //
    // Start is called before the first frame update
    public static AudioManager instance;
    private EventInstance iMusic, iClick;
    Bus masterBus, musicBus, sfxBus;

    private void Awake(){
        if(instance != null && instance != this){
            Destroy(this);
        }else {
            instance = this;
        }
        
        // musicBus = RuntimeManager.GetBus("bus:/Music");
        // sfxBus = RuntimeManager.GetBus("bus:/SFX");
        // musicBus = RuntimeManager.GetBus("bus:/Music");
    }
    void Start(){
        // FMODUnity.RuntimeManager.StudioSystem.getBankList(out FMOD.Studio.Bank[] loadedBanks);
        // foreach (FMOD.Studio.Bank bank in loadedBanks)
        // {
        //     bank.getPath(out string path);     
        // }
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/");
        if(SceneManager.GetActiveScene().buildIndex != 0){ // you have to use the loading scene in the final build or it wont play audio!!!
            PlayMusicLoop(true);
            PlaySound("start"); // add a coroutine so the music starts AFTER the startup sound
        }
    }
    public void SetVolume(float vol, string op) {
        // masterBus.setVolume(vol);
        switch (op) {
            case ("music"):
                iMusic.setVolume(vol);
                break;
            case ("sfx"): //this is for the master not just sfx cause there is no sfx bus
                masterBus.setVolume(vol);
                break;
        }
    }
    public void PlayMusicLoop(bool st){
        switch (st) {
            case true:
                iMusic = RuntimeManager.CreateInstance("event:/Music");
                iMusic.start();
                break;
            case false:
                iMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                // iMusic.setVolume(Mathf.Lerp(iMusic.getVolume(), 0.0f, Time.del))
                break;
        }

    }
    public void PlaySound(string s) {
        // if a sound overlaps itself too much, tell andrew ok i will
        switch (s) {
            case "throw":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Throw");
                break;
            case "click":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Click");
                break;
            case "success":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Chord");
                break;
            case "incorrect":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Minor Failure");
                break;
            case "game over":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Major Failure");
                break;
            case "start":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Major Failure");
                break;
            case "explosion":
                // FMODUnity.RuntimeManager.PlayOneShot("event:/Major Failure");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
