using StarsV2.Interfaces;
using System;
using System.Media;

namespace StarsV2
{
    internal class GameSound : IGameSound
    {
        SoundPlayer back;
        SoundPlayer shoot;
        SoundPlayer lose;

        public GameSound()
        {
            back = new SoundPlayer(Environment.CurrentDirectory + "/Music/musiclvl2.wav");
            shoot = new SoundPlayer(Environment.CurrentDirectory + "/Music/shoot.wav");
            lose = new SoundPlayer(Environment.CurrentDirectory + "/Music/Lose1.wav");
            back.Load();
            shoot.Load();
            lose.Load();
        }

        public void PlayLose()
        {
            lose.Play();
        }

        public void ShootPlay()
        {
            shoot.Play();
        }

        public void StartBackground()
        {
            back.PlayLooping();
        }

        public void StopBackground()
        {
            back.Stop();
        }
    }
}