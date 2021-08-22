namespace MeatGrinderAPI.Models.ViewModels
{
    public class Cluster_VM_Put
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Site_ID { get; set; }

        public Cluster ConvertToModel()
        {
            Cluster cluster = new Cluster();

            if (this.ID != 0)
                cluster.ID = this.ID;
            if (this.User_ID != 0)
                cluster.User.ID = this.User_ID;
            if (this.Site_ID != 0)
                cluster.Site.ID = this.Site_ID;

            return cluster;
        }
    }
}