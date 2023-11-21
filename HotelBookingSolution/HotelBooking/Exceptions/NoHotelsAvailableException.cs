using System.Runtime.Serialization;

namespace HotelBooking.Exceptions
{
    public class NoHotelsAvailableException : Exception
    {
        string msg = "";
        public NoHotelsAvailableException()
        {
            msg = "No Hotels Available ";
        }
        public override string Message => msg;
    }
}