using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
   public static  class ApplicationState
    {
        private static Dictionary<string, object> _values =
              new Dictionary<string, object>();
        public static void SetValue(string key, object value)
        {
            if (_values.ContainsKey(key))
            {
                _values.Remove(key);
            }
            _values.Add(key, value);
        }
        public static MV_Pilot GetValue<MV_Pilot>(string key)
        {
            if (_values.ContainsKey(key))
            {
                return (MV_Pilot)_values[key];
            }
            else
            {
                return default(MV_Pilot);
            }
        }
    }
}
