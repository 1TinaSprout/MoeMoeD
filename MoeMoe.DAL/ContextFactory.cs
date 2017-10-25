using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MoeMoeD.Model;
using System.Threading;
using MoeMoeD.Model.Entity;

namespace MoeMoeD.DAL
{
    public class ContextFactory
    {
        public static Queue<MoeMoeDEntities> entityQueue = new Queue<MoeMoeDEntities>();
        public static Thread thread = new Thread(new ParameterizedThreadStart(EnQueue));

        public static MoeMoeDEntities GetDBContext()
        {
            if (entityQueue.Count == 0)
            {
                if(thread.ThreadState.Equals(ThreadState.Unstarted))
                {
                    thread.Start(entityQueue);
                }
                else
                {
                    thread.Resume();
                }

                return new MoeMoeDEntities();
            }
            else
            {
                return entityQueue.Dequeue();
            }
        }

        public static bool RevertDBContext(MoeMoeDEntities val)
        {
            if (val != null)
            {
                val.SaveChanges();
                entityQueue.Enqueue(val);
                return true;
            }
            return false;
        }

        private static void EnQueue(object obj)
        {
            var entityQueue = obj as Queue<MoeMoeDEntities>;

            while (true)
            {
                if (entityQueue.Count < 5)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        entityQueue.Enqueue(new MoeMoeDEntities());
                    }
                }
                else
                {
                    Thread.CurrentThread.Suspend();
                }
            }
        }
    }
}
