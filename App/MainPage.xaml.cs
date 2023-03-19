using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static APL_FlightStatusHandler mFlightStatusHandler = new APL_FlightStatusHandler();
        Timer mTimer = new Timer { Interval = 1000 };

        public MainPage()
        {
            this.InitializeComponent();
            updateTextLabels();
            mTimer.Enabled = true;
            mTimer.Elapsed += new ElapsedEventHandler(timerTick);
            mTimer.Start();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mFlightStatusHandler.connectSim();
            updateTextLabels();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mFlightStatusHandler.startFlight();
            updateTextLabels();
        }

        private void updateTextLabels()
        {
            switch (mFlightStatusHandler.simConnection)
            {
                case APL_Enums.SimConnection.SIM_DISCONNECTED:
                    simStatus.Text = "Sim disconnected";
                    break;
                case APL_Enums.SimConnection.SIM_CONNECTED:
                    simStatus.Text = "Sim Connected";
                    break;
                default:
                    break;
            }

            switch (mFlightStatusHandler.flightStatus)
            {
                case APL_Enums.FlightStatus.FLIGHT_NOT_STARTED:
                    flightStatus.Text = "Flight not started";
                    break;
                case APL_Enums.FlightStatus.FLIGHT_STARTED:
                    flightStatus.Text = "Flight started";
                    break;
                case APL_Enums.FlightStatus.FLIGHT_STOPPED:
                    flightStatus.Text = "Flight stopped";
                    break;
                default:
                    break;
            }
        }

        private void timerTick(object s, EventArgs e)
        {
        
        }
    }
}
