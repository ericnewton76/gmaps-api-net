using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.ApiCore
{
    public interface ISigningService
    {
		Uri GetSignedUri(Uri value);
		
    }
}
