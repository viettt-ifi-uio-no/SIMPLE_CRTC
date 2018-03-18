using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftPlotingPeak
{
    class Flight
    {
        public string arrival_from;
        public string departure_to;
        public int arrival_time;
        public int departure_time;
        public bool is_next_day_arr = false;
        public bool is_next_day_dep = false;
        public bool is_checked = false;
        public bool is_domestic = false;

        public void print_debug()
        {
            int arr_min_tmp = this.arrival_time % 60;
            int arr_hour_tmp = this.arrival_time / 60;
            arr_hour_tmp = arr_hour_tmp % 24;
            int dep_min_tmp = this.departure_time % 60;
            int dep_hour_tmp = this.departure_time / 60;
            dep_hour_tmp = dep_hour_tmp % 24;

            Console.WriteLine("Arr: " + this.arrival_from + ", will depart to " + this.departure_to + ", arr_time: " + arr_hour_tmp + ":" + arr_min_tmp + ", dep_time: " + dep_hour_tmp + ":" + dep_min_tmp + ", next day arr: " + this.is_next_day_arr + ", next day dep: " + this.is_next_day_dep + " Domestic " + this.is_domestic);
        }

    }
}
