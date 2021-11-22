using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolGrades.API
{
    public sealed class Notification
    {
        private readonly IDictionary<string, IList<string>> _errorMessages = new Dictionary<string, IList<string>>();

        public IDictionary<string, string[]> ModelState
        {
            get
            {
                Dictionary<string, string[]> modelState = _errorMessages
                    .ToDictionary(item => item.Key, item => item.Value.ToArray());

                return modelState;
            }
        }

        public bool IsInvalid => _errorMessages.Count > 0;

        public void Add(string key, string message)
        {
            try
            {
                if (!_errorMessages.ContainsKey(key))
                {
                    _errorMessages[key] = new List<string>();
                }

                _errorMessages[key].Add(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}