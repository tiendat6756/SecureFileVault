using System;
using System.Collections.Generic;
using System.Text;

namespace SecureFileVault.Infrastructure
{
    public interface IRepository<T> 
    {
        List<T> Load();
        void Save(List<T> items);
    }
}
