using System;
using System.Linq;

namespace Movie_Base.Services
{
    public class InvokeCompressed
    {
        public event EventHandler OnResponse;

        async public void Invoke<T>(string apiCall)
        {
            var apiEvent = new Event();

            try
            {
                T response = await Map.LoadCompressedObject<T>(apiCall);
                apiEvent.Object = response;
                apiEvent.Status = Status.SUCCESS;
                apiEvent.Message = string.Empty;
            }
            catch (Exception e)
            {
                apiEvent.Message = e.Message;
                apiEvent.Object = null;
                apiEvent.Status = Status.FAILURE;
            }

            OnResponse(this, apiEvent);
        }
    }
}
