using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AircraftPlotingPeak
{
    class MyDB
    {
        public Hashtable allAirCraft = new Hashtable();
        public int min_time = 99999, max_time = -1;


        public void printAll()
        {
            // Get a collection of the keys.
            ICollection key = allAirCraft.Keys;
            Console.WriteLine("WHAT TO WRITE");
            foreach (string k in key)
            {
                AirPlane p = (AirPlane)allAirCraft[k];
                Console.WriteLine(k + ": " + p.ACRegNo);
                foreach(Flight f in p.listArrival)
                {
                    f.print_debug();
                }
            }
        }

        public int cnt_all_flights_at_minuteTH(int min_th)
        {
            int cnt = 0;
            foreach(AirPlane ap in allAirCraft.Values)
            {
                cnt += ap.cnt_all_flights_at_minuteTH(min_th);
            }
            return cnt;
        }

        public int cnt_intl_flights_at_minuteTH(int min_th)
        {
            int cnt = 0;
            foreach (AirPlane ap in allAirCraft.Values)
            {
                cnt += ap.cnt_intl_flights_at_minuteTH(min_th);
            }
            return cnt;
        }

        public int cnt_domestic_flights_at_minuteTH(int min_th)
        {
            int cnt = 0;
            foreach (AirPlane ap in allAirCraft.Values)
            {
                cnt += ap.cnt_domestic_flights_at_minuteTH(min_th);
            }
            return cnt;
        }


    }
}
