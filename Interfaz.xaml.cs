﻿using System;
using System.Windows;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using STARK.Properties;

namespace STARK
{
    public partial class Interfaz : Window
    {
        
        RecoStart start = new RecoStart();
        EditorCmd EditorCmd;
        //CalculadoraCientifica Mates;
        Ajustes Ajustes;
        Notificaciones Notif;
        Alarma Alarma;
        ComandosSistema csis;
        Gramaticas gramaticas = new Gramaticas();
        CargarGramaticas loadgramaticas = new CargarGramaticas();

        public Interfaz()
        {
            InitializeComponent();
            start.asistente.SpeakAsync("Inicial-izando el Asistente Virtual. .Cargando las gramáticas y conectándose al satélite. .Núcleo cargado y al 100% de energía señor.");
            CargarDatosIniciales();
        }

        void CargarDatosIniciales()
        {
            start.asistente.SelectVoice(Settings.Default.VozDefault);
            start.asistente.Volume = Settings.Default.VolumenIA;
            CargarDatosGramaticas();
            DesactivarMicrófono();
            IdiomaEspañol();
            Process.GetCurrentProcess().MaxWorkingSet = Process.GetCurrentProcess().MinWorkingSet;
        }

        void CargarDatosGramaticas()
        {
            loadgramaticas.SeleccionarComandos();
            start.usuario.LoadGrammarAsync(new Grammar(loadgramaticas.ComandosInternos())); //todo esto tiene la información de los comandos internos
            start.usuario.LoadGrammarAsync(new Grammar(loadgramaticas.CargarGramáticasCalc())); //Carga las gramaticas de la calculadora
            start.usuario.LoadGrammarAsync(new Grammar(new Choices(loadgramaticas.CargarGramáticasBD()))); //Carga las gramaticas del usuario
            start.usuario.LoadGrammarAsync(new Grammar(new Choices(Settings.Default.NombreAsistente)));// Esto se eliminará en un futuro, pero carga el nombre del asistente
            start.usuario.LoadGrammarAsync(loadgramaticas.CargarGramáticasWebs());//hasta aquí carga todas las gramáticas
            start.usuario.RequestRecognizerUpdate();
            start.usuario.SpeechRecognized += usuario_SpeechRecognized;
            start.asistente.SpeakStarted += asistente_SpeakStarted;
            start.asistente.SpeakCompleted += asistente_SpeakCompleted;
            start.usuario.SetInputToDefaultAudioDevice();
            start.usuario.RecognizeAsync(RecognizeMode.Multiple);
            start.tiempo_desactivar_microfono.Tick += Tiempo_desactivar_microfono_Tick;
            start.liberarRAM.Tick += LiberarRAM_Tick;
            start.liberarRAM.Start();
        }

        private void LiberarRAM_Tick(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().MaxWorkingSet = Process.GetCurrentProcess().MinWorkingSet;
        }

        void DesactivarMicrófono()
        {
            Settings.Default.On_Off_Micro = false;
            Settings.Default.Save();
        }

        void Activo(string speech)
        {
            Random rnd = new Random();
            if (speech.Equals("Activar el micrófono"))
            {
                Settings.Default.On_Off_Micro = true;
                Settings.Default.Save();
            }
            else if (speech.Equals(Settings.Default.NombreAsistente))
            {
                int numran = rnd.Next(1, 5);
                start.on_mic.Play();
                switch (numran)
                {
                    case 1:
                        start.asistente.SpeakAsync("Si " + Properties.Settings.Default.NombreUsuario + ". . . .");
                        break;
                    case 2:
                        start.asistente.SpeakAsync("A sus órdenes " + Properties.Settings.Default.NombreUsuario + ". . . .");
                        break;
                    case 3:
                        start.asistente.SpeakAsync("En qué puedo ayudarle " + Properties.Settings.Default.NombreUsuario + ". . . .");
                        break;
                    case 4:
                        start.asistente.SpeakAsync("Diga " + Properties.Settings.Default.NombreUsuario + ". . . .");
                        break;
                    case 5:
                        start.asistente.SpeakAsync("Esperando instrucciones " + Properties.Settings.Default.NombreUsuario + ". . . .");
                        break;
                }
                Settings.Default.On_Off_Micro = true;
                Settings.Default.Save();

                //Actualizar Gramaticas
                loadgramaticas.SeleccionarComandos();
                start.usuario.LoadGrammarAsync(new Grammar(loadgramaticas.ComandosInternos())); //todo esto tiene la información de los comandos internos
                start.usuario.LoadGrammarAsync(new Grammar(loadgramaticas.CargarGramáticasCalc())); //Carga las gramaticas de la calculadora
                start.usuario.LoadGrammarAsync(new Grammar(new Choices(loadgramaticas.CargarGramáticasBD()))); //Carga las gramaticas del usuario
                start.usuario.LoadGrammarAsync(new Grammar(new Choices(Settings.Default.NombreAsistente)));// Esto se eliminará en un futuro, pero carga el nombre del asistente
                start.usuario.LoadGrammarAsync(loadgramaticas.CargarGramáticasWebs());//hasta aquí carga todas las gramáticas
            }
            else if (speech == "Desactivar el micrófono" || speech.Equals("Desactivar micrófono"))
            {
                DesactivarMicrófono();
                start.tiempo_desactivar_microfono.Stop();
                start.tiempo = 0;
                start.off_mic.Play();
            }
        }

