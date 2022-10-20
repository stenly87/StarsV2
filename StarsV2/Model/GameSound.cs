using StarsV2.Interfaces;
using System;
using System.Media;
using System.Windows.Media;

namespace StarsV2
{
    internal class GameSound : IGameSound
    {
        MediaPlayer back;
        SoundPlayer shoot;
        SoundPlayer lose;

        public GameSound()
        {
            back = new MediaPlayer();
            shoot = new SoundPlayer(Environment.CurrentDirectory + "/Music/shoot.wav");
            lose = new SoundPlayer(Environment.CurrentDirectory + "/Music/Lose1.wav");
            back.Open(new Uri(Environment.CurrentDirectory + "/Music/musiclvl2.wav"));
            shoot.Load();
            lose.Load();
            back.MediaEnded += Back_MediaEnded;
        }

        private void Back_MediaEnded(object sender, EventArgs e)
        {
            //back.Play();
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
            back.Play();
        }

        public void StopBackground()
        {
            back.Stop();
        }
    }
}