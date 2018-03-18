using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Annotations;
using OxyPlot.Series;

namespace AircraftPlotingPeak
{
    class AirPlane
    {
        public int OrderNr;
        public string ACRegNo;
        public List<Flight> listArrival;
        public List<Flight> listDeparture;
        public List<Flight> mixedFlightList;

        public AirPlane(string ACRegNo)
        {
            this.OrderNr = 0;
            this.ACRegNo = ACRegNo;
            this.listArrival = new List<Flight>();
            this.listDeparture = new List<Flight>();
            this.mixedFlightList = new List<Flight>();
        }

        public int cnt_all_flights_at_minuteTH(int min_th)
        {
            int cnt = 0;
            foreach(Flight f in this.mixedFlightList)
            {
                if(f.arrival_time<=min_th && min_th <= f.departure_time)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public int cnt_intl_flights_at_minuteTH(int min_th)
        {
            int cnt = 0;
            foreach (Flight f in this.mixedFlightList)
            {
                if (f.arrival_time <= min_th && min_th <= f.departure_time && !f.is_domestic)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public int cnt_domestic_flights_at_minuteTH(int min_th)
        {
            int cnt = 0;
            foreach (Flight f in this.mixedFlightList)
            {
                if (f.arrival_time <= min_th && min_th <= f.departure_time && f.is_domestic)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public void plot_all_flights(PlotModel plot_model)
        {
            foreach (Flight f in this.mixedFlightList)
            {
                
                var pointAnnotation1 = new PointAnnotation();
                pointAnnotation1.X = Convert.ToDouble(f.arrival_time);
                pointAnnotation1.Y = Convert.ToDouble(this.OrderNr);
                pointAnnotation1.Text = f.arrival_from;
                plot_model.Annotations.Add(pointAnnotation1);

                var pointAnnotation2 = new PointAnnotation();
                pointAnnotation2.X = Convert.ToDouble(f.departure_time);
                pointAnnotation2.Y = Convert.ToDouble(this.OrderNr);
                pointAnnotation2.Text = f.departure_to;
                plot_model.Annotations.Add(pointAnnotation2);

                var pAnnoAcReg = new PointAnnotation();
                pAnnoAcReg.X = (Convert.ToDouble(f.arrival_time) + Convert.ToDouble(f.departure_time))/2;
                pAnnoAcReg.Y = Convert.ToDouble(this.OrderNr+1);
                pAnnoAcReg.Text = this.ACRegNo;
                pAnnoAcReg.Size = 0.1;
                plot_model.Annotations.Add(pAnnoAcReg);

                DataPoint d1 = new DataPoint(DateTimeAxis.ToDouble(f.arrival_time), this.OrderNr);
                DataPoint d2 = new DataPoint(DateTimeAxis.ToDouble(f.departure_time), this.OrderNr);

                var linePoints = new[]{d1, d2};
                var lineSeries = new LineSeries{
                    StrokeThickness = 2,
                    ItemsSource = linePoints
                };
                plot_model.Series.Add(lineSeries);
            }
        }

        public void plot_domestic_flights(PlotModel plot_model)
        {
            foreach (Flight f in this.mixedFlightList)
            {
                if (!f.is_domestic) continue;

                var pointAnnotation1 = new PointAnnotation();
                pointAnnotation1.X = Convert.ToDouble(f.arrival_time);
                pointAnnotation1.Y = Convert.ToDouble(this.OrderNr);
                pointAnnotation1.Text = f.arrival_from;
                plot_model.Annotations.Add(pointAnnotation1);

                var pointAnnotation2 = new PointAnnotation();
                pointAnnotation2.X = Convert.ToDouble(f.departure_time);
                pointAnnotation2.Y = Convert.ToDouble(this.OrderNr);
                pointAnnotation2.Text = f.departure_to;
                plot_model.Annotations.Add(pointAnnotation2);

                var pAnnoAcReg = new PointAnnotation();
                pAnnoAcReg.X = (Convert.ToDouble(f.arrival_time) + Convert.ToDouble(f.departure_time)) / 2;
                pAnnoAcReg.Y = Convert.ToDouble(this.OrderNr + 1);
                pAnnoAcReg.Text = this.ACRegNo;
                pAnnoAcReg.Size = 0.1;
                plot_model.Annotations.Add(pAnnoAcReg);

                DataPoint d1 = new DataPoint(DateTimeAxis.ToDouble(f.arrival_time), this.OrderNr);
                DataPoint d2 = new DataPoint(DateTimeAxis.ToDouble(f.departure_time), this.OrderNr);

                var linePoints = new[] { d1, d2 };
                var lineSeries = new LineSeries
                {
                    StrokeThickness = 2,
                    ItemsSource = linePoints
                };
                plot_model.Series.Add(lineSeries);
            }
        }

        public void plot_intl_flights(PlotModel plot_model)
        {
            foreach (Flight f in this.mixedFlightList)
            {
                if (f.is_domestic) continue;
                var pointAnnotation1 = new PointAnnotation();
                pointAnnotation1.X = Convert.ToDouble(f.arrival_time);
                pointAnnotation1.Y = Convert.ToDouble(this.OrderNr);
                pointAnnotation1.Text = f.arrival_from;
                plot_model.Annotations.Add(pointAnnotation1);

                var pointAnnotation2 = new PointAnnotation();
                pointAnnotation2.X = Convert.ToDouble(f.departure_time);
                pointAnnotation2.Y = Convert.ToDouble(this.OrderNr);
                pointAnnotation2.Text = f.departure_to;
                plot_model.Annotations.Add(pointAnnotation2);

                var pAnnoAcReg = new PointAnnotation();
                pAnnoAcReg.X = (Convert.ToDouble(f.arrival_time) + Convert.ToDouble(f.departure_time)) / 2;
                pAnnoAcReg.Y = Convert.ToDouble(this.OrderNr + 1);
                pAnnoAcReg.Text = this.ACRegNo;
                pAnnoAcReg.Size = 0.1;
                plot_model.Annotations.Add(pAnnoAcReg);

                DataPoint d1 = new DataPoint(DateTimeAxis.ToDouble(f.arrival_time), this.OrderNr);
                DataPoint d2 = new DataPoint(DateTimeAxis.ToDouble(f.departure_time), this.OrderNr);

                var linePoints = new[] { d1, d2 };
                var lineSeries = new LineSeries
                {
                    StrokeThickness = 2,
                    ItemsSource = linePoints
                };
                plot_model.Series.Add(lineSeries);
            }
        }

        public void resolve_domestic_flights()
        {
            string[] IATA_Domestic_Code = { "VCS", "UIH", "CAH", "VCA", "BMV", "DAD", "DIN", "PXU", "HPH", "HAN", "SGN", "CXR", "VKG", "PQC", "DLI", "VII" };
            // for each flight in Mixed, if arr and dep belong to IATA_Domestic_Code, just mark it as Domestic
            foreach (Flight f in this.mixedFlightList)
            {
                if (IATA_Domestic_Code.Contains(f.arrival_from) && IATA_Domestic_Code.Contains(f.departure_to))
                {
                    f.is_domestic = true;
                }

                if (f.arrival_from.Equals("P. DAY") && IATA_Domestic_Code.Contains(f.departure_to))
                {
                    f.is_domestic = true;
                }

                if (IATA_Domestic_Code.Contains(f.arrival_from) && f.departure_to.Equals("NEXT DAY"))
                {
                    f.is_domestic = true;
                }
            }
        }

        public void resolve_mixedFlights(int min_time, int max_time)
        {
            List<Flight> ListFlightsArrival = listArrival.OrderBy(o => o.arrival_time).ToList();
            List<Flight> ListFlightsDeparture = listDeparture.OrderBy(o => o.departure_time).ToList();

            

            //for each Arrival, match with nearest departure, checked
            foreach (Flight fa in ListFlightsArrival)
            {
                
                foreach(Flight fd in ListFlightsDeparture)
                {
                    if(fa.arrival_time < fd.departure_time && !fd.is_checked)
                    {
                        Flight flight_mixed = new Flight();
                        fd.is_checked = true;
                        flight_mixed.arrival_from = fa.arrival_from;
                        flight_mixed.departure_to = fd.departure_to;
                        flight_mixed.arrival_time = fa.arrival_time;
                        flight_mixed.departure_time = fd.departure_time;

                        flight_mixed.is_next_day_arr = fa.is_next_day_arr;
                        flight_mixed.is_next_day_dep = fd.is_next_day_dep;

                        this.mixedFlightList.Add(flight_mixed);
                        fa.is_checked = true;
                        break;
                    }
                }
            }

            //Flights from previous day
            foreach(Flight fd in ListFlightsDeparture)
            {
                if (!fd.is_checked)
                {
                    Flight flight_mixed = new Flight();
                    flight_mixed.arrival_from = "P. DAY";
                    flight_mixed.departure_to = fd.departure_to;
                    flight_mixed.arrival_time = min_time;
                    flight_mixed.departure_time = fd.departure_time;
                    flight_mixed.is_next_day_arr = false;
                    flight_mixed.is_next_day_dep = fd.is_next_day_dep;
                    fd.is_checked = true;
                    this.mixedFlightList.Add(flight_mixed);
                }
            }

            //Flights will departure tomorrow
            foreach (Flight fa in ListFlightsArrival)
            {
                if (!fa.is_checked)
                {
                    Flight flight_mixed = new Flight();
                    flight_mixed.arrival_from = fa.arrival_from;
                    flight_mixed.departure_to = "NEXT DAY";
                    flight_mixed.arrival_time = fa.arrival_time;
                    flight_mixed.departure_time = max_time;
                    flight_mixed.is_next_day_arr = fa.is_next_day_arr;
                    flight_mixed.is_next_day_dep = true;
                    fa.is_checked = true;
                    this.mixedFlightList.Add(flight_mixed);
                }
            }
            
        }

        public void printItSelfMIXED()
        {
            Console.WriteLine("AirCraft no "+ ACRegNo);
            foreach(Flight f in mixedFlightList)
            {
                f.print_debug();
            }
        }
    }
}
