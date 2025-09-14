namespace HW_mvc_9.Models
{
    public class Matrix
    {
        public int Size { get; set; } 

        public double[,] MatrixA { get; set; }
        public double[,] MatrixB { get; set; }
        public double[,] Result { get; set; }
        public string Operation { get; set; }
    }

}
