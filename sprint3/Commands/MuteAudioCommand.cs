using CSE3902_Project.Audio;

namespace CSE3902_CSE3902_Project.Commands
{
    class MuteAudioCommand : ICommand
    {
        private AudioManager manager;
        bool muteStatus;
        public MuteAudioCommand(AudioManager audioManager)
        {
            this.manager = audioManager;
            muteStatus = false;
        }

        public void Execute()
        {
            muteStatus = !muteStatus;
            manager.Mute(muteStatus);
        }
    }
}
