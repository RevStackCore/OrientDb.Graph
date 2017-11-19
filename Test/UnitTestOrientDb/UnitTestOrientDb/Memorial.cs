using RevStackCore.OrientDb;
using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class Memorial : OrientDbEntity, IEntity<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
