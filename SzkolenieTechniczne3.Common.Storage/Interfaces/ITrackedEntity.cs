using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.Common.Storage.Interfaces
{
    public interface ITrackedEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
        Guid CreatedByUserId { get; set; }
        Guid ModifiedByUserId { get; set; }
        
    }
}
