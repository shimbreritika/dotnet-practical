using Assignment19.Data;
using Assignment19.Model;
using Assignment19.Repository;

namespace Assignment19.Service
{
    public class BatchService : IBatchService
    {
        private readonly AppDbContext context;

        public BatchService(AppDbContext context)
        {
            this.context = context;
        }

        public Batch GetBatch()
        {
            return context.Batchs.FirstOrDefault();
        }

        public Batch AddBatch(Batch batch)
        {
            context.Batchs.Add(batch);
            context.SaveChanges();

            return batch;
        }

        public Batch UpdateBatch(int id ,Batch batch)
        {
            context.Batchs.Update(batch);
            context.SaveChanges();

            return batch;
        }

        public Batch DeleteBatch(Batch batch)
        {
            context.Batchs.Remove(batch);
            context.SaveChanges();

            return batch;
        }
    }
}