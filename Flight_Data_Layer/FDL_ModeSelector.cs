using APL_Enums;
using FDL_Enums;
using System.Timers;

public class FDL_ModeSelector
{
    private FlightStatus mFlightStatus = FlightStatus.FLIGHT_NOT_STARTED;
    private SimConnection mSimConnection = SimConnection.SIM_DISCONNECTED;

    private FlightSimConnection mFlightSimConnection = FlightSimConnection.SIM_DISCONNECTED;
    private FlightTrackerStatus mFlightTrackerStatus = FlightTrackerStatus.FLIGHT_NOT_TRACKED;

    private FDL_Recorder mFdlRecorder = new FDL_Recorder();
    private System.Timers.Timer mTimer = new System.Timers.Timer();

    public FDL_ModeSelector() 
    {
        mFlightStatus = FlightStatus.FLIGHT_NOT_STARTED;
        mSimConnection = SimConnection.SIM_DISCONNECTED;

        mFlightSimConnection = FlightSimConnection.SIM_DISCONNECTED;
        mFlightTrackerStatus = FlightTrackerStatus.FLIGHT_NOT_TRACKED;

        mFdlRecorder.startAcquiringData();

        mTimer.Interval = 1000;
        mTimer.Elapsed += modeSelectorCyclic;
        mTimer.Start();
    }

    public FlightStatus getFlightTrackerStatus()
    {
        return mFlightStatus;
    }

    public SimConnection getFlightSimConnectionStatus()
    {
        return mSimConnection;
    }

    public void startFlightTracking()
    {
        if (mFlightSimConnection == FlightSimConnection.SIM_CONNECTED && mFlightTrackerStatus == FlightTrackerStatus.FLIGHT_TRACKED)
        {
            mFdlRecorder.startAcquiringData();
            mFlightStatus = FlightStatus.FLIGHT_STARTED;
        }
    }

    public void stopFlightTracking()
    {
        if (mFlightStatus == FlightStatus.FLIGHT_STARTED)
        {
            mFdlRecorder.stopAcquiringData();
            mFlightStatus = FlightStatus.FLIGHT_STOPPED;
            // TODO: Trigger sending to ACARS
        }
    }

    private void modeSelectorCyclic(object o, ElapsedEventArgs e)
    {
        mFlightTrackerStatus = mFdlRecorder.getFlightTrackerStatus();
        mFlightSimConnection = mFdlRecorder.getSimConnection();

        if (mFlightSimConnection == FlightSimConnection.SIM_CONNECTED)
        {
            mSimConnection = SimConnection.SIM_CONNECTED;
        }
        else
        {
            mSimConnection = SimConnection.SIM_DISCONNECTED;
        }
    }
}