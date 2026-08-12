using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Services
{
    public class IncidentDetector
    {
        private Dictionary<string, int> _violations;
        private int _maxAttempts;

        public IncidentDetector(int maxAttempts)
        {
            _maxAttempts = maxAttempts;
            _violations = new Dictionary<string, int>();
        }

        public int MaxAttempts
        {
            get
            {
                return _maxAttempts;
            }
        }

        public void RecordViolation(string userId)
        {
            if(!_violations.ContainsKey(userId))
            {
                _violations[userId] = 0;
            }
            _violations[userId]++;
        }

        public bool ShouldLock(string userId)
        {
            return _violations.ContainsKey(userId) && _violations[userId] >= _maxAttempts;
        }

        public void Reset(string userId)
        {
            _violations.Remove(userId);

        }
    }
}
