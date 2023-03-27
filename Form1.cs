namespace AirEvents
{
    public partial class Form1 : Form
    {
        private static APL_FlightStatusHandler mFlightStatusHandler = new APL_FlightStatusHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void startFlightBtn_Click(object sender, EventArgs e)
        {
            if (mFlightStatusHandler.flightStatus == APL_Enums.FlightStatus.FLIGHT_STARTED)
            {
                mFlightStatusHandler.stopFlight();
            }
            else
            {
                mFlightStatusHandler.startFlight();
            }
        }

        private void updateTextLabels()
        {
            switch (mFlightStatusHandler.simConnection)
            {
                case APL_Enums.SimConnection.SIM_DISCONNECTED:
                    simStatus.Text = "Sim disconnected";
                    startFlightBtn.Text = "Start Flight";
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
                    startFlightBtn.Text = "Start Flight";
                    break;
                case APL_Enums.FlightStatus.FLIGHT_STARTED:
                    flightStatus.Text = "Flight started";
                    startFlightBtn.Text = "Stop Flight";
                    break;
                case APL_Enums.FlightStatus.FLIGHT_STOPPED:
                    flightStatus.Text = "Flight stopped";
                    startFlightBtn.Text = "Start Flight";
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateTextLabels();
        }


    }
}