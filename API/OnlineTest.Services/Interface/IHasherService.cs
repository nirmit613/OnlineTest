using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.Interface
{
    public interface IHasherService
    {
        public string Hash(string input);
    }
}