        private void IdiomaEspañol()
        {
            btnAjustes.ToolTip = "Ajustes";
            btnAlarma.ToolTip = "Alarma";
            btnComandos.ToolTip = "Comandos";
            btnNotificaciones.ToolTip = "Notificaciones";
        }

        private void asistente_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            start.habilitarReconocimiento = false;
            start.tiempo = 0;
        }

        private void asistente_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            start.habilitarReconocimiento = true;
            start.tiempo = 0;
            start.tiempo_desactivar_microfono.Start();
        }

        private void Tiempo_desactivar_microfono_Tick(object sender, EventArgs e)
        {
            start.tiempo++;
            if (start.tiempo.Equals(Settings.Default.OffMicro))
            {
                start.off_mic.Play();
                DesactivarMicrófono();
                start.tiempo_desactivar_microfono.Stop();
                start.tiempo = 0;
            }
        }

        private void usuario_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            start.recogResult = e.Result;
            start.speech = e.Result.Text;
            Activo(start.speech);

            if(Settings.Default.On_Off_Micro == true)
            {

                if (e.Result.Confidence >= Settings.Default.ConfidenciaUsuario)
                {
                    if (start.habilitarReconocimiento == true)
                    {
                        string ejecutarcmdBD = gramaticas.EjecutarComandosBD(start.speech); // ay que reparlo
                        string ejecutarcmdInternos = gramaticas.SinonimoCmd(start.speech);
                        string calculadora = gramaticas.Calc(start.recogResult);
                        string buscador = gramaticas.Busc(start.recogResult, start.speech);
                        if (ejecutarcmdBD != string.Empty)
                        {
                            start.asistente.SpeakAsync(ejecutarcmdBD + "          ."); // ay que reparlo
                        }
                        if (ejecutarcmdInternos != string.Empty)
                        {
                            if (ejecutarcmdInternos == "Abriendo configuraciones del sistema")
                            {
                                if (Ajustes == null)
                                {
                                    Ajustes = new Ajustes();
                                    Ajustes.Show();
                                    Ajustes.Closed += delegate (object a, EventArgs b)
                                    {
                                        Ajustes = null;
                                    };
                                }
                            }
                            else if (ejecutarcmdInternos == "Abriendo el editor de comandos")
                            {
                                EditorCmd cmd = new EditorCmd();
                                cmd.Show();
                            }
                            else if (ejecutarcmdInternos == "Hasta pronto")
                            {
                                start.asistente.Speak(ejecutarcmdInternos + Properties.Settings.Default.NombreUsuario);
                                Application.Current.Shutdown();
                            }
                            else if (ejecutarcmdInternos == "Minimizado")
                            {
                                Visibility = Visibility.Hidden;
                            }
                            else if (ejecutarcmdInternos == "Mostrado")
                            {
                                Visibility = Visibility.Visible;
                            }
                            else if (ejecutarcmdInternos == "Mostrando todos los comandos")
                            {
                                csis = new ComandosSistema();
                                csis.Show();

                            }
                            start.asistente.SpeakAsync(ejecutarcmdInternos + "         .");
                        }
                        if (calculadora != string.Empty)
                        {
                            start.asistente.SpeakAsync(calculadora + "         .");
                        }
                        if (buscador != string.Empty)
                        {
                            start.asistente.SpeakAsync(buscador + "          .");
                        }
                    }
                }
            }
        }

        private void btnComandos_Click(object sender, RoutedEventArgs e)
        {
            if (EditorCmd == null)
            {
                EditorCmd = new EditorCmd();
                EditorCmd.Show();
                EditorCmd.Closed += delegate (object a, EventArgs b)
                {
                    EditorCmd = null;
                };
            }
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            if (Ajustes == null)
            {
                Ajustes = new Ajustes();
                Ajustes.Show();
                Ajustes.Closed += delegate (object a, EventArgs b)
                {
                    Ajustes = null;
                };
            }
        }

        private void btnNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            if (Notif == null)
            {
                Notif = new Notificaciones();
                Notif.Show();
                Notif.Closed += delegate (object a, EventArgs b)
                {
                    Notif = null;
                };
            }
        }

        private void btnAlarma_Click(object sender, RoutedEventArgs e)
        {
            if (Alarma == null)
            {
                Alarma = new Alarma();
                Alarma.Show();
                Alarma.Closed += delegate (object a, EventArgs b)
                {
                    Alarma = null;
                };
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}