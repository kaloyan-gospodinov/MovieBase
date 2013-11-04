using System;
using System.Linq;

namespace Movie_Base.Services
{
    public delegate void EventHandler(object sender, Event e);

    public class InvokeApi
    {
        public event EventHandler OnResponse;

        async public void Invoke<T>(string apiCall)
        {
            var apiEvent = new Event();

            try
            {
                T response = await Map.LoadObject<T>(apiCall);
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