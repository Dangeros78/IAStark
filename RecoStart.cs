using System;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Windows.Threading;
using System.Media;

namespace STARK
{
    public class RecoStart
    {
        public string NombreAsistente;
        public string NombreUsuario;
        public string _Speech;
        public string speech;
        public SpeechSynthesizer asistente;
        public SpeechRecognitionEngine usuario;
        public bool habilitarReconocimiento;
        public DispatcherTimer tiempo_desactivar_microfono;
        public DispatcherTimer liberarRAM;
        public RecognitionResult recogResult;
        public int tiempo;
        public SoundPlayer on_mic = new SoundPlayer(@"Assets\\Speech_On.wav");
        public SoundPlayer off_mic = new SoundPlayer(@"Assets\\Speech_Off.wav");
        public RecoStart()
        {
            LoadData();
            tiempo = 0;
            asistente = new SpeechSynthesizer();
            usuario = new SpeechRecognitionEngine();
            tiempo_desactivar_microfono = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            liberarRAM = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 1) };
        }

        private void LoadData()
        {
            
        }
    }
}