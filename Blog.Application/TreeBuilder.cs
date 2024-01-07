using Blog.Application.Interfaces;
using Blog.Domain.Base;

namespace Blog.Application
{
    public class TreeBuilder<T, K> 
        where T : class, IModelTree
        where K : ITree<K>
    {
        private readonly ICustomMapper<T, K> _mapper;
        public TreeBuilder(ICustomMapper<T, K> mapper)
        {
            _mapper = mapper;
        }
        public List<K> Build(IEnumerable<T> listModels, T? startParent = null) 
        {
            var listReturn = new List<K>();
            foreach (var model in listModels.Where(m => m.ParentId == startParent?.Id))
            {
                var stack = new Stack<T>();
                stack.Push(model);
                var modelParent = _mapper.ToViewModel(model);
                listReturn.Add(modelParent);
                while (stack.Count > 0)
                {
                    var temp = stack.Pop();
                    
                    foreach (var item in listModels.Where(m => m.ParentId == temp.Id))
                    {
                        var tempModel = _mapper.ToViewModel(item);
                        tempModel.Parent = modelParent;
                        modelParent.Child.Add(tempModel);
                        stack.Push(item);
                    }
                }
            }
            return listReturn;
            
        }
    }
}
