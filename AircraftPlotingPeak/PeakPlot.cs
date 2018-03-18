using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Collections;
using OxyPlot.Axes;
using OxyPlot.Annotations;

namespace AircraftPlotingPeak
{
    public partial class PeakPlot : Form
    {
        private OxyPlot.WindowsForms.PlotView plotFlights;
        private OxyPlot.WindowsForms.PlotView plotPeak;
        private MyDB allAircrafts = new MyDB();
        private string arrLink = null, depLink = null;
        public PeakPlot()
        {
            InitializeComponent();
            initialPlots();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 900);
            this.Name = "PEAK VISUALISATION";
            this.Text = "PEAK VISUALISATION";
            this.ResumeLayout(false);

        }

        private void btnLoadArrFile_Click(object sender, EventArgs e)
        {
            int unknown_cnt = 1;
            string selectedFileName = "";
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.Filter = "Excel files (*.xls,*.xlsl)|*.xls;*.xlsx";
            if (chooseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedFileName = chooseFile.FileName;
                arrLink = selectedFileName;
            }
            else return;

            Microsoft.Office.Interop.Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt;
            int rw = 0;
            int cl = 0;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(selectedFileName);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;


            for (rCnt = 2; rCnt <= rw; rCnt++)
            {

                //Has Route
                str = range.Cells[rCnt, 5].Text.ToString();
                if (!str.Equals(""))
                {
                    //GET ACRegNo
                    string f_regNo = range.Cells[rCnt, 3].Text.ToString();
                    AirPlane f_found = (AirPlane)allAircrafts.allAirCraft[f_regNo];
                    if (f_found == null)
                    {
                        if (f_regNo.Equals(""))
                        {
                            f_regNo = "UNKNOWN_ARR" + unknown_cnt++;
                        }
                        f_found = new AirPlane(f_regNo);
                    }

                    //GET ARRIVAL ROUTE
                    string arrival_from = "";
                    arrival_from = str.Substring(0, 3);
                    //departure_to = str.Substring(str.Length - 3, str.Length);
                    string f_time = "";
                    bool is_next_day = false;
                    //Convert time to minutes of the day
                    string str1 = range.Cells[rCnt, 6].Text.ToString();
                    if (str1[str1.Length - 1] == '+')
                    {
                        str1 = str1.Substring(0, str1.Length - 1);
                        is_next_day = true;
                    }
                    if (str1.Length > 2)
                    {
                        f_time = str1.Substring(0, str1.Length - 2) + ":" + str1.Substring(str1.Length - 2, 2);
                    }
                    else
                    {
                        f_time = "00:" + str1.Substring(str1.Length - 2, 2);
                    }

                    string[] b = f_time.Split(':');
                    int hour = Int32.Parse(b[0]);
                    int minute = Int32.Parse(b[1]);
                    if (is_next_day) hour += 24;
                    int f_timeT = hour * 60 + minute * 1;
                    if (f_timeT > allAircrafts.max_time) allAircrafts.max_time = f_timeT;
                    if (f_timeT < allAircrafts.min_time) allAircrafts.min_time = f_timeT;

                    Flight new_flight = new Flight();
                    new_flight.arrival_from = arrival_from;
                    new_flight.arrival_time = f_timeT;
                    new_flight.is_next_day_arr = is_next_day;
                    f_found.listArrival.Add(new_flight);

                    allAircrafts.allAirCraft[f_regNo] = f_found;




                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            btnLoadDepartureData.Enabled = true;
        }

        private void btnLoadDepartureData_Click(object sender, EventArgs e)
        {
            string selectedFileName = "";
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.Filter = "Excel files (*.xls,*.xlsl)|*.xls;*.xlsx";
            if (chooseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedFileName = chooseFile.FileName;
                depLink = selectedFileName;
            }
            else return;

            int unknown_cnt = 1;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt;
            int rw = 0;
            int cl = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(selectedFileName);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;


            for (rCnt = 2; rCnt <= rw; rCnt++)
            {

                //Has Route
                str = range.Cells[rCnt, 5].Text.ToString();
                if (!str.Equals(""))
                {
                    //GET ACRegNo
                    string f_regNo = range.Cells[rCnt, 3].Text.ToString();
                    AirPlane f_found = (AirPlane)allAircrafts.allAirCraft[f_regNo];
                    if (f_found == null)
                    {
                        if (f_regNo.Equals(""))
                        {
                            f_regNo = "UNKNOWN_DEP" + unknown_cnt++;
                        }
                        f_found = new AirPlane(f_regNo);
                    }

                    //GET DEPARTURE ROUTE
                    string departure_to = "";
                    departure_to = str.Substring(str.Length - 3, 3);
                    string f_time = "";
                    bool is_next_day = false;
                    //Convert time to minutes of the day
                    string str1 = range.Cells[rCnt, 6].Text.ToString();
                    if (str1[str1.Length - 1] == '+')
                    {
                        str1 = str1.Substring(0, str1.Length - 1);
                        is_next_day = true;
                    }
                    if (str1.Length > 2)
                    {
                        f_time = str1.Substring(0, str1.Length - 2) + ":" + str1.Substring(str1.Length - 2, 2);
                    }
                    else
                    {
                        f_time = "00:" + str1.Substring(str1.Length - 2, 2);
                    }

                    string[] b = f_time.Split(':');
                    int hour = Int32.Parse(b[0]);
                    int minute = Int32.Parse(b[1]);
                    if (is_next_day) hour += 24;
                    int f_timeT = hour * 60 + minute * 1;
                    if (f_timeT > allAircrafts.max_time) allAircrafts.max_time = f_timeT;
                    if (f_timeT < allAircrafts.min_time) allAircrafts.min_time = f_timeT;

                    Flight new_flight = new Flight();
                    new_flight.departure_to = departure_to;
                    new_flight.departure_time = f_timeT;
                    new_flight.is_next_day_dep = is_next_day;
                    f_found.listDeparture.Add(new_flight);

                    allAircrafts.allAirCraft[f_regNo] = f_found;


                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            btnLoadDepartureData.Enabled = false;
            initiate_Aircraft_Info();
            drawFlight('A');
        }

        private void drawFlight(char type)
        {
            //WE HAVE all aircrafts with their full info in mixedListFlights ---- allAircrafts
            //Setup aircraft_model
            var aircraft_model = new PlotModel { Title = "AirCraft" };
            aircraft_model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Minimum = allAircrafts.min_time - 60,
                Maximum = allAircrafts.max_time + 60,
                Title = "Time of day",
                LabelFormatter = (double arg) =>
                {
                    int args = (int)arg;
                    int min_f = args % 60;
                    int hour_f = args / 60;
                    hour_f = hour_f % 24;
                    string hh = "", mm = "";
                    if ((hour_f + "").Length == 1) hh = "0" + hour_f;
                    else hh = "" + hour_f;
                    if ((min_f + "").Length == 1) mm = "0" + min_f;
                    else mm = "" + min_f;
                    string time_str = hh + ":" + mm;
                    return time_str;
                }
            });

            aircraft_model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = -2, Maximum = allAircrafts.allAirCraft.Count + 2, Title = "ACRegNo" });

            //Each aircraft will plot its flights
            foreach (AirPlane ap in allAircrafts.allAirCraft.Values)
            {
                if(type == 'A') ap.plot_all_flights(aircraft_model);
                else if (type == 'D') ap.plot_domestic_flights(aircraft_model);
                else if (type == 'I') ap.plot_intl_flights(aircraft_model);
            }

            //Setup peak_model
            var peak_model = new PlotModel { Title = "Peak time" };
            peak_model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Minimum = allAircrafts.min_time - 60,
                Maximum = allAircrafts.max_time + 60,
                Title = "Time of day",
                LabelFormatter = (double arg) =>
                {
                    int args = (int)arg;
                    int min_f = args % 60;
                    int hour_f = args / 60;
                    hour_f = hour_f % 24;
                    string hh = "", mm = "";
                    if ((hour_f + "").Length == 1) hh = "0" + hour_f;
                    else hh = "" + hour_f;
                    if ((min_f + "").Length == 1) mm = "0" + min_f;
                    else mm = "" + min_f;
                    string time_str = hh + ":" + mm;
                    return time_str;
                }
            });



            //DRAW PEAK
            var peak_line = new LineSeries { StrokeThickness = 1, MarkerSize = 1 };
            int y_tmp = -1, max_cnt = 0;
            for (int i = allAircrafts.min_time; i < allAircrafts.max_time; i += 5)
            {
                int x_val = i;
                int y_val = 0;
                if(type == 'A') y_val = allAircrafts.cnt_all_flights_at_minuteTH(i);
                else  if (type == 'D') y_val = allAircrafts.cnt_domestic_flights_at_minuteTH(i);
                else if (type == 'I') y_val = allAircrafts.cnt_intl_flights_at_minuteTH(i);

                if (y_val > max_cnt) max_cnt = y_val;

                peak_line.Points.Add(new DataPoint(x_val, y_val));

                if (y_tmp != y_val)
                {
                    var pointAnnotation = new PointAnnotation();
                    pointAnnotation.X = i;
                    pointAnnotation.Y = y_val;
                    pointAnnotation.Text = y_val.ToString();
                    peak_model.Annotations.Add(pointAnnotation);
                    y_tmp = y_val;
                }

            }
            peak_model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Minimum = -2, Maximum = max_cnt + 2, Title = "Number flights arrival/departure" });
            peak_model.Series.Add(peak_line);

            this.plotPeak.Model = peak_model;
            this.plotFlights.Model = aircraft_model;
        }

        private void initiate_Aircraft_Info()
        {
            ICollection key = allAircrafts.allAirCraft.Keys;
            string[] sorted_keyset = new string[key.Count];
            int inx = 0;
            foreach (string k in key) sorted_keyset[inx++] = k;
            Array.Sort(sorted_keyset);

            int cnt_AC_no = 1;
            for (inx = 0; inx < sorted_keyset.Length; inx++)
            {
                AirPlane f = (AirPlane)allAircrafts.allAirCraft[sorted_keyset[inx]];
                f.resolve_mixedFlights(allAircrafts.min_time, allAircrafts.max_time);
                f.resolve_domestic_flights();
                f.OrderNr = cnt_AC_no++;
                //f.printItSelfMIXED();
            }
        }

        private void allFlights_CheckedChanged(object sender, EventArgs e)
        {
            tblPlot.Controls.Remove(plotFlights);
            tblPlot.Controls.Remove(plotPeak);
            initialPlots();
            drawFlight('A');
        }

        private void rdDomestic_CheckedChanged(object sender, EventArgs e)
        {
            tblPlot.Controls.Remove(plotFlights);
            tblPlot.Controls.Remove(plotPeak);
            initialPlots();
            drawFlight('D');
        }

        private void rdIntl_CheckedChanged(object sender, EventArgs e)
        {
            tblPlot.Controls.Remove(plotFlights);
            tblPlot.Controls.Remove(plotPeak);
            initialPlots();
            drawFlight('I');
        }

        private void initialPlots()
        {
            this.plotFlights = new OxyPlot.WindowsForms.PlotView();
            this.plotPeak = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();

            // 
            // plotFlights
            // 
            this.plotFlights.Location = new System.Drawing.Point(0, 50);
            this.plotFlights.Name = "Aircrafts";
            this.plotFlights.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotFlights.Size = new System.Drawing.Size(1200, 500);
            this.plotFlights.TabIndex = 0;
            this.plotFlights.Text = "Aircrafts";
            this.plotFlights.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotFlights.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotFlights.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotPeak
            // 
            //this.plotPeak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotPeak.Location = new System.Drawing.Point(0, 550);
            this.plotPeak.Name = "Peak Time";
            this.plotPeak.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotPeak.Size = new System.Drawing.Size(1200, 300);
            this.plotPeak.TabIndex = 1;
            this.plotPeak.Text = "Peak Time";
            this.plotPeak.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotPeak.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotPeak.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;

            tblPlot.Controls.Add(this.plotFlights,0,0);
            tblPlot.Controls.Add(this.plotPeak,0,1);
        }
    }
}
