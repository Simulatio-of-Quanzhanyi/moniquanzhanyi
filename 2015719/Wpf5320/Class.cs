using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Windows;

using System.ComponentModel;


namespace Wpf5320
{
    class jiaodu
    {
        private float radian;
        private string dms = null;
        private int d, m, s;
        public float Radian
        {
            get { return this.radian;}
            set { this.radian = value; }

        }
        public string DMS
        {
            
            get
            {
                d=(int)(this.radian); 
                m=(int)((this.radian-d)*60);
                s=(int)(((this.radian-d)*60-m)*60);
                return d.ToString() + m.ToString() + s.ToString();
            }
            set { this.dms = value; }
        }
        public jiaodu(float Radian)
        {
            this.radian = Radian;
        }
        public jiaodu(int D, int M, int S)
        {
            this.d = D;
            this.m = M;
            this.s = S;
            this.radian = (float)(D + M / 60.0 + S / 3600.0);
        }
        public jiaodu()
        {
            this.radian = 0;
            this.d = 0;
            this.m = 0;
            this.s = 0;
        }
        public string v1
        {
            get;
            set;
        }
        public string v2
        {
            get;
            set;
        }
        public string v3
        {
            get;
            set;
        }
    }
    //定义点类
    public class Point_ylj
    {
        private double x;
        private double y;
        private double z;
        private string ptName;
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }
        public string PtName
        {
            get { return this.ptName; }
            set { this.ptName = value; }
        }
     /*   public double drawX
        {
            get
            {
                double
        }*/

        public Point_ylj()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.ptName = null;
        }

        public Point_ylj(double X, double Y, double Z)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;

        }
    }
