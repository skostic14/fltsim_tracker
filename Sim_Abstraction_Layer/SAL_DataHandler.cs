
using SAL_Enums;
using FDL_Enums;
using System.Timers;

public class SAL_DataHandler
{
    private static List<SimDataHandlers> mConnectedHandlers = new List<SimDataHandlers>();
    private static System.Timers.Timer mTimer = new System.Timers.Timer();
    private static SAL_FSUIPCHandler mFsUipcHandler = new SAL_FSUIPCHandler();
    private static FlightDataSample flightDataSample = new FlightDataSample();

    public SAL_DataHandler()
    {
        mTimer.Interval = 10000;
        mTimer.Elapsed += new ElapsedEventHandler(getHandlersConnectionStatus);
    }

    public void startPollingSALHandlers()
    {
        mConnectedHandlers.Clear();
        mTimer.Start();
    }

    public void stopPollingSALHandlers()
    {
        mTimer.Stop();
    }

    public FlightDataSample getFlightDataSample()
    {
        return flightDataSample;
    }

    public FlightSimConnection getSimConnectionStatus()
    {
        if (mConnectedHandlers.Count > 0)
        {
            return FlightSimConnection.SIM_CONNECTED;
        }
        else
        {
            return FlightSimConnection.SIM_DISCONNECTED;
        }
    }

    private static void getHandlersConnectionStatus(object o, ElapsedEventArgs e)
    {
        SimDataHandlerConnection fsUipcConnection = mFsUipcHandler.getConnectionStatus();

        if (fsUipcConnection == SimDataHandlerConnection.DISCONNECTED && mConnectedHandlers.Contains(SimDataHandlers.FSUIPC))
        {
            mConnectedHandlers.Remove(SimDataHandlers.FSUIPC);
        }
        else if (fsUipcConnection == SimDataHandlerConnection.CONNECTED && !mConnectedHandlers.Contains(SimDataHandlers.FSUIPC))
        {
            mConnectedHandlers.Add(SimDataHandlers.FSUIPC);
        }

        if (mConnectedHandlers.Contains(SimDataHandlers.FSUIPC))
        {
            flightDataSample = mFsUipcHandler.flightDataSample;
        }

        return;
    }
}