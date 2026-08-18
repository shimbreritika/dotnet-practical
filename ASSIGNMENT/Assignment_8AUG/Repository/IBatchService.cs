using Assignment19.Model;

namespace Assignment19.Repository
{
    public interface IBatchService
    {
        Batch GetBatch();

        Batch AddBatch(Batch batch);

        Batch UpdateBatch(int id ,Batch batch);

        Batch DeleteBatch(Batch batch);
    }
}
