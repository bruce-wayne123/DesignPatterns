using System;

namespace DesignPatternsDemo
{
    public interface ILEDTV
    {
        void SwitchON();

        void SwitchOFF();

        void SetChannel(int channelNumber);
    }

    public class SamsungLEDTV : ILEDTV
    {
        public void SwitchON()
        {
            Console.WriteLine("Turning ON:Samsung TV");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine($"Setting Channel number{channelNumber} for Samsung TV");
        }

        public void SwitchOFF()
        {
            Console.WriteLine("Turning OFF:Samsung TV");
        }
    }

    public class LgTV : ILEDTV
    {
        public void SwitchON()
        {
            Console.WriteLine("Turning ON:Lg TV");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine($"Setting Channel number{channelNumber} for Lg TV");
        }

        public void SwitchOFF()
        {
            Console.WriteLine("Turning OFF:Lg TV");
        }
    }

    public abstract class AbstractRemoteControl
    {
        protected ILEDTV lEDTV;

        public AbstractRemoteControl(ILEDTV ledTV)
        {
            this.lEDTV = ledTV;
        }

        public abstract void SwitchOn();

        public abstract void SwitchOff();

        public abstract void SetChannel(int channelNumber);
    }

    public class SamsungRemoteControl : AbstractRemoteControl
    {
        public SamsungRemoteControl(ILEDTV lEDTv) : base(lEDTv)
        {
        }

        public override void SetChannel(int channelNumber)
        {
            lEDTV.SetChannel(channelNumber);
        }

        public override void SwitchOff()
        {
            lEDTV.SwitchOFF();
        }

        public override void SwitchOn()
        {
            lEDTV.SwitchON();
        }
    }

    public class LGRemoteControl : AbstractRemoteControl
    {
        public LGRemoteControl(ILEDTV lEDTV ):base(lEDTV)
        {

        }

        public override void SwitchOn()
        {
            lEDTV.SwitchON();
        }
        public override void SetChannel(int channelNumber)
        {
            lEDTV.SetChannel(channelNumber);
        }

        public override void SwitchOff()
        {
            lEDTV.SwitchOFF();
        }

       
    }
}