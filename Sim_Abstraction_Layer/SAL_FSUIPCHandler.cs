using SAL_Enums;
using FSUIPC;
using System.Timers;

class SAL_FSUIPCHandler
{
    private SimDataHandlerConnection mConnection = SimDataHandlerConnection.DISCONNECTED;
    private System.Timers.Timer mTimer = new System.Timers.Timer();
    public FlightDataSample flightDataSample = new FlightDataSample();

    /* OFFSETS */
    private Offset<uint> airspeed = new Offset<uint>(0x02BC);
    private Offset<short> onGround = new Offset<short>(0x0366);
    private Offset<int> verticalSpeed = new Offset<int>(0x030C);
    private Offset<uint> avionicsMaster = new Offset<uint>(0x2E80);
    private Offset<string> model = new Offset<string>(0x3500, 24);
    //private Offset<FsLongitude> longitude = new Offset<FsLongitude>("LatLonPoint", 0x0568, 8);
    //private Offset<FsLatitude> latitude = new Offset<FsLatitude>("LatLonPoint", 0x0560, 8);

    private Offset<double> latitude = new Offset<double>(0x6010);
    private Offset<double> longitude = new Offset<double>(0x6018);

    private Offset<uint> altitude = new Offset<uint>(0x0020);

    public SAL_FSUIPCHandler()
    {
        mConnection = SimDataHandlerConnection.DISCONNECTED;
        mTimer.Interval = 1000;
        mTimer.Elapsed += getSimData;
    }

    public SimDataHandlerConnection getConnectionStatus() 
    {
        if (mConnection == SimDataHandlerConnection.DISCONNECTED)
        {
            try
            {
                FSUIPCConnection.Open();
                mConnection = SimDataHandlerConnection.CONNECTED;
                mTimer.Start();
            }
            catch
            {
                mConnection = SimDataHandlerConnection.DISCONNECTED;
                mTimer.Stop();
            }
        }   
        return mConnection;
    }

    private void getSimData(object o, ElapsedEventArgs a)
    {
        try
        {
            FSUIPCConnection.Process();
            flightDataSample = getFlightDataSample();
        }
        catch
        {
            mConnection = SimDataHandlerConnection.DISCONNECTED;
            mTimer.Stop();
        }
    }

    private double convert256mToFeet(double inValue)
    {
        return inValue / 256 * 3.28084d;
    }

    private FlightDataSample getFlightDataSample()
    {
        PayloadServices ps = FSUIPCConnection.PayloadServices;
        ps.RefreshData();

        FlightDataSample tempFlightDataSample = new FlightDataSample();
        FsLatLonPoint playerPos = new FsLatLonPoint(latitude.Value, longitude.Value);
        //tempFlightDataSample.latitude = latitude.Value.DecimalDegrees;
        //tempFlightDataSample.longitude = longitude.Value.DecimalDegrees;

        tempFlightDataSample.latitude = latitude.Value;
        tempFlightDataSample.longitude = longitude.Value;

        tempFlightDataSample.speed = airspeed.Value;
        tempFlightDataSample.altitude = convert256mToFeet(altitude.Value);
        tempFlightDataSample.verticalSpeed = convert256mToFeet(verticalSpeed.Value);
        tempFlightDataSample.onGround = (onGround.Value > 0) ? true : false;
        tempFlightDataSample.acType = model.Value;
        tempFlightDataSample.fuelOnBoard = ps.FuelWeightKgs;

        return tempFlightDataSample;
    }
}
