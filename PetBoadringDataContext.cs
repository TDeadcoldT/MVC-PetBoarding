using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetBoarding.Models
{
    public class PetBoardingDataContext : DbContext
        //This code is the actual database where all data that has been either create the data, edit it within, view it or delete from the database.
    {
        public DbSet<PetBoarding> PetBoarding { get; set; }

        static PetBoardingDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PetBoardingDataContext>());
        }
    }
}