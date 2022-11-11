namespace SimpleCV.Data.Entities
{
    public class CVActivity 
    {
        public int CVId;
        public int ActivityId;

        /// Config 1:n relationship CVActivity:CV
        public CV? RefCV;

        // Config 1:n relationship CVActivity:Activity
        public Activity? RefActivity;
    }
}