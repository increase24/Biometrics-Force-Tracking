using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ad_angular
{
    public class MyQueue<T> : Queue<T>
    {
        public MyQueue(int maxsize)
        {
            this.MaxSize = maxsize;
        }
        public int MaxSize { get; set; }
        public void Enqueue(T t)
        {
            base.Enqueue(t);
            if (this.Count > MaxSize)
            {
                this.Dequeue();
            }
        }
    }
    //public double queueRMS()
    //{
    //    T[] dataSequence=this.ToArray();
    //    double rms=0;
    //    for (int i=0;i<this.MaxSize;i++)
    //    {
    //        rms += Math.Pow(dataSequence[i],2);
    //    }
    //    rms/=this.MaxSize;
    //    return rms;
    //}
}
