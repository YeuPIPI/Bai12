using System;

namespace Bai12
{
    public abstract class Motor
    {
        private double I_DinhMuc;
        private double I_PhanHoi;

        public Motor(double I_DinhMuc, double I_PhanHoi)
        {
            this.I_DinhMuc = I_DinhMuc;
            this.I_PhanHoi = I_PhanHoi;
        }

        public double I_DINHMUC { get => I_DinhMuc; set => I_DinhMuc = value; }
        public double I_PHANHOI { get => I_PhanHoi; set => I_PhanHoi = value; }
        public abstract bool MotorOverload();
    }
    public class ACMotor : Motor
    {
        private double Cos_Phi;
        public ACMotor(double I_DinhMuc, double I_PhanHoi, double Cos_phi) : base(I_DinhMuc, I_PhanHoi) 
        {
            this.Cos_Phi = Cos_Phi;
        }

        public double Cos_Phi1
        {
            get
            {
                return this.Cos_Phi;
            }
            set
            {
                if( this.Cos_Phi <= 1 && this.Cos_Phi >= -1)
                {
                    this.Cos_Phi = value;
                }
            }
        }

        public override bool MotorOverload()
        {
            if (I_DINHMUC > I_PHANHOI)
            {
                return true;
            }
            else return false;
        }
    }
    public class DCMotor : Motor
    {
        public DCMotor(double I_DinhMuc, double I_PhanHoi) : base(I_DinhMuc, I_PhanHoi) { }
        public override bool MotorOverload()
        {
            if (I_DINHMUC > I_PHANHOI)
            {
                return true;
            }
            else return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ACMotor a = new ACMotor(1.2,3.4,1);
            DCMotor b = new DCMotor(1.2,3.4);
            bool c = a.MotorOverload();
            bool e = b.MotorOverload();
            if (c)
            {
                Console.WriteLine("Dong co xoay chieu khong bi qua tai");
            }
            else
            {
                Console.WriteLine("Dong co xoay chieu bi qua tai");
            }
            if (e)
            {
                Console.WriteLine("Dong co 1 chieu khong bi qua tai");
            }
            else
            {
                Console.WriteLine("Dong co xoay chieu bi qua tai");
            }
        }
    }
}
