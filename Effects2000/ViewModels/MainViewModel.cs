using Effects2000.Utils;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;

namespace Effects2000.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        public ParameterDelegateCommand<string> YesCommand { get; private set; }
        public ParameterDelegateCommand<string> NoCommand { get; private set; }
        public ParameterDelegateCommand<string> WrongCommand { get; private set; }

        Dictionary<string, string> sounds;


        protected override void Initlialize()
        {
            base.Initlialize();
            
            sounds = new Dictionary<string, string> {
                { "yes",Directory.GetCurrentDirectory()+ @"\Assets\yes.wav" },
                { "no",Directory.GetCurrentDirectory()+ @"\Assets\no.wav" },
                { "correct",Directory.GetCurrentDirectory()+ @"\Assets\correct.wav" },
                { "wrong",Directory.GetCurrentDirectory()+ @"\Assets\wrong.wav" },
                { "laugh",Directory.GetCurrentDirectory()+ @"\Assets\laugh.wav" }
            };
            YesCommand = new ParameterDelegateCommand<string>(Play);
            NoCommand = new ParameterDelegateCommand<string>(Play);
            WrongCommand = new ParameterDelegateCommand<string>(Play);

        }


        void Play(string buttonText)
        {
            try
            {
                using (var player = new SoundPlayer(sounds[buttonText.ToLower()]))
                {
                    player.LoadAsync();
                    player.Play();
                }

            }
            catch (System.Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
