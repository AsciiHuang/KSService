using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSService
{
    public class Constants
    {
        public enum LayoutType
        {
            Landscape_Full, 
            Landscape_L1_R21, 
            Landscape_L1_R111, 
            Landscape_Full_BottomMarquee, 
            Landscape_BottomMarquee_L1_R11, 
            Landscape_BottomMarquee_L1_R21, 
            Portrait_Full, 
            Portrait_Full_TopMarquee, 
            Portrait_CenterMarquee_T1_B3,
            Portrait_T1_C1_B1, 
            Portrait_T1_C1_CL1_CR1_B1, 
        }

        public enum MediaType
        {
            Photo, Video, 
        }

        public enum MediaLayoutPosition
        {
            Default, 
            TL, TC, TR, 
            CL, CC, CR, 
            BL, BC, BR, 
        }

        public enum MarqueeLayoutPosition
        {
            Default, 
            MT, 
            MC, 
            MB, 
        }
    }
}
