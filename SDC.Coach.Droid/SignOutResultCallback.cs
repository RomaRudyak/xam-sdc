using Java.Lang;
using Android.Gms.Common.Apis;

namespace SDC.Coach.Droid
{
    public class SignOutResultCallback : Object, IResultCallback
    {
        public MainActivity Activity { get; set; }

        public void OnResult(Object result)
        {
            Activity.UpdateUI(false);
        }
    }
}
