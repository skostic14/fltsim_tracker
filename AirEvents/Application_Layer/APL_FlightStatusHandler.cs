using APL_Enums;

public sealed class APL_FlightStatusHandler
{
    public FlightStatus flightStatus = FlightStatus.FLIGHT_NOT_STARTED;
    public SimConnection simConnection = SimConnection.SIM_DISCONNECTED;

    public APL_FlightStatusHandler()
    {
        flightStatus = FlightStatus.FLIGHT_NOT_STARTED;
        simConnection = SimConnection.SIM_DISCONNECTED;
    }

    public void startFlight()
    {
        if (simConnection == SimConnection.SIM_CONNECTED && flightStatus != FlightStatus.FLIGHT_STARTED)
        {
            flightStatus = FlightStatus.FLIGHT_STARTED;
        }
    }

    public void stopFlight()
    {
        if (simConnection == SimConnection.SIM_CONNECTED && flightStatus == FlightStatus.FLIGHT_STARTED)
        {
            flightStatus = FlightStatus.FLIGHT_STOPPED;
        }
    }

    public void connectSim()
    {
        if (simConnection != SimConnection.SIM_CONNECTED)
        {
            simConnection = SimConnection.SIM_CONNECTED;
            flightStatus = FlightStatus.FLIGHT_NOT_STARTED;
        }
    }

    public void disconnectSim()
    {
        if (simConnection != SimConnection.SIM_DISCONNECTED)
        {
            simConnection = SimConnection.SIM_DISCONNECTED;
            flightStatus = FlightStatus.FLIGHT_NOT_STARTED;
        }
    }
}