using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Exceptions;

namespace SzkolenieTechniczne3.Common.Storage
{
    public class PlatformDbContext : DbContext
    {
        private const uint VIOLATION_FOREIGN_KEY_REFERENCE_CONSTRAINTS = 547;
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception exception) when (exception.InnerException is SqlException sqlException
                                                && sqlException.Number == VIOLATION_FOREIGN_KEY_REFERENCE_CONSTRAINTS)
            {
                throw new ApiHttpException(StatusCodes.Status409Conflict);
            }
        }
    }
}
