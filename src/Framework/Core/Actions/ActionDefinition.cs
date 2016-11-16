namespace Aurora.Core.Actions
{
    public class ActionDefinition
    {
        public string Id { get; }
        public string ParentId { get; }
        public bool IsAbstract { get; }
        public IHandler DefaultHandler { get; }
        public IActionParameter[] Parameters { get; }

        public ActionDefinition(string id, bool isAbstract = false, string parentId = null, IHandler defaultHandler = null, IActionParameter[] parameters = null)
        {
            Id = id;
            ParentId = parentId;
            IsAbstract = isAbstract;
            DefaultHandler = defaultHandler;
            Parameters = parameters??new IActionParameter[0];
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ParentId)}: {ParentId}, {nameof(IsAbstract)}: {IsAbstract}, {nameof(Parameters)}: {Parameters}";
        }
    }
}