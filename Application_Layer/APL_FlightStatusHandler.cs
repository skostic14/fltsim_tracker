using APL_Enums;
using FDL_Enums;
using System.Timers;

public sealed class APL_FlightStatusHandler
{
    public FlightStatus flightStatus = FlightStatus.FLIGHT_NOT_STARTED;
    public SimConnection simConnection = SimConnection.SIM_DISCONNECTED;
    private FDL_ModeSelector mFdlModeSelector = new();
    private System.Timers.Timer mTimer = new System.Timers.Timer();

    public APL_FlightStatusHandler()
    {
        flightStatus = FlightStatus.FLIGHT_NOT_STARTED;
        simConnection = SimConnection.SIM_DISCONNECTED;

        mTimer.Interval = 1000;
        mTimer.Elapsed += updateFlightHandlerStatus;
        mTimer.Start();
    }

    private void updateFlightHandlerStatus(object o, ElapsedEventArgs e)
    {
        flightStatus = mFdlModeSelector.getFlightTrackerStatus();
        simConnection = mFdlModeSelector.getFlightSimConnectionStatus();
    }

    public void startFlight()
    {
        mFdlModeSelector.startFlightTracking();
    }

    public void stopFlight()
    {
        mFdlModeSelector.stopFlightTracking();
    }
}