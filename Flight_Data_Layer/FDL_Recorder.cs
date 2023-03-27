

using System.Timers;
using FDL_Enums;

public class FDL_Recorder
{
    private static List<FlightDataSample> flightData = new List<FlightDataSample>();
    private static System.Timers.Timer mAcquisitionTimer = new System.Timers.Timer();
    private static System.Timers.Timer mSimConnectionTimer = new System.Timers.Timer();
    private static SAL_DataHandler mSimDataHandler = new SAL_DataHandler();

    private static FlightSimConnection mSimConnection = FlightSimConnection.SIM_DISCONNECTED;
    private static FlightTrackerStatus mTrackerStatus = FlightTrackerStatus.FLIGHT_NOT_TRACKED;

    public FDL_Recorder()
    {
        mSimDataHandler.startPollingSALHandlers();

        mSimConnectionTimer.Interval = 1000;
        mSimConnectionTimer.Elapsed += new ElapsedEventHandler(getFlightSimConnectionStatus);
        mSimConnectionTimer.Start();

        mAcquisitionTimer.Interval = 5000;
        mAcquisitionTimer.Elapsed += new ElapsedEventHandler(getFlightData);
    }

    public void startAcquiringData()
    {
        flightData = new List<FlightDataSample>();
        mAcquisitionTimer.Start();
    }

    public void stopAcquiringData()
    {
        mAcquisitionTimer.Stop();
    }

    public FlightSimConnection getSimConnection()
    {
        return mSimConnection;
    }

    public FlightTrackerStatus getFlightTrackerStatus()
    {
        return mTrackerStatus;
    }

    private static void getFlightSimConnectionStatus(object o, ElapsedEventArgs e)
    {
        mSimConnection = mSimDataHandler.getSimConnectionStatus();
    }

    private static void getFlightData(object o, ElapsedEventArgs e)
    {
        if (mSimConnection == FlightSimConnection.SIM_CONNECTED)
        {
            FlightDataSample sample = mSimDataHandler.getFlightDataSample();
            flightData.Add(sample);
            mTrackerStatus = FlightTrackerStatus.FLIGHT_TRACKED;
        }
        else
        {
            mTrackerStatus = FlightTrackerStatus.FLIGHT_NOT_TRACKED;
        }
        return;
    }
}