//定义工具箱
    static class ToolCase
    {

        //一直测站，距离，水平角，高度角计算坐标点方法
        public static Point_ylj CalculationOfCoordinatePoints(Point_ylj StationPoint, double Dis, double Hhudu, double Vhudu)
        {
            double denrtaX = 0, denrtaY = 0, denrtaZ = 0;
            Point_ylj Point_P = new Point_ylj();
            denrtaX = (Dis * Math.Cos(Vhudu)) * Math.Cos(Hhudu);
            denrtaY = (Dis * Math.Cos(Vhudu)) * Math.Sin(Hhudu);
            denrtaZ = Dis * Math.Tan(Vhudu);
            //坐标
            Point_P.X = StationPoint.X + denrtaX;
            Point_P.Y = StationPoint.Y + denrtaY;
            Point_P.Z = StationPoint.Z + denrtaZ;
            return Point_P;
        }

      


        //求两个点的，斜距，平距及垂直距离
        public static double IIPointSD(Point_ylj FirstP, Point_ylj SeconP)
        {
            double SD;
            SD = Math.Sqrt((FirstP.X - SeconP.X) * (FirstP.X - SeconP.X) + (FirstP.Y - SeconP.Y) * (FirstP.Y - SeconP.Y) + (FirstP.Z - SeconP.Z) * (FirstP.Z - SeconP.Z));
            return SD;
        }
        public static double IIPointHD(Point_ylj FirstP, Point_ylj SeconP)
        {
            double HD;
            HD = Math.Sqrt((FirstP.X - SeconP.X) * (FirstP.X - SeconP.X) + (FirstP.Y - SeconP.Y) * (FirstP.Y - SeconP.Y));
            return HD;
        }
        public static double IIPointVD(Point_ylj FirstP, Point_ylj SeconP)
        {
            double HD;
            HD = Math.Abs(FirstP.Z - SeconP.Z);
            return HD;
        }
        public static double IIPointFW(Point_ylj FirstP, Point_ylj SeconP)
        {
            //先求出AB的象限角：
            //θ=arctan((Y2-Y1)/(X2-X1))
            /*再根据条件将象限角θ转换为方位角α：
            当X1-X2>0 时, Y1-Y2>0，α＝θ；
            当X1-X2<0时 , Y1-Y2>0，α＝θ+180° 
            当X1-X2<0 时, Y1-Y2<0，α＝θ+180°
            当X1-X2>0 时, Y1-Y2<0，α＝θ+360°*/
            double xita = 0;
            double FW = 0;
            xita = Math.Atan((SeconP.Y - FirstP.Y) / (SeconP.X - FirstP.X));
            if ((FirstP.X - SeconP.X > 0) && (FirstP.Y - SeconP.Y > 0))
            {
                FW = xita;
            }
            if ((FirstP.X - SeconP.X < 0))
            {
                FW = xita + Math.PI;
            }
            if ((FirstP.X - SeconP.X > 0) && (FirstP.Y - SeconP.Y < 0))
            {
                FW = xita + Math.PI * 2.0;
            }
            return FW;
        }
        
        
        //定义弧度转度分秒的方法
        public static string huduTojiaodu(double Radian)
        {
            int d, m, s;
            string DMS = null;
            double hudu;
            hudu=Radian/Math.PI/2*360;
            if (hudu > 0)
            {
                d = (int)hudu;
                m = (int)((hudu - d) * 60);
                s = (int)((((hudu - d) * 60) - m) * 60);
                DMS = d.ToString() + "." + m.ToString("d2") + s.ToString("d2");
            }
            else
            {
                hudu = -hudu;
                d = (int)hudu;
                m = (int)((hudu - d) * 60);
                s = (int)((((hudu - d) * 60) - m) * 60);
                DMS = "-" + d.ToString() + "." + m.ToString("d2") + s.ToString("d2");
            }
            return DMS;
        }
        //定义弧度制转角度制 度分秒
        public static string huduTojiaodu1(double Radian)
        {
            int d, m, s;
            string DMS = null;
            double hudu;
            hudu = Radian / Math.PI / 2 * 360;
            if (hudu > 0)
            {
                d = (int)hudu;
                m = (int)((hudu - d) * 60);
                s = (int)((((hudu - d) * 60) - m) * 60);
                DMS = d.ToString() + "°" + m.ToString("d2") + "'" + s.ToString("d2") + "''";
            }
            else
            {
                hudu = -hudu;
                d = (int)hudu;
                m = (int)((hudu - d) * 60);
                s = (int)((((hudu - d) * 60) - m) * 60);
                DMS = "-" + d.ToString() + "°" + m.ToString("d2") + "'" + s.ToString("d2") + "''";
            }
            return DMS;
        }


        //定义产生水平角方法，单位弧度（1）
        public static double HA // horizontal angle
        {
            get
            {
                double T = 0;
                Random Hrd = new Random();
                T = Hrd.NextDouble() * 2.0 * Math.PI;
                return T;
            }
        }
        //定义产生竖直角方法，单位弧度（1）
        public static double VA //Vertical angle理论值应该-90到90
        {
            get
            {
                Double T = 0;
                Random Vrd = new Random();
                T = Vrd.NextDouble() / 2 * Math.PI - Math.PI / 4;
                return T;
            }
        }
        //定义产生水平角方法，单位弧度（2）
        public static double HARadom  // horizontal angle
        {
          get
            {
              double T = 0;  
              Random Hrd = new Random();
              T = Hrd.NextDouble() * 2.0 * Math.PI;
              return T;
            }
         }



      //定义产生竖直角方法，单位弧度（2）
      public static double VARadom  //Vertical angle理论值应该-90到90
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble()/2 * Math.PI-Math.PI/4;
              return T;
          }
      }
      //定义产生距离随机数（1）
      public static double DistanceRadom  //
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble() *200+0.02;
              return T;
          }
      }
      //定义产生距离随机数（2）
      public static double Distance //
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble() * 180 + 0.02;
              return T;
          }
      }

      //定义产生不同的距离
      public static double Distance1 //
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble() * 300 + 0.02;
              return T;
          }
      }

      public static double Distance2 //
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble() * 260 + 0.04;
              return T;
          }
      }
      public static double Distance3 //
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble() * 400 + 0.01;
              return T;
          }
      }
      public static double Distance4 //
      {
          get
          {
              Double T = 0;
              Random Vrd = new Random();
              T = Vrd.NextDouble() * 180 + 0.03;
              return T;
          }
      }


      public static double DistanceN1(int n)//
      {

              Double T = 0;
              //int i;             
              Random Vrd = new Random();              
              T = Vrd.NextDouble() * 100*1.0/(n*4) + 0.01;
              return T;

      }

      public static double DistanceN2(int n)//
      {

          Double T = 0;
          //int i;             
          Random Vrd = new Random();
          T = Vrd.NextDouble() * 200 * 1.0 / (n * 4) + 0.01;
          return T;

      }

      public static double DistanceN3(int n)//
      {

          Double T = 0;
          //int i;             
          Random Vrd = new Random();
          T = Vrd.NextDouble() * 400 * 1.0 / (n * 5) + 0.01;
          return T;

      }

      public static double DistanceN4(int n)//
      {

          Double T = 0;
          //int i;             
          Random Vrd = new Random();
          T = Vrd.NextDouble() * 300 * 1.0 / (n * 4) + 0.01;
          return T;

      }

      // 定义点号增加1
      public static string PointNumberAdd1(string OriginalPN)
      {
          string newPNF = null;
          string newPN = null;
          //        string Temp = null;
          char T;
          int Lenth, i, PN;
          int CharLenth = 0;
          Lenth = OriginalPN.Length;
          for (i = Lenth - 1; i > 0; i = i - 1)
          {
              if (char.IsNumber(OriginalPN, i))
              {
                  T = OriginalPN[i];
                  newPNF += T;
              }
              else
              {
                  CharLenth = i + 1;
                  break;
              }
          }
          if (CharLenth == Lenth)
          {
              newPN = OriginalPN + "1";
          }
          else
          {
              for (i = newPNF.Length - 1; i > -1; i--)
              {
                  T = newPNF[i];
                  newPN += T;
              }
              newPN.Trim();
              PN = Convert.ToInt32(newPN);
              PN = PN + 1;
              newPN = OriginalPN.Substring(0, CharLenth) + PN.ToString();
          }
          return newPN;
      }
    }
    public class PointData : INotifyPropertyChanged
    {
       // private string pname;//点名
        private string n=null;
        private string e = null;
        private string z = null;
        //private string code;//编码
        private string ha;
        private string va;
        private string hd;
        private string vd;
        private string sd;
        public string N
        {
            get
            {
                return n;
            }
            set
            {
                this.n = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("N"));
                }
            }
        }

        public string E
        {
            get
            {
                return e;
            }
            set
            {
                this.e = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("E"));
                }
            }
        }
        public string Z
        {
            get
            {
                return z;
            }
            set
            {
                this.z = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Z"));
                }
            }
        }
        public string HA
        {
            get
            {
                return ha;
            }
            set
            {
                this.ha = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HA"));
                }
            }
        }
        public string VA
        {
            get
            {
                return va;
            }
            set
            {
                this.va = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("VA"));
                }
            }
        }
        public string HD
        {
            get
            {
                return hd;
            }
            set
            {
                this.hd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HA"));
                }
            }
        }
        public string VD
        {
            get
            {
                return vd;
            }
            set
            {
                this.vd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("VD"));
                }
            }
        }
        public string SD
        {
            get
            {
                return sd;
            }
            set
            {
                this.sd= value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SD"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
   
    }
    //在静态类里面定义全局变量
    public class GlobalVariables
    {
        public static string OpenItem = "";
        public GlobalVariables()
        {

        }
    }

}
