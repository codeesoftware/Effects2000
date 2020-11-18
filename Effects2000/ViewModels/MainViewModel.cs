using Effects2000.Utils;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace Effects2000.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        public ParameterDelegateCommand<string> YesCommand { get; private set; }

        Dictionary<string, string> sounds;
        protected override void Initlialize()
        {
            base.Initlialize();

            //player.Load();
            //player.Play();
            sounds = new Dictionary<string, string> { { "yes",Directory.GetCurrentDirectory()+ @"\Assets\yes.wav" } };
            YesCommand = new ParameterDelegateCommand<string>(() => true, Play);
        }

        //private void Yes()
        //{
        //    Play("yes");
        //}

        void Play(string soundName)
        {
            using (var player = new SoundPlayer(sounds[soundName.ToLower()]))
            {
                player.LoadAsync();
                player.Play();
            }
        }
    }
}
