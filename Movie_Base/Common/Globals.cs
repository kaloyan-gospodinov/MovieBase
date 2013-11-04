using System;
using System.Linq;

namespace Movie_Base.Common
{
    public static class Globals
    {
        // STEP 1. ADD YOUR DEV KEY HERE
        public static string ROTTEN_TOMATOES_API_KEY = @"apikey=s6k62d4zdqbr3tetvar6meqm";

        public static string ROTTEN_TOMATOES_API_MOVIES_INTHEATERS = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?page_limit=10&page=1&country=us&" + ROTTEN_TOMATOES_API_KEY;
       
    }
}
